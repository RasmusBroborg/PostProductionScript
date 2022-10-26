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
      var scriptLine = new ScriptLine();
      scriptLine.TimecodeIn = new Timecode("10:00:00:00", DotnetTimecode.Enums.Framerate.fps23_976);
      scriptLine.TimecodeOut = new Timecode("10:00:03:00", DotnetTimecode.Enums.Framerate.fps23_976);

      // Act
      scriptLine.OffsetHours(1);

      // Assert
      scriptLine.TimecodeIn.ToString().Should().Be("11:00:00:00");
      scriptLine.TimecodeOut.ToString().Should().Be("11:00:03:00");
    }
  }
}
