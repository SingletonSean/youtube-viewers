using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.Domain.Queries
{
    public interface IGetAllYouTubeViewersQuery
    {
        Task<IEnumerable<YouTubeViewer>> Execute();
    }
}
