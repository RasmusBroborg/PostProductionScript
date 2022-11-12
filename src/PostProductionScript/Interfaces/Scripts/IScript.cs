
using PostProductionScript.Interfaces.ScriptLines;

namespace PostProductionScript.Models.ScriptModels
{
  /// <summary>
  /// Provides an interface for the most basic form of script.
  /// </summary>
  public interface IScript
  {
    /// <summary>
    /// Represents the general description of the script.
    /// </summary>
    string Description { get; set; }
    /// <summary>
    /// Represents the general spoken language of the script.
    /// </summary>
    string Language { get; set; }
    /// <summary>
    /// Represents the script lines.
    /// </summary>
    IReadOnlyCollection<IScriptLine> Lines { get; }
    /// <summary>
    /// Represents the script title.
    /// </summary>
    string Title { get; set; }
    /// <summary>
    /// Inserts a line into the script.
    /// </summary>
    /// <param name="lineToInsert">The line to insert.</param>
    /// <param name="lineNumber">The line number position.</param>
    void InsertLine(IScriptLine lineToInsert, int lineNumber = 0);
    /// <summary>
    /// Removes a line from the script.
    /// </summary>
    /// <param name="lineNumber">The line number which should be removed.</param>
    void RemoveLine(int lineNumber);
    /// <summary>
    /// Updates a line in the script.
    /// </summary>
    /// <param name="lineNumber">The line number which should be updated.</param>
    void UpdateLine(IScriptLine lineToUpdate, int lineNumber);
  }
}