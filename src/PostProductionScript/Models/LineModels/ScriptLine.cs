using DotnetTimecode;

using PostProductionScript.Interfaces.ScriptLines;

namespace PostProductionScript.Models.LineModels
{
  public abstract class ScriptLine : IScriptLine
  {
    public int LineNumber { get; set; }
    public Timecode? TimecodeIn { get; set; }
    public Timecode? TimecodeOut { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string Annotations { get; set; } = string.Empty;

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

    public void OffsetSeconds(int seconds)
    {
      TimecodeIn?.AddSeconds(seconds);
      TimecodeOut?.AddSeconds(seconds);
    }

    public void OffsetFrames(int frames)
    {
      TimecodeIn?.AddFrames(frames);
      TimecodeOut?.AddFrames(frames);
    }
  }
}