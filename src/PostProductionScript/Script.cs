using PostProductionScript.Interfaces;

using DotnetTimecode.Enums;

// TODO: DialogueLists,
// As Broadcast Script,
// Continuity Lists (Combined Continuity List, Spotting List, Combined Dialogue and Spotting List (CDSL), Combined Continuity and Spotting List (CCSL))

namespace PostProductionScript
{
  /// <summary>
  /// Represents the most basic form of dialogue script.
  /// </summary>
	public class Script
  {
    /// <summary>
    /// Represents the script title.
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// Represents the general spoken language of the script.
    /// </summary>
    public string Language { get; set; } = "";

    /// <summary>
    /// Represents the general description of the script.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// Represents the script lines.
    /// </summary>
    public List<IScriptLine> Lines { get; } = new List<IScriptLine>();

    /// <summary>
    /// Offsets the hours of all script lines by a given amount.
    /// </summary>
    /// <param name="hours">The number of hours to add to all script lines.</param>
    public void OffsetHours(int hours)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Offsets the minutes of all script lines by a given amount.
    /// </summary>
    /// <param name="minutes">The number of minutes to add to all script lines</param>
    public void OffsetMinutes(int minutes)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Offsets the seconds of all script lines by a given amount.
    /// </summary>
    /// <param name="seconds">The number of seconds to add to all script lines</param>
    public void OffsetSeconds(int seconds)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Offsets the frames of all script lines by a given amount.
    /// </summary>
    /// <param name="frames">The number of frames to add to all script lines</param>
    public void OffsetFrames(int frames)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Changes the scripts framerate.
    /// </summary>
    /// <param name="framerate">The script target framerate.</param>
    /// <param name="convertExistingTimecodes">Determines if all existing timecodes should be converted to the target framerate. 
    /// <br/> True set as default behaviour.</param>
    public void ChangeScriptFramerate(Framerate framerate, bool convertExistingTimecodes = true)
    {
      throw new NotImplementedException();
    }

    // TODO: Fix line classes. Must insert a new line and update the line numbers of all other lines.
    /// <summary>
    /// Adds a line from the script.
    /// </summary>
    /// <param name="lineNumber">The line number which should be removed.</param>
    public void InsertLine(int lineNumber)
    {
      throw new NotImplementedException();
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
