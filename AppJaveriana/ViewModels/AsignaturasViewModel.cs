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
    public class AsignaturasViewModel : CourseModel
    {
        private CourseServices CourseServices = new CourseServices();
        CourseModel curso;
        private ObservableCollection<CourseModel> cursos;
        bool IsBusy;
        public string promedio { get; set; }

        public AsignaturasViewModel()
        {
            curso = new CourseModel(); //##consult
            cursos = new ObservableCollection<CourseModel>();
        }

        public AsignaturasViewModel(CourseModel selectedCourse)
        {
            curso = selectedCourse;
            loadInfo();

        }

        public void loadInfo()
        {
            NameCourse = curso.NameCourse;
            CodCursoCourse = "Código del curso: "+curso.CodCursoCourse;
            AbsencePercentageCourse = "Inasistencia: "+curso.AbsencePercentageCourse;
            AverageGradeCourse = curso.AverageGradeCourse;
        }

        public ObservableCollection<CourseModel> Cursos
        {
            get { return cursos; }
            set
            {
                cursos = value;
                OnPropertyChanged("Cursos");
            }
        }

        public async Task nombre()
        {
            NameCourse = await CourseServices.getnombre();
            //NameCourse = await CourseServices.GetNamesito(Cursos);
        }

        public async Task loadCourses()
        {
            Cursos = await CourseServices.getcourses();
            AverageGradeCourse = CourseServices.promedio;
        }
    }
}
