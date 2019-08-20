using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppJaveriana.Modelos
{
    public class GradeModel : INotifyPropertyChanged
    {
        //Attributes
        private string gradeModelID;

        private string idCourseGrade;

        private string notaGrade;
        private string porcentajeGrade;

        //Constructos
        public GradeModel(String idCourseGradeP,String notaGradeP, String porcentajeGradeP)
        {
            Guid nuevoId = Guid.NewGuid();
            this.gradeModelID = nuevoId.ToString();

            this.idCourseGrade = idCourseGradeP;

            this.notaGrade = notaGradeP;
            this.porcentajeGrade = porcentajeGradeP;
        }

        public GradeModel() { }

        //Getters and Setters
        public String GradeModelID
        {
            get { return gradeModelID; }
            set { gradeModelID = value; OnPropertyChanged(); }
        }
        public String IdCourseGrade
        {
            get { return idCourseGrade; }
            set { idCourseGrade = value; OnPropertyChanged(); }
        }
        public String NotaGrade
        {
            get { return notaGrade; }
            set { notaGrade = value; OnPropertyChanged(); }
        }

        public String PorcentajeGrade
        {
            get { return porcentajeGrade; }
            set { porcentajeGrade = value; OnPropertyChanged(); }
        }

        //Methods
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
