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
    /// <summary>
    /// Regex of a .srt dialogue line.<br/>
    /// <br/>
    /// Example dialogue line:<br/>
    /// 1<br/>
    /// 01:01:01:500 --> 01:01:05:500<br/>
    /// Lorem ipsum dolor sit amet, consectetur adipiscing elit.
    /// </summary>
    internal readonly static string srtContentRegexPattern =
      @"(( *)(?<Linenumber>[0-9])+(\r\n|\r|\n)( *){0,1}(?<TimecodeIn>(([0-9]){2}:){2}(([0-9]){2})(,)([0-9]){3}) *-->( ){*}{0,1}(?<TimecodeOut>(([0-9]){2}:){2}(([0-9]){2})(,)([0-9]){3})(\r\n|\r|\n)(?<Body>[^\r\n]+((\r|\n|\r\n)[^\r\n]+)*))";

    /// <summary>
    /// Constructs a TimecodeScript from the contents of a .srt-file.
    /// </summary>
    /// <param name="srtFileContent">The string content of a .srt file.</param>
    /// <param name="framerate">The target timecode framerate.</param>
    /// <returns>A script object with all of the srt timecode values converted into script lines.</returns>
    public static TimecodeScript ConvertSrtToTimecodeScript(string srtFileContent, Framerate framerate)
    {
      string[] srtSubstrings = ExtractSrtSubstrings(srtFileContent);
      TimecodeScript script = new TimecodeScript();
      foreach (var srtSubstring in srtSubstrings)
      {
        ExtractSrtValues(srtSubstring, framerate,
          out int lineNumber,
          out Timecode timecodeIn,
          out Timecode timecodeOut,
          out string body);

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

    /// <summary>
    /// Extracts substrings of an entire .srt file. Each substring consists of a srt dialogue line,<br/>
    /// with a line number, a start timecode, an end timecode, and a body of text.<br/>
    /// <br/>
    /// Example substring:<br/>
    /// 1<br/>
    /// 01:01:01:500 --> 01:01:05:500<br/>
    /// Lorem ipsum dolor sit amet, consectetur adipiscing elit.
    /// </summary>
    /// <param name="srtFileContent">The content of an entire .srt file.</param>
    /// <returns>An array of substrings, for each line of the .srt file.</returns>
    private static string[] ExtractSrtSubstrings(string srtFileContent)
    {
      return Regex.Matches(srtFileContent, srtContentRegexPattern)
        .Cast<Match>().Select(m => m.Value).ToArray();
    }

    /// <summary>
    /// Extracts line variables from a .srt substring which consists of a srt dialogue line,<br/>
    /// with a line number, a start timecode, an end timecode, and a body of text.<br/><br/>
    /// Example substring:<br/>
    /// 1<br/>
    /// 01:01:01:500 --> 01:01:05:500<br/>
    /// Lorem ipsum dolor sit amet, consectetur adipiscing elit.
    /// </summary>
    /// <param name="srtSubstring">The .srt substring to extract variables from.</param>
    /// <param name="framerate">The target framerate.</param>
    /// <param name="lineNumber">A line number.</param>
    /// <param name="timecodeIn">A timecode representing the line start time.</param>
    /// <param name="timecodeOut">A timecode representing the line end time.</param>
    /// <param name="body">The line body.</param>
    private static void ExtractSrtValues(
      string srtSubstring, Framerate framerate,
      out int lineNumber, out Timecode timecodeIn, out Timecode timecodeOut, out string body)
    {
      Regex pattern = new Regex(srtContentRegexPattern);
      Match match = pattern.Match(srtSubstring);
      string timecodeInStr = Timecode.ConvertSrtTimecodeToTimecode(match.Groups["TimecodeIn"].Value, framerate);
      string timecodeOutStr = Timecode.ConvertSrtTimecodeToTimecode(match.Groups["TimecodeOut"].Value, framerate);
      timecodeIn = new Timecode(timecodeInStr, framerate);
      timecodeOut = new Timecode(timecodeOutStr, framerate);
      lineNumber = int.Parse(match.Groups["Linenumber"].Value);
      body = match.Groups["Body"].Value;
    }
    private static string GenerateSrtText(TimecodeScript script)
    {
      string result = "";
      for (int i = 0; i < script.Lines.Count; i++)
      {
        result += script.Lines.ElementAt(i).LineNumber + "/n" +
           script.Lines.ElementAt(i).TimecodeIn + " -> " +
           script.Lines.ElementAt(i).TimecodeOut + "/n" +
           script.Lines.ElementAt(i).Body + "/n";
      }
      return result;
    }
  }
}
