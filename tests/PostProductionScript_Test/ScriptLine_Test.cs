using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotnetTimecode;

using FluentAssertions;

using PostProductionScript;

using Xunit;

namespace PostProductionScript_Test
{
	public class ScriptLine_Test
	{
    [Fact]
    public void OffsetHours_ValidInputs_ExpectedBehaviour()
    {
      // Arrange
      var scriptLine = new DialogueLine();

      scriptLine.TimecodeIn = new Timecode("10:00:00:00", DotnetTimecode.Enums.Framerate.fps23_976);
      scriptLine.TimecodeOut = new Timecode("10:00:03:00", DotnetTimecode.Enums.Framerate.fps23_976);

      // Act
      scriptLine.OffsetHours(1);

      // Assert
      scriptLine.TimecodeIn.ToString().Should().Be("11:00:00:00");
      scriptLine.TimecodeOut.ToString().Should().Be("11:00:03:00");
    }
    [Fact]
    public void OffsetMinutes_ValidInput_ExpectedBehaviour()
    {
      // Arrange
      var scriptLine = new DialogueLine();
      scriptLine.TimecodeIn = new Timecode("10:00:00:00", DotnetTimecode.Enums.Framerate.fps23_976);
      scriptLine.TimecodeOut = new Timecode("10:03:00:00", DotnetTimecode.Enums.Framerate.fps23_976);

      //Act
      scriptLine.OffsetMinutes(1);

      //Assert
      scriptLine.TimecodeIn.ToString().Should().Be("10:01:00:00");
      scriptLine.TimecodeOut.ToString().Should().Be("10:04:00:00");
    }
    [Fact]
    public void OffsetSeconds_ValidInput_ExpectedBehaviour()
    {
      //Arrange
      var scriptLine = new DialogueLine();
      scriptLine.TimecodeIn = new Timecode("10:00:00:00", DotnetTimecode.Enums.Framerate.fps23_976);
      scriptLine.TimecodeOut = new Timecode("10:00:03:00", DotnetTimecode.Enums.Framerate.fps23_976);

      //Act
      scriptLine.OffsetSeconds(1);

      //Assert
      scriptLine.TimecodeIn.ToString().Should().Be("10:00:01:00");
      scriptLine.TimecodeOut.ToString().Should().Be("10:00:04:00");
    }
    [Fact]
    public void OffsetFrames_ValidInput_ExpectedBehaviour()
    {
      //Arrange
      var scriptLine = new DialogueLine();
      scriptLine.TimecodeIn = new Timecode("10:00:00:00", DotnetTimecode.Enums.Framerate.fps23_976);
      scriptLine.TimecodeOut = new Timecode("10:00:00:03", DotnetTimecode.Enums.Framerate.fps23_976);

      //Act
      scriptLine.OffsetFrames(1);

      //Assert
      scriptLine.TimecodeIn.ToString().Should().Be("10:00:00:01");
      scriptLine.TimecodeOut.ToString().Should().Be("10:00:00:04");
    }
  }
}