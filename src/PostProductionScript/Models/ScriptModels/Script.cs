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
    /// Represents the script lines.
    /// </summary>
    public List<IScriptLine> Lines { get; } = new List<IScriptLine>();
  }
}
