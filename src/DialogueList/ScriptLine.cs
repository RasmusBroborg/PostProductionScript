using DialogueList.Interfaces;

using DotnetTimecode;

namespace DialogueList
{
  // TODO: Types of lines. Song, effect, action, dialogue.


  /// <summary>
  /// Represents a script line.
  /// </summary>
  public abstract class ScriptLine : IScriptLine
  {
    public int LineNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Timecode? In { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Timecode? Out { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Body { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  }
}