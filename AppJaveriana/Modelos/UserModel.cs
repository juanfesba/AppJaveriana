using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppJaveriana.Modelos
{
    public class UserModel : INotifyPropertyChanged
    {
        //Atributes
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int userModelID { get; set; }

        private string codigouser;
        private string nombreuser;
        private string apellidouser; 
        private string correouser;

        public List<CourseModel> Cursos { get; set; }

        //Constructors
        public UserModel(String codigouserP, String nombreuserP, String apellidouserP, String correoP)
        {
            //Guid nuevoId = Guid.NewGuid();
            //this.userModelID = nuevoId.ToString();

            this.codigouser = codigouserP;
            this.nombreuser = nombreuserP;
            this.apellidouser = apellidouserP;
            this.correouser = correoP;
        }

        public UserModel() { }


        //Getters and Setters
        /*public String UserModelID
        {
            get { return userModelID; }
            set { userModelID = value; OnPropertyChanged(); }
        }*/
        public String Codigouser
        {
            get { return codigouser; }
            set { codigouser = value; OnPropertyChanged(); }
        }

        public String Nombreuser
        {
            get { return nombreuser; }
            set { nombreuser = value; OnPropertyChanged(); }
        }



        public String Apellidouser
        {
            get { return apellidouser; }
            set { apellidouser = value; OnPropertyChanged(); }
        }

        public String Correouser
        {
            get { return correouser; }
            set { correouser = value; OnPropertyChanged(); }
        }

        //Methods
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}