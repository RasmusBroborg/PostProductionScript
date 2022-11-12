using System.Linq;
using PostProductionScript.Managers;
using DotnetTimecode.Enums;

using Xunit;
using FluentAssertions;

namespace PostProductionScript_Test.Managers
{
  public class SubtitleManager_Test
  {
    [Fact]
    public void ConvertSrtToAsBroadcastScript_ValidInputs_Successful()
    {
      // Arrange
      var framerate = Framerate.fps24;
      var validSrt = @$"
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

      // Act
      var result = SubtitleManager.ConvertSrtToAsBroadcastScript(validSrt, framerate);

      // Assert
      result.Lines.Count().Should().Be(6);

      for (int i = 0; i < result.Lines.Count(); i++)
      {
        result.Lines.ElementAt(i).LineNumber.Should().Be(i+1);
        result.Lines.ElementAt(i).TimecodeIn!.Second.Should().Be(i);
        result.Lines.ElementAt(i).TimecodeIn!.Frame.Should().Be(0);
        result.Lines.ElementAt(i).TimecodeOut!.Second.Should().Be(i+1);
        result.Lines.ElementAt(i).TimecodeOut!.Frame.Should().Be(12); // 24fps*0.500
      }
    }
  }
}
