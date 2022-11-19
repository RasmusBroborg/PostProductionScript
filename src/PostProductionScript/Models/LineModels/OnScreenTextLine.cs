using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotnetTimecode;

namespace PostProductionScript.Models.LineModels
{
  public class OnScreenTextLine : ScriptLine
  {
    public OnScreenTextLine(Timecode? timecodeIn, Timecode? timecodeOut, string body)
    {
      TimecodeIn = timecodeIn;
      TimecodeOut = timecodeOut;
      Body = body;
    }
  }
}
