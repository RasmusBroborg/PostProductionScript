using System.Linq;
using PostProductionScript.Managers;
using DotnetTimecode.Enums;

using Xunit;
using FluentAssertions;
using System.Text;
using System.IO;

namespace PostProductionScript_Test.Managers
{
  public class SubtitleManager_Test
  {
    public static readonly string EXAMPLE_SRT_STRING = @$"
1
00:00:00,000 --> 00:00:01,500
Lorem ipsum dolor sit amet,
consectetur adipiscing elit.

2
00:00:01,000 --> 00:00:02,500
Sed do eiusmod tempor incididunt
ut labore et dolore magna aliqua.

3
00:00:02,000 --> 00:00:03,500
Justo donec enim diam vulputate.

4
00:00:03,000 --> 00:00:04,500
Id cursus metus aliquam eleifend
mi in nulla.

5
00:00:04,000 --> 00:00:05,500
Ornare aenean euismod elementum nisi.
Sit amet mattis vulputate enim.

6
00:00:05,000 --> 00:00:06,500
Fermentum dui faucibus in ornare quam
viverra. Elit eget gravida cum sociis
natoque penatibus et magnis dis.
";

    [Fact]
    public void ConvertSrtToTimecodeScript_ValidInput_Successful()
    {
      // Arrange
      var framerate = Framerate.fps24;
      var validSrt = EXAMPLE_SRT_STRING;

      // Act
      var result = SubtitleManager.ConvertSrtTextToTimecodeScript(validSrt, framerate);

      // Assert
      result.Lines.Count().Should().Be(6);
      for (int i = 0; i < result.Lines.Count(); i++)
      {
        result.Lines.ElementAt(i).LineNumber.Should().Be(i + 1);
        result.Lines.ElementAt(i).TimecodeIn!.Second.Should().Be(i);
        result.Lines.ElementAt(i).TimecodeIn!.Frame.Should().Be(0);
        result.Lines.ElementAt(i).TimecodeOut!.Second.Should().Be(i + 1); // Every out timecode is increased by 1s and 500ms
        result.Lines.ElementAt(i).TimecodeOut!.Frame.Should().Be(12); // 24fps*0.500s = 12 frames
      }
    }

    [Fact]
    public void ConvertSrtStreamToTimecodeScript_ValidInput_Successful()
    {
      // Arrange
      var framerate = Framerate.fps24;
      byte[] byteArray = Encoding.ASCII.GetBytes(EXAMPLE_SRT_STRING);
      MemoryStream stream = new MemoryStream(byteArray);

      // Act
      var result = SubtitleManager.ConvertSrtStreamToTimecodeScript(stream, framerate);

      // Assert
      result.Lines.Count().Should().Be(6);

      result.Lines.ElementAt(0).TimecodeIn!.ToString().Should().Be("00:00:00:00");
      result.Lines.ElementAt(0).TimecodeOut!.ToString().Should().Be("00:00:01:12");
      result.Lines.ElementAt(0).Body.Should().Be(
@"Lorem ipsum dolor sit amet,
consectetur adipiscing elit.");

      result.Lines.ElementAt(1).TimecodeIn!.ToString().Should().Be("00:00:01:00");
      result.Lines.ElementAt(1).TimecodeOut!.ToString().Should().Be("00:00:02:12");
      result.Lines.ElementAt(1).Body.Should().Be(
@"Sed do eiusmod tempor incididunt
ut labore et dolore magna aliqua.");

      result.Lines.ElementAt(2).TimecodeIn!.ToString().Should().Be("00:00:02:00");
      result.Lines.ElementAt(2).TimecodeOut!.ToString().Should().Be("00:00:03:12");
      result.Lines.ElementAt(2).Body.Should().Be(
@"Justo donec enim diam vulputate.");

      result.Lines.ElementAt(3).TimecodeIn!.ToString().Should().Be("00:00:03:00");
      result.Lines.ElementAt(3).TimecodeOut!.ToString().Should().Be("00:00:04:12");
      result.Lines.ElementAt(3).Body.Should().Be(
@"Id cursus metus aliquam eleifend
mi in nulla.");

      result.Lines.ElementAt(4).TimecodeIn!.ToString().Should().Be("00:00:04:00");
      result.Lines.ElementAt(4).TimecodeOut!.ToString().Should().Be("00:00:05:12");
      result.Lines.ElementAt(4).Body.Should().Be(
@"Ornare aenean euismod elementum nisi.
Sit amet mattis vulputate enim.");

      result.Lines.ElementAt(5).TimecodeIn!.ToString().Should().Be("00:00:05:00");
      result.Lines.ElementAt(5).TimecodeOut!.ToString().Should().Be("00:00:06:12");
      result.Lines.ElementAt(5).Body.Should().Be(
@"Fermentum dui faucibus in ornare quam
viverra. Elit eget gravida cum sociis
natoque penatibus et magnis dis.");
    }
  }
}