using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppJaveriana.Modelos
{
    public class CourseScheduleModel : INotifyPropertyChanged
    {
        //RECORDAR SI TRANSFORMAR DIA NUMERICO A STRING
        //SE NECESITARA EL ATRIBUTO DE COURSE?

        //Attributes
        private string courseScheduleModelID;

        private string idCourseSchedule;

        private string startHourSchedule;
        private string endHourSchedule;
        private string roomSchedule;
        private string daySchedule;

        public CourseModel Course { get; set; }
        [ForeignKey("CourseModelForeignKey")]
        public int IdCourse { get; set; }

        //Constructos
        public CourseScheduleModel(String idCourseScheduleP,String startHourScheduleP, String endHourScheduleP, String day, String roomScheduleP, CourseModel courseP)
        {
            Guid nuevoId = Guid.NewGuid();
            this.courseScheduleModelID = nuevoId.ToString();

            this.idCourseSchedule = idCourseScheduleP;

            this.startHourSchedule = startHourScheduleP;
            this.endHourSchedule = endHourScheduleP;
            this.daySchedule = day;
            this.roomSchedule = roomScheduleP;

            this.Course = courseP;
        }

        public CourseScheduleModel() { }

        //Getters and Setters
        
        
        public String CourseScheduleModelID
        {
            get { return courseScheduleModelID; }
            set { courseScheduleModelID = value; OnPropertyChanged(); }
        }
        public String IdCourseSchedule
        {
            get { return idCourseSchedule; }
            set { idCourseSchedule = value; OnPropertyChanged(); }
        }
        public String StartHourSchedule
        {
            get { return startHourSchedule; }
            set { startHourSchedule = value; OnPropertyChanged(); }
        }

        public String EndHour
        {
            get { return endHourSchedule; }
            set { endHourSchedule = value; OnPropertyChanged(); }
        }

        public String Day
        {
            get { return daySchedule; }
            set { daySchedule = value; OnPropertyChanged(); }
        }

        public String RoomSchedule
        {
            get { return roomSchedule; }
            set { roomSchedule = value; OnPropertyChanged(); }
        }

        //Methods
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}