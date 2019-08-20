using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppJaveriana.Modelos
{
    public class BookModel : INotifyPropertyChanged
    {
        //Attributes
        private String bookModelID;

        private string idcourseBook;

        private string codigoBook;
        private string nameBook;
        private string pedidoDateBook;
        private string returningDateBook;
        private string ownerBook;
        private string multaBook;

        //Constructors
        public BookModel(String idCourseBookP,String idcourseBookP,String codigoBookP,String nameBookP, String pedidoDateBookP,String returningDateBookP,String ownerBookP,String multaBookP)
        {
            Guid nuevoId = Guid.NewGuid();
            this.bookModelID = nuevoId.ToString();

            this.idcourseBook = idcourseBookP;

            this.codigoBook = codigoBookP;
            this.nameBook = nameBookP;
            this.pedidoDateBook = pedidoDateBookP;
            this.returningDateBook = returningDateBookP;
            this.ownerBook = ownerBookP;
            this.multaBook = multaBookP;
        }

        public BookModel() { }

        //Getters and Setters
        public String BookModelID
        {
            get { return bookModelID; }
            set { bookModelID = value; }
        }
        public String IdcourseBook
        {
            get { return idcourseBook; }
            set { idcourseBook = value; }
        }
        public String CodigoBook
        {
            get { return codigoBook; }
            set { codigoBook = value; }
        }
        public String NameBook
        {
            get { return nameBook; }
            set { nameBook = value; }
        }

        public String PedidoDateBook
        {
            get { return pedidoDateBook; }
            set { pedidoDateBook = value; }
        }

        public String ReturningDateBook
        {
            get { return returningDateBook; }
            set { returningDateBook = value; }
        }

        public String OwnerBook
        {
            get { return ownerBook; }
            set { ownerBook = value; }
        }

        public String MultaBook
        {
            get { return multaBook; }
            set { multaBook = value; }
        }


        //Methods

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
