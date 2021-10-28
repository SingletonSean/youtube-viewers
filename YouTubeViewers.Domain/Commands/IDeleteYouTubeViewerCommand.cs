using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.Domain.Commands
{
    public interface IDeleteYouTubeViewerCommand
    {
        Task Execute(Guid id);
    }
}
