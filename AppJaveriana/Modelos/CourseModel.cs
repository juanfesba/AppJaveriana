using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppJaveriana.Modelos
{
    public class CourseModel : INotifyPropertyChanged
    {
        //Attributes
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int courseModelID { get; set; }

        //private string idUserCourse;

        private string nameCourse;
        private string codCursoCourse;
        private string profesor;
        private string averageGradeCourse;
        private string absencePercentageCourse;
        private string idClassCourse;
        private string periodoCourse;

        public UserModel User { get; set; }
        [ForeignKey("UserModelForeignKey")]
        public int IdUser { get; set; }

        public List<CourseScheduleModel> Horarios { get; set; }

        //Constructors
        //public CourseModel(String idUserCourseP,String nameCourseP, String codCursoCourseP,String averageGradeCourseP, String absencePercentageCourseP, String idClassCourseP,String periodoCourseP)
        public CourseModel(String nameCourseP, String codCursoCourseP,String profesorP,String averageGradeCourseP, String absencePercentageCourseP, String idClassCourseP,String periodoCourseP,UserModel UserP)
        {
            /*Guid nuevoId = Guid.NewGuid();
            this.courseModelID = nuevoId.ToString();*/

            //this.idUserCourse = idUserCourseP;

            this.nameCourse = nameCourseP;
            this.codCursoCourse = codCursoCourseP;



            if (averageGradeCourseP.Substring(0, 1) == ".")
            {
                averageGradeCourseP="0"+averageGradeCourseP.Substring(0, 3);
            }
            else
            {
                if(averageGradeCourseP.Substring(0, 1) != "0")
                {
                    averageGradeCourseP = averageGradeCourseP.Substring(0, 4);
                }
            }
            this.averageGradeCourse = averageGradeCourseP;

            if (absencePercentageCourseP.Substring(0, 1) == ".")
            {
                absencePercentageCourseP = "0" + absencePercentageCourseP.Substring(0, 3)+"%";
            }
            else
            {
                if (absencePercentageCourseP.Substring(0, 1) != "0")
                {
                    absencePercentageCourseP = absencePercentageCourseP.Substring(0, 4)+"%";
                }
            }
            this.profesor = profesorP;
            this.absencePercentageCourse = absencePercentageCourseP;
            this.idClassCourse = idClassCourseP;
            this.periodoCourse = periodoCourseP;
            this.User = UserP;
        }

        public CourseModel() { }

        //Getters and Setters

        /*public String CourseModelID
        {
            get { return courseModelID; }
            set { courseModelID = value; }
        }*/
        /*public String IdUserCourse
        {
            get { return idUserCourse; }
            set { idUserCourse = value; OnPropertyChanged(); }
        }*/
        public String NameCourse
        {
            get { return nameCourse; }
            set { nameCourse = value; OnPropertyChanged(); }
        }
        public String CodCursoCourse
        {
            get { return codCursoCourse; }
            set { codCursoCourse = value; OnPropertyChanged(); }

        }

        public String Profesor
        {
            get { return profesor; }
            set { profesor = value; OnPropertyChanged(); }

        }

        public String AverageGradeCourse
        {
            get { return averageGradeCourse; }
            set { averageGradeCourse = value; OnPropertyChanged(); }
        }

        public String AbsencePercentageCourse
        {
            get { return absencePercentageCourse; }
            set { absencePercentageCourse = value; OnPropertyChanged(); }
        }

        public String IdClassCourse
        {
            get { return idClassCourse; }
            set { idClassCourse = value; OnPropertyChanged(); }
        }

        public String PeriodoCourse
        {
            get { return periodoCourse; }
            set { periodoCourse = value; OnPropertyChanged(); }
        }


        //Methods

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}