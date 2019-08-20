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
    public partial class ScheduleView : ContentPage
    {
        ScheduleViewModel context;

        public ScheduleView()
        {
            InitializeComponent();
            context = new ScheduleViewModel();
            BindingContext = context;
            this.Title = "App Javeriana";

            Load_Horarios();
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

        async void getRoom(object sender, EventArgs e)
        {
            string data = ((ImageButton)sender).BindingContext as string;
            string x = data.Substring(0, 2);
            string y = data.Substring(3, 2);
            int xINT = Convert.ToInt32(x);
            int yINT = Convert.ToInt32(y);
            xINT -= 1;
            yINT -= 1;

            if (context.banderas[yINT * 15 + xINT] == 1)
            {
                prueba.Text = "Clase: " + context.clases[yINT * 15 + xINT] + "\nSalón: " +context.salones[yINT * 15 + xINT];
            }

            /*string debugx = xINT.ToString();
            string debugy = yINT.ToString();
            prueba.Text = debugx + "x" + debugy;*/



            //await Navigation.PushAsync(new ProfileView());
        }

        async void Load_Horarios()
        {
            await context.loadSchedules();
            await context.feedSchedules();
            //prueba.Text = context.debug;
            x1y1.Source = ImageSource.FromResource(context.images[context.banderas[0]]);
            x2y1.Source = ImageSource.FromResource(context.images[context.banderas[1]]);
            x3y1.Source = ImageSource.FromResource(context.images[context.banderas[2]]);
            x4y1.Source = ImageSource.FromResource(context.images[context.banderas[3]]);
            x5y1.Source = ImageSource.FromResource(context.images[context.banderas[4]]);
            x6y1.Source = ImageSource.FromResource(context.images[context.banderas[5]]);
            x7y1.Source = ImageSource.FromResource(context.images[context.banderas[6]]);
            x8y1.Source = ImageSource.FromResource(context.images[context.banderas[7]]);
            x9y1.Source = ImageSource.FromResource(context.images[context.banderas[8]]);
            x10y1.Source = ImageSource.FromResource(context.images[context.banderas[9]]);
            x11y1.Source = ImageSource.FromResource(context.images[context.banderas[10]]);
            x12y1.Source = ImageSource.FromResource(context.images[context.banderas[11]]);
            x13y1.Source = ImageSource.FromResource(context.images[context.banderas[12]]);
            x14y1.Source = ImageSource.FromResource(context.images[context.banderas[13]]);
            x15y1.Source = ImageSource.FromResource(context.images[context.banderas[14]]);

            x1y2.Source = ImageSource.FromResource(context.images[context.banderas[15]]);
            x2y2.Source = ImageSource.FromResource(context.images[context.banderas[16]]);
            x3y2.Source = ImageSource.FromResource(context.images[context.banderas[17]]);
            x4y2.Source = ImageSource.FromResource(context.images[context.banderas[18]]);
            x5y2.Source = ImageSource.FromResource(context.images[context.banderas[19]]);
            x6y2.Source = ImageSource.FromResource(context.images[context.banderas[20]]);
            x7y2.Source = ImageSource.FromResource(context.images[context.banderas[21]]);
            x8y2.Source = ImageSource.FromResource(context.images[context.banderas[22]]);
            x9y2.Source = ImageSource.FromResource(context.images[context.banderas[23]]);
            x10y2.Source = ImageSource.FromResource(context.images[context.banderas[24]]);
            x11y2.Source = ImageSource.FromResource(context.images[context.banderas[25]]);
            x12y2.Source = ImageSource.FromResource(context.images[context.banderas[26]]);
            x13y2.Source = ImageSource.FromResource(context.images[context.banderas[27]]);
            x14y2.Source = ImageSource.FromResource(context.images[context.banderas[28]]);
            x15y2.Source = ImageSource.FromResource(context.images[context.banderas[29]]);

            x1y3.Source = ImageSource.FromResource(context.images[context.banderas[30]]);
            x2y3.Source = ImageSource.FromResource(context.images[context.banderas[31]]);
            x3y3.Source = ImageSource.FromResource(context.images[context.banderas[32]]);
            x4y3.Source = ImageSource.FromResource(context.images[context.banderas[33]]);
            x5y3.Source = ImageSource.FromResource(context.images[context.banderas[34]]);
            x6y3.Source = ImageSource.FromResource(context.images[context.banderas[35]]);
            x7y3.Source = ImageSource.FromResource(context.images[context.banderas[36]]);
            x8y3.Source = ImageSource.FromResource(context.images[context.banderas[37]]);
            x9y3.Source = ImageSource.FromResource(context.images[context.banderas[38]]);
            x10y3.Source = ImageSource.FromResource(context.images[context.banderas[39]]);
            x11y3.Source = ImageSource.FromResource(context.images[context.banderas[40]]);
            x12y3.Source = ImageSource.FromResource(context.images[context.banderas[41]]);
            x13y3.Source = ImageSource.FromResource(context.images[context.banderas[42]]);
            x14y3.Source = ImageSource.FromResource(context.images[context.banderas[43]]);
            x15y3.Source = ImageSource.FromResource(context.images[context.banderas[44]]);

            x1y4.Source = ImageSource.FromResource(context.images[context.banderas[45]]);
            x2y4.Source = ImageSource.FromResource(context.images[context.banderas[46]]);
            x3y4.Source = ImageSource.FromResource(context.images[context.banderas[47]]);
            x4y4.Source = ImageSource.FromResource(context.images[context.banderas[48]]);
            x5y4.Source = ImageSource.FromResource(context.images[context.banderas[49]]);
            x6y4.Source = ImageSource.FromResource(context.images[context.banderas[50]]);
            x7y4.Source = ImageSource.FromResource(context.images[context.banderas[51]]);
            x8y4.Source = ImageSource.FromResource(context.images[context.banderas[52]]);
            x9y4.Source = ImageSource.FromResource(context.images[context.banderas[53]]);
            x10y4.Source = ImageSource.FromResource(context.images[context.banderas[54]]);
            x11y4.Source = ImageSource.FromResource(context.images[context.banderas[55]]);
            x12y4.Source = ImageSource.FromResource(context.images[context.banderas[56]]);
            x13y4.Source = ImageSource.FromResource(context.images[context.banderas[57]]);
            x14y4.Source = ImageSource.FromResource(context.images[context.banderas[58]]);
            x15y4.Source = ImageSource.FromResource(context.images[context.banderas[59]]);

            x1y5.Source = ImageSource.FromResource(context.images[context.banderas[60]]);
            x2y5.Source = ImageSource.FromResource(context.images[context.banderas[61]]);
            x3y5.Source = ImageSource.FromResource(context.images[context.banderas[62]]);
            x4y5.Source = ImageSource.FromResource(context.images[context.banderas[63]]);
            x5y5.Source = ImageSource.FromResource(context.images[context.banderas[64]]);
            x6y5.Source = ImageSource.FromResource(context.images[context.banderas[65]]);
            x7y5.Source = ImageSource.FromResource(context.images[context.banderas[66]]);
            x8y5.Source = ImageSource.FromResource(context.images[context.banderas[67]]);
            x9y5.Source = ImageSource.FromResource(context.images[context.banderas[68]]);
            x10y5.Source = ImageSource.FromResource(context.images[context.banderas[69]]);
            x11y5.Source = ImageSource.FromResource(context.images[context.banderas[70]]);
            x12y5.Source = ImageSource.FromResource(context.images[context.banderas[71]]);
            x13y5.Source = ImageSource.FromResource(context.images[context.banderas[72]]);
            x14y5.Source = ImageSource.FromResource(context.images[context.banderas[73]]);
            x15y5.Source = ImageSource.FromResource(context.images[context.banderas[74]]);

            x1y6.Source = ImageSource.FromResource(context.images[context.banderas[75]]);
            x2y6.Source = ImageSource.FromResource(context.images[context.banderas[76]]);
            x3y6.Source = ImageSource.FromResource(context.images[context.banderas[77]]);
            x4y6.Source = ImageSource.FromResource(context.images[context.banderas[78]]);
            x5y6.Source = ImageSource.FromResource(context.images[context.banderas[79]]);
            x6y6.Source = ImageSource.FromResource(context.images[context.banderas[80]]);
            x7y6.Source = ImageSource.FromResource(context.images[context.banderas[81]]);
            x8y6.Source = ImageSource.FromResource(context.images[context.banderas[82]]);
            x9y6.Source = ImageSource.FromResource(context.images[context.banderas[83]]);
            x10y6.Source = ImageSource.FromResource(context.images[context.banderas[84]]);
            x11y6.Source = ImageSource.FromResource(context.images[context.banderas[85]]);
            x12y6.Source = ImageSource.FromResource(context.images[context.banderas[86]]);
            x13y6.Source = ImageSource.FromResource(context.images[context.banderas[87]]);
            x14y6.Source = ImageSource.FromResource(context.images[context.banderas[88]]);
            x15y6.Source = ImageSource.FromResource(context.images[context.banderas[89]]);
        }
    }
}