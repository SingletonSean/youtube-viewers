using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.Domain.Models
{
    public class YouTubeViewer
    {
        public Guid Id { get; }
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }

        public YouTubeViewer(Guid id, string username, bool isSubscribed, bool isMember)
        {
            Id = id;
            Username = username;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }
    }
}
