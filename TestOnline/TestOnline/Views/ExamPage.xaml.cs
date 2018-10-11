using System;
using System.Collections.Generic;

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
            viewModel.CurrentPage = this;
        }
    }
}
