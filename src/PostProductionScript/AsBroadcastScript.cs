using PostProductionScript.Interfaces;

using DotnetTimecode.Enums;
using DotnetTimecode;

// TODO: DialogueLists,
// As Broadcast Script,
// Continuity Lists (Combined Continuity List, Spotting List, Combined Dialogue and Spotting List (CDSL), Combined Continuity and Spotting List (CCSL))

namespace PostProductionScript
{
  /// <summary>
  /// Represents the most basic form of dialogue script.
  /// </summary>
	public class AsBroadcastScript
  {
    /// <summary>
    /// Represents the show title.
    /// </summary>
    public string ShowTitle { get; set; } = "";

    /// <summary>
    /// Represents the episode title.
    /// </summary>
    public string EpisodeTitle { get; set; } = "";

    /// <summary>
    /// Represents the season number.
    /// </summary>
    public int SeasonNumber { get; set; }

    /// <summary>
    /// Represents the episode number.
    /// </summary>
    public int EpisodeNumber { get; set; }

    /// <summary>
    /// Represents the general spoken language of the script.
    /// </summary>
    public string Language { get; set; } = "";

    /// <summary>
    /// Represents the general description of the script.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// Represents the episode runtime.
    /// </summary>
    public Timecode? RunTime { get; set; }

    /// <summary>
    /// Represents the script lines.
    /// </summary>
    public List<IScriptLine> Lines { get; } = new List<IScriptLine>();

    /// <summary>
    /// Offsets the hours of all script lines by a given amount.
    /// </summary>
    /// <param name="hours">The number of hours to to offset.</param>
    public void OffsetHours(int hours)
    {
      for (int i = 0; i < Lines.Count; i++)
      {
        Lines[i]?.OffsetHours(hours);
      }
    }
    /// <summary>
    /// Offsets the minutes of all script lines by a given amount.
    /// </summary>
    /// <param name="minutes">The number of minutes to offset.</param>
    public void OffsetMinutes(int minutes)
    {
      for (int i = 0; i < Lines.Count; i++)
      {
        Lines[i]?.OffsetMinutes(minutes);
      }
    }

    /// <summary>
    /// Offsets the seconds of all script lines by a given amount.
    /// </summary>
    /// <param name="seconds">The number of seconds to offset.</param>
    public void OffsetSeconds(int seconds)
    {
      for (int i = 0; i < Lines.Count; i++)
      {
        Lines[i]?.OffsetSeconds(seconds);
      }
    }

    /// <summary>
    /// Offsets the frames of all script lines by a given amount.
    /// </summary>
    /// <param name="frames">The number of frames to add to all script lines</param>
    public void OffsetFrames(int frames)
    {
      for (int i = 0; i < Lines.Count; i++)
      {
        Lines[i]?.OffsetFrames(frames);
      }
    }

    /// <summary>
    /// Changes the scripts framerate.
    /// </summary>
    /// <param name="framerate">The script target framerate.</param>
    /// <param name="convertExistingTimecodes">Determines if all existing timecodes should be converted to the target framerate. 
    /// <br/> True set as default behaviour.</param>
    public void ChangeScriptFramerate(Framerate framerate, bool convertExistingTimecodes = true)
    {
      if (convertExistingTimecodes)
      {
        ConvertAllTimecodeFramerates(framerate);
        return;
      }
      ReplaceAllTimecodesWithUpdatedFramerates(framerate);
    }

    /// <summary>
    /// Replaces all timecodes with new timecode objects with updated framerates.
    /// The timecode hours, minutes, seconds, and frames remain unchanged.
    /// </summary>
    /// <param name="framerate">The target framerate.</param>
    private void ReplaceAllTimecodesWithUpdatedFramerates(Framerate framerate)
    {
      for (int i = 0; i < Lines.Count; i++)
      {
        var tcIn = Lines[i]?.TimecodeIn;
        var tcOut = Lines[i]?.TimecodeOut;

        tcIn = tcIn is not null
          ? new Timecode(
            tcIn!.Hour,
            tcIn!.Minute,
            tcIn.Second,
            tcIn.Frame,
            framerate)
          : null;

        tcOut = tcOut is not null
          ? new Timecode(
            tcOut!.Hour,
            tcOut!.Minute,
            tcOut.Second,
            tcOut.Frame,
            framerate)
          : null;

        var lineWithUpdTimecodes = Lines[i];
        lineWithUpdTimecodes.TimecodeIn = tcIn;
        lineWithUpdTimecodes.TimecodeIn = tcOut;

        Lines[i] = lineWithUpdTimecodes;
      }
    }

    /// <summary>
    /// Converts all of the lines timecode values to the target framerate.
    /// </summary>
    /// <param name="framerate">The target framerate.</param>
    private void ConvertAllTimecodeFramerates(Framerate framerate)
    {
      for (int i = 0; i < Lines.Count; i++)
      {
        Lines[i]?.TimecodeIn?.ConvertFramerate(framerate);
        Lines[i]?.TimecodeOut?.ConvertFramerate(framerate);
      }
      return;
    }

    // TODO: Fix line classes. Must insert a new line and update the line numbers of all other lines.

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lineToInsert">The line to insert.</param>
    /// <param name="lineNumber">The line number position.</param>
    public void InsertLine(IScriptLine lineToInsert, int lineNumber = 0)
    {
      if (lineNumber == 0)
      {
        Lines.Add(lineToInsert);
        Lines.Last().LineNumber = Lines.Count;
        return;
      }

      // Hantera logik för om lineNumber specificeras
      Lines.Insert(lineNumber - 1, lineToInsert);
      for(int i = 0; i < Lines.Count; i++)
      {
        Lines[i].LineNumber = i + 1;
      }
    }

    /// <summary>
    /// Removes a line from the script.
    /// </summary>
    /// <param name="lineNumber">The line number which should be removed.</param>
    public void RemoveLine(int lineNumber)
    {
      throw new NotImplementedException();
    }
  }
}
