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
    
    class UserLoginServices
    {
        //¿ESTARA BIEN EL TENER LA SESSION Y EL USUARIO EN ESTE SERVICIO?
        //OTROS: ESTA BIEN TENER MODELOS SIN MODELVIEW DICRECTO?, ESTA BIEN MODEL INSIDE MODEL?

        //Attributes
        private SessionModel currentSession { get; set; }

        private APIService ServicioAPI = new APIService();

        DataBase bd;

        //MAKE IT PUBLIC ATTRIBUTES?


        //Constructors
        public UserLoginServices()
        {
            if (currentSession == null)
                {
                    currentSession = new SessionModel(); //##
                }
            bd = App.DB;
        }

        //DBMethods
        public async Task<List<SessionModel>> ObtenerTablaSession()
        {
            return await bd.Set<SessionModel>().ToListAsync();
        }

        public async Task<List<UserModel>> ObtenerTablaUsuarios()
        {
            return await bd.Set<UserModel>().ToListAsync();
        }

        public virtual async Task<SessionModel> BuscarPorIdSession(int id)
        {
            return await bd.Set<SessionModel>().FindAsync(id);
        }

        public virtual async Task<UserModel> BuscarPorIdUsuario(int id)
        {
            return await bd.Set<UserModel>().FindAsync(id);
        }

        public virtual async Task<SessionModel> AgregarSession(SessionModel dato)
        {
            await bd.Set<SessionModel>().AddAsync(dato);
            await bd.SaveChangesAsync();
            return dato;
        }
        public virtual async Task<UserModel> AgregarUsuario(UserModel dato)
        {
            await bd.Set<UserModel>().AddAsync(dato);
            await bd.SaveChangesAsync();
            return dato;
        }
        public virtual async Task<SessionModel> ActualizarSession(SessionModel dato)
        {
            bd.Set<SessionModel>().Update(dato);
            await bd.SaveChangesAsync();
            return dato;
        }

        public virtual async Task<UserModel> ActualizarUsuario(UserModel dato)
        {
            bd.Set<UserModel>().Update(dato);
            await bd.SaveChangesAsync();
            return dato;
        }

        public virtual async Task<bool> EliminarSession(int id)
        {
            var entity = await BuscarPorIdSession(id);
            bd.Set<SessionModel>().Remove(entity);
            await bd.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> EliminarUsuario(int id)
        {
            var entity = await BuscarPorIdUsuario(id);
            bd.Set<UserModel>().Remove(entity);
            await bd.SaveChangesAsync();
            return true;
        }

        public async Task<JObject> GetApi(String url,String[] header)
        {
            if (header.Length > 0)
            {
                for(int i=0;i< header.Length; i += 2)
                {
                    url += "&" + header[i] + "=" + header[i + 1];
                }
            }
            return await ServicioAPI.testCallSingle(url);
        }

        //Methods
        public virtual async Task<bool> LoginAttempt(SessionModel sessionAttempt)
        {
            //Esto se implementara con la API, si retorna null es porque fue invalido el usuario
            JObject responseAPI = await GetApi("http://replica.javerianacali.edu.co:8100/WSMobile/mobile/v2/Autenticacion/?", new string[] { "usu", sessionAttempt.UserSession, "pass", sessionAttempt.PassSession });

            if (responseAPI["valido"].ToString()=="True")
            {
                

                UserModel usuario = new UserModel(responseAPI["emplid"].ToString(), responseAPI["nombre"].ToString(), responseAPI["apellido"].ToString(), responseAPI["email"].ToString());

                //generar usuario
                List<UserModel> usuarios = await ObtenerTablaUsuarios();
                //coger el i
                bool flag = false;
                int ii=0;
                for(int i = 0; i < usuarios.Count; i++)
                {
                    if (usuarios[i].Codigouser == responseAPI["emplid"].ToString())
                    {
                        flag = true;
                        ii = i;
                        
                        //await EliminarUsuario(usuarios[i].userModelID);
                        break;
                    }
                }
                if (flag)
                {
                    await ActualizarUsuario(usuarios[ii]);
                }
                else
                {
                    await AgregarUsuario(usuario);
                }
                //await AgregarUsuario(usuario);

                sessionAttempt.UserSession = responseAPI["emplid"].ToString();
                sessionAttempt.TokenSession = responseAPI["x-t6519fdd1s5q"].ToString();
                sessionAttempt.LastlogindateSession = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                sessionAttempt.Validated = true;
                List<SessionModel> session = await ObtenerTablaSession();
                if (session.Count > 0)
                {
                    await EliminarSession(session[0].sessionModelID);
                }
                await AgregarSession(sessionAttempt);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}