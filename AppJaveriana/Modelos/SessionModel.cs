using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppJaveriana.Modelos
{
    public class SessionModel : INotifyPropertyChanged
    {
        //Atributes

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int sessionModelID { get; set; }

        private string userSession;
        private string passSession;
        private string tokenSession;
        private string lastlogindateSession;
        private bool remembermeSession;
        private bool validated;


        //Constructors
        public SessionModel(String userSessionP, String passSessionP, String tokenSessionP, Boolean rememberbesessionP,Boolean validatedP)
        {

            this.lastlogindateSession = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");

            this.userSession = userSessionP;
            this.passSession = passSessionP;
            this.tokenSession = tokenSessionP;
            this.remembermeSession = rememberbesessionP;
            this.validated = validatedP;
        }

        public SessionModel() {
            this.validated = false;
        }


        //Getters and Setters

        /*public String SessionModelID
        {
            get { return sessionModelID; }
            set { sessionModelID = value; OnPropertyChanged(); }
        }*/
        public String UserSession
        {
            get { return userSession; }
            set { userSession = value; OnPropertyChanged(); }
        }

        public String PassSession
        {
            get { return passSession; }
            set { passSession = value; OnPropertyChanged(); }
        }

        public String TokenSession
        {
            get { return tokenSession; }
            set { tokenSession = value; OnPropertyChanged(); }
        }

        public String LastlogindateSession
        {
            get { return lastlogindateSession; }
            set { lastlogindateSession = value; OnPropertyChanged(); }
        }

        public Boolean RemembermeSession
        {
            get { return remembermeSession; }
            set { remembermeSession = value; OnPropertyChanged(); }
        }

        public Boolean Validated
        {
            get { return validated; }
            set { validated = value; OnPropertyChanged(); }
        }

        //Methods

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}