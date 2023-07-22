﻿using System;
using System.Windows.Input;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
  public class EditYouTubeViewerViewModel : ViewModelBase
  {
    public Guid YouTubeViewerId { get; }

    public YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; }

    public EditYouTubeViewerViewModel(YouTubeViewer youTubeViewer, YouTubeViewersStore youTubeViewersStore, ModalNavigationStore modalNavigationStore)
    {
      YouTubeViewerId = youTubeViewer.Id;

      ICommand submitCommand = new EditYouTubeViewerCommand(this, youTubeViewersStore, modalNavigationStore);
      ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
      YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel(submitCommand, cancelCommand)
      {
        Username = youTubeViewer.Username,
        IsSubscribed = youTubeViewer.IsSubscribed,
        IsMember = youTubeViewer.IsMember,
      };
    }
  }
}
