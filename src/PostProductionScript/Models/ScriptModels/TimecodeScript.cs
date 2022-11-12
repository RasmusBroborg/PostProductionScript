using DotnetTimecode.Enums;
using DotnetTimecode;

// TODO: DialogueLists,
// As Broadcast Script,
// Continuity Lists (Combined Continuity List, Spotting List, Combined Dialogue and Spotting List (CDSL), Combined Continuity and Spotting List (CCSL))

namespace PostProductionScript.Models.ScriptModels
{
  /// <summary>
  /// Represents the most basic form of timecoded script.
  /// </summary>
	public class TimecodeScript : Script, ITimecodeScript
  {
    public void OffsetHours(int hours)
    {
      for (int i = 0; i < _lines.Count; i++)
      {
        _lines[i]?.OffsetHours(hours);
      }
    }
    
    public void OffsetMinutes(int minutes)
    {
      for (int i = 0; i < Lines.Count; i++)
      {
        _lines[i]?.OffsetMinutes(minutes);
      }
    }

    public void OffsetSeconds(int seconds)
    {
      for (int i = 0; i < _lines.Count; i++)
      {
        _lines[i]?.OffsetSeconds(seconds);
      }
    }

    public void OffsetFrames(int frames)
    {
      for (int i = 0; i < _lines.Count; i++)
      {
        _lines[i]?.OffsetFrames(frames);
      }
    }

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
      for (int i = 0; i < _lines.Count; i++)
      {
        var tcIn = _lines[i]?.TimecodeIn;
        var tcOut = _lines[i]?.TimecodeOut;

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

        var lineWithUpdTimecodes = _lines[i];
        lineWithUpdTimecodes.TimecodeIn = tcIn;
        lineWithUpdTimecodes.TimecodeIn = tcOut;

        _lines[i] = lineWithUpdTimecodes;
      }
    }

    /// <summary>
    /// Converts all of the lines timecode values to the target framerate.
    /// </summary>
    /// <param name="framerate">The target framerate.</param>
    private void ConvertAllTimecodeFramerates(Framerate framerate)
    {
      for (int i = 0; i < _lines.Count; i++)
      {
        _lines[i]?.TimecodeIn?.ConvertFramerate(framerate);
        _lines[i]?.TimecodeOut?.ConvertFramerate(framerate);
      }
      return;
    }
  }
}
