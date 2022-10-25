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
    public void OffsetHours(int hours)
    {
      TimecodeIn?.AddHours(hours);
      TimecodeOut?.AddHours(hours);
    }
  }
}