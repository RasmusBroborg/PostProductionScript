using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using DotnetTimecode;

using FluentAssertions;
using PostProductionScript;

namespace PostProductionScript_Test
{
  public class AsBroadcastScript_Test
  {
    [Fact]
    public void AddLinesToClass_ValidInputs_Success()
    {
      // Arrange
      var script = new AsBroadcastScript();

      // Act
      var newDialogueLine = new DialogueLine()
      {
        Body = "Hejsan",
        Source = "Rasmus",
        BurnedInSubtitles = "Ola",
        Annotations = "Greeting phrase",
        LineNumber = 1,
        TimecodeIn = new Timecode("10:00:01:01", DotnetTimecode.Enums.Framerate.fps24),
        TimecodeOut = new Timecode("10:00:02:01", DotnetTimecode.Enums.Framerate.fps24)
      };

      var newOnScreenLine = new OnScreenTextLine()
      {
        Body = "A NETFLIX ORIGINAL SERIES",
        Source = "CREDIT",
        LineNumber = 2,
        TimecodeIn = new Timecode("10:00:03:01", DotnetTimecode.Enums.Framerate.fps24),
        TimecodeOut = new Timecode("10:00:05:01", DotnetTimecode.Enums.Framerate.fps24)
      };

      script.Lines.Add(newDialogueLine);
      script.Lines.Add(newOnScreenLine);


      // Assert
      script.Lines[0].Body.Should().Be("Hejsan");
      script.Lines[1].Body.Should().Be("A NETFLIX ORIGINAL SERIES");
    }

    [Fact]
    public void InsertLine_Insert3LinesUpdateLineNumbers_Successful()
    {
      // Arrange
      var script = new AsBroadcastScript();

      // Act
      var line1 = new DialogueLine();
      var line2 = new OnScreenTextLine();
      var line3 = new OnScreenTextLine();

      script.InsertLine(line1);
      script.InsertLine(line2);
      script.InsertLine(line3);

      // Assert
      script.Lines[0].LineNumber.Should().Be(1);
      script.Lines[1].LineNumber.Should().Be(2);
      script.Lines[2].LineNumber.Should().Be(3);
    }

    [Fact]
    public void InsertLine_Insert1LinesUpdateOtherLines_Successful()
    {
      // Arrange
      var script = new AsBroadcastScript();

      // Act
      var line1 = new DialogueLine() { Body = "First Line"};
      var line2 = new OnScreenTextLine(){ Body = "Second Line" };
      var line3 = new OnScreenTextLine() { Body = "Third Line" };

      script.InsertLine(line1);
      script.InsertLine(line2);
      script.InsertLine(line3, 1);

      // Assert
      script.Lines[0].Body.Should().Be("Third Line");
      script.Lines[0].LineNumber.Should().Be(1);

      script.Lines[1].Body.Should().Be("First Line");
      script.Lines[1].LineNumber.Should().Be(2);

      script.Lines[2].Body.Should().Be("Second Line");
      script.Lines[2].LineNumber.Should().Be(3);
    }

  }
}
