using AppJaveriana.Modelos;
using AppJaveriana.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppJaveriana.ViewModels
{
    class SessionViewModel : SessionModel
    {
        private UserLoginServices userLoginServices = new UserLoginServices();
        SessionModel session;
        bool IsBusy;

        public SessionViewModel()
        {
            session = new SessionModel(); //##consult
        }

        //Eventos


        public void getInfoFromView()
        {
            session.UserSession = UserSession;
            session.PassSession = PassSession;
        }

        public async Task Refresh()
        {
            List<UserModel> entity = await userLoginServices.ObtenerTablaUsuarios();
            for(int i = 0; i < entity.Count; i++)
            {
                TokenSession += entity[i].Nombreuser;
            }
        }



        //private async Task<int> Login()
        public async Task<bool> Login()
        {
            IsBusy = true;
            getInfoFromView();
            bool response = await userLoginServices.LoginAttempt(session);
            IsBusy = false;
            return response;

            //session.Token = usar servicios ya con API
        }

    }
}
