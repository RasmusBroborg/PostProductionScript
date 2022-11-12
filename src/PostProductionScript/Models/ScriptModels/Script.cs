using PostProductionScript.Interfaces.ScriptLines;

namespace PostProductionScript.Models.ScriptModels
{
  /// <summary>
  /// Represents the most basic form of script.
  /// </summary>
  public class Script : IScript
  {    
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Language { get; set; } = "";
    
    public IReadOnlyCollection<IScriptLine> Lines => _lines.AsReadOnly();

    protected readonly List<IScriptLine> _lines = new List<IScriptLine>();
    
    public void InsertLine(IScriptLine lineToInsert, int lineNumber = 0)
    {
      if (lineNumber == 0)
      {
        _lines.Add(lineToInsert);
        _lines.Last().LineNumber = Lines.Count;
        return;
      }
      _lines.Insert(lineNumber - 1, lineToInsert);
      UpdateLineNumbers(lineNumber);
    }
    
    public void RemoveLine(int lineNumber)
    {
      _lines.RemoveAt(lineNumber - 1);
      UpdateLineNumbers(lineNumber);
    }

    public void UpdateLine(IScriptLine lineToUpdate, int lineNumber)
    {
      _lines.RemoveAt(lineNumber - 1);
      InsertLine(lineToUpdate, lineToUpdate.LineNumber);
      UpdateLineNumbers();
    }

    /// <summary>
    /// Iterates through a collection of lines and updates their line numbers 
    /// to match their position in the collection.
    /// </summary>
    /// <param name="lineNumber">Optional argument. Updates all lines starting from the variable lineNumber.</param>
    private void UpdateLineNumbers(int lineNumber = 1)
    {
      for (int i = lineNumber - 1; i < Lines.Count; i++)
      {
        _lines[i].LineNumber = i + 1;
      }
    }
  }
}
