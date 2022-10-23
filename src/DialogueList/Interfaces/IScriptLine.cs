using DotnetTimecode;

namespace DialogueList.Interfaces
{
  /// <summary>
  /// Represents a script line.
  /// </summary>
  public interface IScriptLine
  {
    /// <summary>
    /// Represents the script line index.
    /// </summary>
    public int LineNumber { get; set; }
    /// <summary>
    /// Represents the script line start timecode.
    /// </summary>
    public Timecode? In { get; set; }
    /// <summary>
    /// Represents the script line end timecode.
    /// </summary>
    public Timecode? Out { get; set; }
    /// <summary>
    /// Represents the script line body text.
    /// </summary>
    public string Body { get; set; }
  }
}
