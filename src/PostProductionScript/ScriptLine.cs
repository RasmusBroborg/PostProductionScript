using PostProductionScript.Interfaces;

using DotnetTimecode;

namespace PostProductionScript
{
  // TODO: Types of lines. Song, effect, action, dialogue.


  /// <summary>
  /// Represents a script line.
  /// </summary>
  public abstract class ScriptLine : IScriptLine
  {
    public int LineNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Timecode? TimecodeIn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Timecode? TimecodeOut { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Body { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  }
}