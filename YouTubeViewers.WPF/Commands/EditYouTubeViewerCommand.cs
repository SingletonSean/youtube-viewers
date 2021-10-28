using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    public class EditYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly EditYouTubeViewerViewModel _editYouTubeViewerViewModel;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditYouTubeViewerCommand(EditYouTubeViewerViewModel editYouTubeViewerViewModel, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
        {
            _editYouTubeViewerViewModel = editYouTubeViewerViewModel;
            _youTubeViewersStore = youTubeViewersStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            YouTubeViewerDetailsFormViewModel formViewModel = _editYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel;

            formViewModel.ErrorMessage = null;
            formViewModel.IsSubmitting = true;

            YouTubeViewer youTubeViewer = new YouTubeViewer(
                _editYouTubeViewerViewModel.YouTubeViewerId,
                formViewModel.Username,
                formViewModel.IsSubscribed,
                formViewModel.IsMember);

            try
            {
                await _youTubeViewersStore.Update(youTubeViewer);

                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                formViewModel.ErrorMessage = "Failed to update YouTube viewer. Please try again later.";
            }
            finally
            {
                formViewModel.IsSubmitting = false;
            }
        }
    }
}
