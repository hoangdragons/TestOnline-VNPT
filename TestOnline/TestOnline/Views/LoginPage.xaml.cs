﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TestOnline.ViewModels;

namespace TestOnline.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        LoginViewModel viewModel; 
        public LoginPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new LoginViewModel();
            viewModel.CurrentPage = this ;
        }
	}
}