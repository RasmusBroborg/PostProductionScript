using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DotnetTimecode;

namespace PostProductionScript.Interfaces.Scripts
{
  public interface ITvSeriesScript
  {
    /// <summary>
    /// Represents the episode title.
    /// </summary>
    public string EpisodeTitle { get; set; }

    /// <summary>
    /// Represents the season number.
    /// </summary>
    public int? SeasonNumber { get; set; }

    /// <summary>
    /// Represents the episode number.
    /// </summary>
    public int? EpisodeNumber { get; set; }

    /// <summary>
    /// Represents the episode runtime.
    /// </summary>
    public Timecode? RunTime { get; set; }
  }
}