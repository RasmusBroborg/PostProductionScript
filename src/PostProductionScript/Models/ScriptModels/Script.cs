using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PostProductionScript.Interfaces;

namespace PostProductionScript.Models.ScriptModels
{
  public class Script
  {
    /// <summary>
    /// Represents the script title.
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// Represents the general description of the script.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// Represents the script lines.
    /// </summary>
    public IReadOnlyCollection<IScriptLine> Lines => _lines.AsReadOnly();

    internal List<IScriptLine> _lines { get; } = new List<IScriptLine>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lineToInsert">The line to insert.</param>
    /// <param name="lineNumber">The line number position.</param>
    public void InsertLine(IScriptLine lineToInsert, int lineNumber = 0)
    {
      if (lineNumber == 0)
      {
        _lines.Add(lineToInsert);
        _lines.Last().LineNumber = Lines.Count;
        return;
      }

      // Hantera logik för om lineNumber specificeras
      _lines.Insert(lineNumber - 1, lineToInsert);
      for (int i = 0; i < Lines.Count; i++)
      {
        _lines[i].LineNumber = i + 1;
      }
    }

    /// <summary>
    /// Removes a line from the script.
    /// </summary>
    /// <param name="lineNumber">The line number which should be removed.</param>
    public void RemoveLine(int lineNumber)
    {
      _lines.RemoveAt(lineNumber - 1);
      for (int i = lineNumber - 1; i < Lines.Count; i++)
      {
        _lines[i].LineNumber = i + 1;
      }
    }
  }
}
