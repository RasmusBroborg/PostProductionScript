using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotnetTimecode.Enums;

using PostProductionScript.Models.ScriptModels;

namespace PostProductionScript.Managers
{
  internal static class SubtitleManager
  {
    /// <summary>
    /// Imports the content of a .srt-file and constructs a script object.
    /// </summary>
    /// <param name="filepath">The filepath to the .srt file.</param>
    /// <param name="framerate">The target timecode framerate.</param>
    /// <returns>A script object with all of the srt timecode values converted into script lines.</returns>
    public static AsBroadcastScript ImportSrtFile(string filepath, Framerate framerate)
    {
      throw new NotImplementedException();
    }
  }
}
