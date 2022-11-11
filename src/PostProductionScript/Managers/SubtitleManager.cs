using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using DotnetTimecode;
using DotnetTimecode.Enums;

using PostProductionScript.Models.LineModels;
using PostProductionScript.Models.ScriptModels;

namespace PostProductionScript.Managers
{
  public static class SubtitleManager
  {
    internal static string srtContentRegexPattern = @"(( *)(?<Linenumber>[0-9])+(\r\n|\r|\n)( *){0,1}(?<TimecodeIn>(([0-9]){2}:){2}(([0-9]){2})(,)([0-9]){3}) *-->( ){*}{0,1}(?<TimecodeOut>(([0-9]){2}:){2}(([0-9]){2})(,)([0-9]){3})(\r\n|\r|\n)(?<Body>[^\r\n]+((\r|\n|\r\n)[^\r\n]+)*))";

    /// <summary>
    /// Constructs an AsBroadcastScript from the contents of a .srt-file.
    /// </summary>
    /// <param name="srtFileContent">The string content of a .srt file.</param>
    /// <param name="framerate">The target timecode framerate.</param>
    /// <returns>A script object with all of the srt timecode values converted into script lines.</returns>
    public static AsBroadcastScript ConvertSrtToAsBroadcastScript(string srtFileContent, Framerate framerate)
    {
      // Split into smaller string chunks

      string[] srtSubstrings = Regex.Matches(srtFileContent, srtContentRegexPattern)
        .Cast<Match>().Select(m => m.Value).ToArray();

      AsBroadcastScript script = new AsBroadcastScript();

      foreach (var srtSubstring in srtSubstrings)
      {
        Regex pattern = new Regex(srtContentRegexPattern);
        Match match = pattern.Match(srtSubstring);

        int lineNumber = int.Parse(match.Groups["Linenumber"].Value);
        string timecodeInStr = Timecode.ConvertSrtTimecodeToTimecode(match.Groups["TimecodeIn"].Value, framerate);
        string timecodeOutStr = Timecode.ConvertSrtTimecodeToTimecode(match.Groups["TimecodeOut"].Value, framerate);
        Timecode timecodeIn = new Timecode(timecodeInStr, framerate);
        Timecode timecodeOut = new Timecode(timecodeOutStr, framerate);
        string body = match.Groups["Body"].Value;

        DialogueLine dialogueLine = new DialogueLine
        {
          LineNumber = lineNumber,
          TimecodeIn = timecodeIn,
          TimecodeOut = timecodeOut,
          Body = body,
        };

        script.InsertLine(dialogueLine);
      }

      return script;
    }
  }
}
