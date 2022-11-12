using DotnetTimecode.Enums;

namespace PostProductionScript.Models.ScriptModels
{
  public interface ITimecodeScript
  {
    /// <summary>
    /// Changes the scripts framerate.
    /// </summary>
    /// <param name="framerate">The script target framerate.</param>
    /// <param name="convertExistingTimecodes">Determines if all existing timecodes should be converted to the target framerate. 
    /// <br/> True set as default behaviour.</param>
    void ChangeScriptFramerate(Framerate framerate, bool convertExistingTimecodes = true);
    /// <summary>
    /// Offsets the frames of all script lines by a given amount.
    /// </summary>
    /// <param name="frames">The number of frames to add to all script lines</param>
    void OffsetFrames(int frames);
    /// <summary>
    /// Offsets the hours of all script lines by a given amount.
    /// </summary>
    /// <param name="hours">The number of hours to to offset.</param>
    void OffsetHours(int hours);
    /// <summary>
    /// Offsets the minutes of all script lines by a given amount.
    /// </summary>
    /// <param name="minutes">The number of minutes to offset.</param>
    void OffsetMinutes(int minutes);
    /// <summary>
    /// Offsets the seconds of all script lines by a given amount.
    /// </summary>
    /// <param name="seconds">The number of seconds to offset.</param>
    void OffsetSeconds(int seconds);
  }
}