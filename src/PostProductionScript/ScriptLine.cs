using PostProductionScript.Interfaces;

using DotnetTimecode;

namespace PostProductionScript
{
  // TODO: Types of lines. Song, effect, action, dialogue.
  /// <summary>
  /// Represents a script line.
  /// </summary>
  public class ScriptLine : IScriptLine
  {
    public int LineNumber { get; set; }
    public Timecode? TimecodeIn { get; set; }
    public Timecode? TimecodeOut { get; set; }
    public string Source { get; set; }
    public string Dialogue { get; set; }
    public string BurnediInSubtitles { get; set; }
    public string OnScreenText { get; set; }
    public string Annotations { get; set; }
    /// <summary>
    /// Offsets the hours of the properties TimecodeIn and TimecodeOut.
    /// </summary>
    /// <param name="hours">The number of hours to offset.</param>
    public void OffsetHours(int hours)
    {
      TimecodeIn?.AddHours(hours);
      TimecodeOut?.AddHours(hours);
    }
    public void OffsetMinutes(int minutes)
    {
      TimecodeIn?.AddMinutes(minutes);
      TimecodeOut?.AddMinutes(minutes);
    }
    /// <summary>
    /// Offsets the seconds of the properties TimecodeIn and TimecodeOut.
    /// </summary>
    /// <param name="seconds">The number of seconds to offset.</param>
    public void OffsetSeconds(int seconds)
    {
      TimecodeIn?.AddSeconds(seconds);
      TimecodeOut?.AddSeconds(seconds);
    }
    /// <summary>
    /// Offsets the frames of the properties TimecodeIn and TimecodeOut.
    /// </summary>
    /// <param name="frames">The number of frames to offset.</param>
    public void OffsetFrames(int frames)
    {
      TimecodeIn?.AddFrames(frames);
      TimecodeOut?.AddFrames(frames);
    }
  }
}