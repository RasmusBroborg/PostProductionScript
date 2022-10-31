using DotnetTimecode;

namespace PostProductionScript.Interfaces
{
  /// <summary>
  /// Represents a script line.
  /// </summary>
  public interface IScriptLine
  {
    public int LineNumber { get; set; }
    public Timecode? TimecodeIn { get; set; }
    public Timecode? TimecodeOut { get; set; }
    public string Source { get; set; }
    public string Body { get; set; }
    public string Annotations { get; set; }
    /// <summary>
    /// Offsets the hours of the properties TimecodeIn and TimecodeOut.
    /// </summary>
    /// <param name="hours">The number of hours to offset.</param>
    public void OffsetHours(int hours);
    /// <summary>
    /// Offsets the minutes of the properties TimecodeIn and TimecodeOut.
    /// </summary>
    /// <param name="minutes">The number of minutes to offset.</param>
    public void OffsetMinutes(int minutes);
    /// <summary>
    /// Offsets the seconds of the properties TimecodeIn and TimecodeOut.
    /// </summary>
    /// <param name="seconds">The number of seconds to offset.</param>
    public void OffsetSeconds(int seconds);
    /// <summary>
    /// Offsets the frames of the properties TimecodeIn and TimecodeOut.
    /// </summary>
    /// <param name="frames">The number of frames to offset.</param>
    public void OffsetFrames(int frames);
  }
}
