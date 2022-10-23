using DialogueList.Interfaces;

using DotnetTimecode.Enums;

namespace DialogueList
{
  /// <summary>
  /// Represents a complete dialogue script.
  /// </summary>
	public class Script
  {
    /// <summary>
    /// Represents the script title.
    /// </summary>
    public string Title { get; set; } = "";
    /// <summary>
    /// Represents the script language.
    /// </summary>
    public string Language { get; set; } = "";
    /// <summary>
    /// Represents the general description of the script.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// Represents the script lines.
    /// </summary>
    public List<IScriptLine> Lines { get; } = new List<IScriptLine>();
    /// <summary>
    /// Adds hours to all script lines.
    /// </summary>
    /// <param name="hours">The number of hours to add to all script lines.</param>
    public void AddHours(int hours)
    {
      throw new NotImplementedException();
    }
    /// <summary>
    /// Adds minutes to all script lines.
    /// </summary>
    /// <param name="minutes">The number of minutes to add to all script lines</param>
    public void AddMinutes(int minutes)
    {
      throw new NotImplementedException();
    }
    /// <summary>
    /// Adds seconds to all script lines.
    /// </summary>
    /// <param name="seconds">The number of seconds to add to all script lines</param>
    public void AddSeconds(int seconds)
    {
      throw new NotImplementedException();
    }
    /// <summary>
    /// Adds frames to all script lines.
    /// </summary>
    /// <param name="frames">The number of frames to add to all script lines</param>
    public void AddFrames(int frames)
    {
      throw new NotImplementedException();
    }
    /// <summary>
    /// Changes the scripts framerate.
    /// </summary>
    /// <param name="framerate">The script target framerate.</param>
    /// <param name="convertExistingTimecodes">Determines if all existing timecodes should be converted to the target framerate. 
    /// <br/> True set as default behaviour.</param>
    public void ChangeFramerate(Framerate framerate, bool convertExistingTimecodes = true)
    {
      throw new NotImplementedException();
    }

    // TODO: Fix line classes. Must insert a new line and update the line numbers of all other lines.
    public void InsertLine()
    {
      throw new NotImplementedException();
    }
    /// <summary>
    /// Removes a line from the script.
    /// </summary>
    /// <param name="lineNumber">The line number which should be removed.</param>
    public void RemoveLine(int lineNumber)
    {
      throw new NotImplementedException();
    }
  }
}
