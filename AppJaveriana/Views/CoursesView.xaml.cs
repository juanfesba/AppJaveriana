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
    public partial class CoursesView : ContentPage
    {
        AsignaturasViewModel context;
        public CoursesView()
        {
            InitializeComponent();
            context = new AsignaturasViewModel();
            BindingContext = context;
            this.Title = "App Javeriana";
            LvCursos.ItemSelected += LvCursos_ItemSelected;

            Load_Courses();
            //DebugThis();
        }

        protected void LvCursos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CourseModel curso = (CourseModel)e.SelectedItem;
                Navigation.PushAsync(new DetailCourseView(curso));
            }
        }

        async void DebugThis()
        {
            await context.nombre();
        }

        async void Load_Courses()
        {
            await context.loadCourses();
        }

        async void Test(object sender, EventArgs e)
        {
            var imageSender = (ImageButton)sender;

            if (imageSender.Source == ImageSource.FromResource("AppJaveriana.shield.png"))
            {

                imageSender.Source = ImageSource.FromResource("AppJaveriana.shield.png");
            }

            else
            {
                imageSender.Source = ImageSource.FromResource("AppJaveriana.shield2.png");
            }
            //h1.Source= ImageSource.FromResource("AppJaveriana.shield2.png");
        }

        async void navCourses(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursesView());
        }

        async void navSchedule(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScheduleView());
        }

        async void navBook(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksView());
        }

        async void navLaptop(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LaptopView());
        }

        async void navNews(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewsView());
        }

        async void navProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileView());
        }
    }
}