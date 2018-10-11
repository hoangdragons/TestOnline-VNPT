using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TestOnline.Models;
using TestOnline.Views;

namespace TestOnline.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public User CurrentUsers { get; set; }

        public Command LoginCommand { get; set; }

        public LoginViewModel()
        {
            CurrentUsers = new User();
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        async Task ExecuteLoginCommand()
        {
            CurrentUsers.UserCode = 0;
            CurrentUsers.Name = "Chinh";
            CurrentUsers.Department = "Dev";
            CurrentUsers.Bird = "1/1/2000";
            CurrentUsers.Exams = "Test";
            CurrentUsers.Times = 45;
            CurrentUsers.SemesterCode = 0;
            CurrentUsers.SubjectCode = 0;
            CurrentUsers.bLogin = true;

            if (CurrentUsers.bLogin)
            {
                string mes = "Xin chào " + CurrentUsers.Name;
                await CurrentPage.DisplayAlert("Đăng nhập Thanh công", mes, "OK");
                await Navigation.PushModalAsync(new NavigationPage(new ExamPage()));
            }
            else
            {
                string mes = "Vui long liên hệ quản trị viên!";
                await CurrentPage.DisplayAlert("Đăng nhập thất bại!", mes, "OK");
            }
        }
    }
}
