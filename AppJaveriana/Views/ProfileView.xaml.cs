using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
    public partial class ProfileView : ContentPage
    {
        ProfileViewModel context;
        public ProfileView()
        {
            InitializeComponent();
            context = new ProfileViewModel();
            BindingContext = context;
            this.Title = "App Javeriana";

            Load_User();
        }

        async void Load_User()
        {
            await context.loadUser();
        }

        async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginView());
        }

            async void navCourses(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesView());
        }

        async void navSchedule(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScheduleView());
        }

        async void navLaptop(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LaptopView());
        }

        async void navNews(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewsView());
        }

        async void navBook(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksView());
        }
    }
}