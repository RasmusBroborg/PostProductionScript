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
    public string Body { get; set; } = string.Empty;
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
      TimecodeIn?.AddHours(minutes);
      TimecodeOut?.AddHours(minutes);
    }
  }
}