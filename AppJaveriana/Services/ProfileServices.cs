using AppJaveriana.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using MVVMXamarin.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AppJaveriana.Services
{
    class ProfileServices
    {
        DataBase bd;
        public UserModel CurrentUser { get; set; }

        public ProfileServices()
        {
            bd = App.DB;
        }

        public async Task<List<SessionModel>> ObtenerTablaSession()
        {
            return await bd.Set<SessionModel>().ToListAsync();
        }
        public async Task<List<UserModel>> ObtenerTablaUsuario()
        {
            return await bd.Set<UserModel>().ToListAsync();
        }

        public virtual async Task<UserModel> getLogged()
        {
            SessionModel currentSession = (await ObtenerTablaSession())[0];
            List<UserModel> currentUsers = await ObtenerTablaUsuario();
            for (int i = 0; i < currentUsers.Count; i++)
            {
                if (currentUsers[i].Codigouser == currentSession.UserSession)
                {
                    CurrentUser = currentUsers[i];
                    break;
                }
            }
            return CurrentUser;
        }
    }
}
