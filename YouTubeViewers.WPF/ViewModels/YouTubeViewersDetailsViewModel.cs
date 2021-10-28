using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersDetailsViewModel : ViewModelBase 
    {
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

        private YouTubeViewer SelectedYouTubeViewer => _selectedYouTubeViewerStore.SelectedYouTubeViewer;

        public bool HasSelectedYouTubeViewer => SelectedYouTubeViewer != null;
        public string Username => SelectedYouTubeViewer?.Username ?? "Unknown";
        public string IsSubscribedDisplay => (SelectedYouTubeViewer?.IsSubscribed ?? false) ? "Yes" : "No";
        public string IsMemberDisplay => (SelectedYouTubeViewer?.IsMember ?? false) ? "Yes" : "No";

        public YouTubeViewersDetailsViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;

            _selectedYouTubeViewerStore.SelectedYouTubeViewerChanged += SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged;
        }

        protected override void Dispose()
        {
            _selectedYouTubeViewerStore.SelectedYouTubeViewerChanged -= SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged;

            base.Dispose();
        }

        private void SelectedYouTubeViewerStore_SelectedYouTubeViewerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedYouTubeViewer));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDisplay));
        }
    }
}
