namespace PostProductionScript.Models.LineModels
{
  // TODO: Types of lines. Song, effect, action, dialogue.
  /// <summary>
  /// Represents a script line.
  /// </summary>
  public class DialogueLine : ScriptLine
  {
    public string BurnedInSubtitles { get; set; } = string.Empty;
  }
}