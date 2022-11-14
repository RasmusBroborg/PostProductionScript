using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotnetTimecode;

namespace PostProductionScript.Interfaces.Scripts
{
  public interface IFilmScript
  {
    /// <summary>
    /// Represents the feature film runtime.
    /// </summary>
    public Timecode? RunTime { get; set; }
  }
}