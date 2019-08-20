using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppJaveriana.Modelos
{
    public class NoticiaModel : INotifyPropertyChanged
    {
        private string noticiaModelID;

        private string nidNoticia;
        private string pathNoticia;
        private string tituloNoticia;
        private string fechaPublicNoticia;
        private string typeNoticia;
        private string bodyNoticia;
        private string imageNoticia;

        //Constructors
        public NoticiaModel(String idCourseNoticiaP, String nidNoticiaP, String pathNoticiaP, String tituloNoticiaP, String fechaPublicNoticiaP, String typeNoticiaP, String bodyNoticiaP, String imageNoticiaP)
        {
            Guid nuevoId = Guid.NewGuid();
            this.noticiaModelID = nuevoId.ToString();

            this.nidNoticia = nidNoticiaP;
            this.pathNoticia = pathNoticiaP;
            this.tituloNoticia = tituloNoticiaP;
            this.fechaPublicNoticia = fechaPublicNoticiaP;
            this.typeNoticia = typeNoticiaP;
            this.bodyNoticia = bodyNoticiaP;
            this.imageNoticia = imageNoticiaP;
        }

        public NoticiaModel() { }

        //Getters and Setters
        public String NoticiaModelID
        {
            get { return noticiaModelID; }
            set { noticiaModelID = value; OnPropertyChanged(); }
        }
        public String NidNoticia
        {
            get { return nidNoticia; }
            set { nidNoticia = value; OnPropertyChanged(); }
        }
        public String PathNoticia
        {
            get { return pathNoticia; }
            set { pathNoticia = value; OnPropertyChanged(); }
        }
        public String TituloNoticia
        {
            get { return tituloNoticia; }
            set { tituloNoticia = value; OnPropertyChanged(); }
        }

        public String FechaPublicNoticia
        {
            get { return fechaPublicNoticia; }
            set { fechaPublicNoticia = value; OnPropertyChanged(); }
        }

        public String TypeNoticia
        {
            get { return typeNoticia; }
            set { typeNoticia = value; OnPropertyChanged(); }
        }

        public String BodyNoticia
        {
            get { return bodyNoticia; }
            set { bodyNoticia = value; OnPropertyChanged(); }
        }

        public String ImageNoticia
        {
            get { return imageNoticia; }
            set { imageNoticia = value; OnPropertyChanged(); }
        }


        //Methods

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
