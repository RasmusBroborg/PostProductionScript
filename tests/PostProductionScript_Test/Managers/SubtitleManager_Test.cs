using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostProductionScript.Managers;

using DotnetTimecode;
using DotnetTimecode.Enums;

using PostProductionScript.Models.LineModels;

using Xunit;
using FluentAssertions;

namespace PostProductionScript_Test.Managers
{
  public class SubtitleManager_Test
  {
    [Theory] // Arrange
    [InlineData(@$"
1
00:00:01,500 --> 00:00:07,500
Lorem ipsum dolor sit amet, 
consectetur adipiscing elit.

2
00:00:08,500 --> 00:00:10,000
Sed do eiusmod tempor incididunt
ut labore et dolore magna aliqua. 

3
00:00:10,000 --> 00:00:13,500
Justo donec enim diam vulputate. 

4
00:00:13,500 --> 00:00:17,000
Id cursus metus aliquam eleifend 
mi in nulla.

5
00:00:17,000 --> 00:00:21,000
Ornare aenean euismod elementum nisi. 
Sit amet mattis vulputate enim.

6
00:00:21,000 --> 00:00:26,000
Fermentum dui faucibus in ornare quam
viverra. Elit eget gravida cum sociis 
natoque penatibus et magnis dis.
", Framerate.fps25
      )]
    public void ConvertSrtToAsBroadcastScript_ValidInputs_Successful(string validSrt, Framerate framerate)
    {
      // Act
      var result = SubtitleManager.ConvertSrtToAsBroadcastScript(validSrt, framerate);

      // Assert
      result.Lines.Count().Should().Be(6);

      for (int i = 0; i < result.Lines.Count(); i++)
      {
        result.Lines.ElementAt(i).LineNumber.Should().Be(i+1);
      }
    }
  }
}
