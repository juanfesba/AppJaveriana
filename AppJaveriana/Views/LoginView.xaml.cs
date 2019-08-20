using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppJaveriana.Modelos;
using AppJaveriana.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppJaveriana.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        SessionViewModel context;
        public LoginView()
        {
            InitializeComponent();
            context = new SessionViewModel();
            BindingContext = context;
            this.Title = "App Javeriana";
            var existingPages = Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                Navigation.RemovePage(page);
            }
        }
        /*
        public void infsdsfas()
        {
            context.userLoginServices
                if
        }*/
        //await contentPage.Navigation.PushAsync(new CoursesView());
        //Task RemoveLastFromBackStackAsync();

        async void Login_Clicked(object sender,EventArgs e)
        {
            if (await context.Login())
            {
                //await context.Refresh();
                await Navigation.PushAsync(new CoursesView());
                /*await Navigation.PopToRootAsync();*/
                /*var existingPages = Navigation.NavigationStack.ToList();
                foreach (var page in existingPages)
                {
                    Navigation.RemovePage(page);
                }*/
            }
            else
            {
                await DisplayAlert("Error", "Usuario o Contraseña Incorrectos!", "OK");
            }
        }

        /*async void ChangeImage(object sender, EventArgs e)
        {
            var imageSender = (ImageButton)sender;

            if (imageSender.Source == (ImageSource)"{local:ImageResource AppJaveriana.colombia.jpg}")
            {
                
                imageSender.Source = "{local:ImageResource AppJaveriana.logojaveriana.jpg}";
            }

            else
            {
                imageSender.Source = "{local:ImageResource AppJaveriana.colombia.jpg}";
            }
        }*/
    }
}