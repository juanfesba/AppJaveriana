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
    public partial class NewsView : ContentPage
    {
        NewsViewModel context;
        public NewsView()
        {
            InitializeComponent();
            context = new NewsViewModel();
            BindingContext = context;
            this.Title = "App Javeriana";
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

        async void navBook(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksView());
        }

        async void navProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileView());
        }
    }
}