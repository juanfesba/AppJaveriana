using AppJaveriana.Modelos;
using AppJaveriana.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppJaveriana.ViewModels
{
    public class ScheduleViewModel : CourseScheduleModel
    {
        private ObservableCollection<CourseScheduleModel> horarios;
        private ScheduleServices ScheduleService = new ScheduleServices();
        public string[] images { get; set; }
        public int[] banderas { get; set; }

        public string[] salones { get; set; }

        public string debug { get; set; }

        public string[] clases { get; set; }

        public ScheduleViewModel()
        {
            images = new string[2];
            images[0] = "AppJaveriana.white.png";
            images[1] = "AppJaveriana.yellow.png";
            banderas = new int[90];
            salones = new string[90];
            clases = new string[90];
            for(int i = 0; i < 90; i++)
            {
                banderas[i] = 0;
            }
            debug = "";
        }


        public ObservableCollection<CourseScheduleModel> Horarios
        {
            get { return horarios; }
            set
            {
                horarios = value;
                OnPropertyChanged("Horarios");
            }
        }

        public async Task loadSchedules()
        {
            Horarios = await ScheduleService.gethorarios();
        }

        public async Task feedSchedules()
        {
            String clase;
            String hora;
            String salon;
            String start;
            String end;
            String day;
            int startINT;
            int endINT;
            int dayINT;

            int intento = 20;
            foreach (var hor in Horarios)
            {
                clase = hor.Course.NameCourse;
                hora = hor.StartHourSchedule;
                salon = hor.RoomSchedule;
                start = hora.Substring(0, 2);
                end = hora.Substring(8, 2);
                startINT = Convert.ToInt32(start);
                endINT = Convert.ToInt32(end);
                startINT -= 8;
                endINT -= 8;


                day = hor.Day;
                dayINT = Convert.ToInt32(day);
                dayINT = Math.Min(dayINT, 6);
                dayINT -= 1;

                //debug = debug + endINT.ToString() + "#" + startINT + "#";
                for (int i = endINT; i > startINT; i--)
                {
                    clases[15 * dayINT + i] = clase;
                    banderas[15 * dayINT+i] = 1;
                    salones[15 * dayINT + i] = salon;
                    debug += "#";
                    intento = intento - 1;
                    if (intento == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
