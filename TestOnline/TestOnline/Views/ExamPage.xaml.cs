using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System;
using Xamarin.Forms;
using TestOnline.ViewModels;

namespace TestOnline.Views
{
    public partial class ExamPage : ContentPage
    {
        ExamViewModel viewModel;

        public ExamPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ExamViewModel();
            viewModel.ListView_Radio = this.ListView_Radio;
            viewModel.CurrentPage = this;
            viewModel.Navigation = this.Navigation;
            viewModel.Initialize();
        }

        public async void Handle_Clicked(object sender, EventArgs e)
        {
            viewModel.Handle_Clicked();
        }
        /// <summary>
        /// Handles the item tapped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as RadioOption;

            if (item == null)
                return;

            viewModel.Handle_ItemTapped(item);
        }

        public void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Clear selected item so we don't have a lingering highlight of the last
            // item tapped
            ListView_Radio.SelectedItem = null;
        }

    }
}
