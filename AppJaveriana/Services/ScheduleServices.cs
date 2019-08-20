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
    class ScheduleServices
    {
        DataBase bd;
        public CourseScheduleModel ScheduleExplore { get; set; }

        public UserModel CurrentUser { get; set; }

        public ObservableCollection<CourseScheduleModel> horarios;

        public List<CourseScheduleModel> currentHorarios { get; set; }

        public ScheduleServices()
        {
            bd = App.DB;
            horarios = new ObservableCollection<CourseScheduleModel>();
        }

        public async Task<List<SessionModel>> ObtenerTablaSession()
        {
            return await bd.Set<SessionModel>().ToListAsync();
        }

        public async Task<List<UserModel>> ObtenerTablaUsuario()
        {
            return await bd.Set<UserModel>().ToListAsync();
        }

        public async Task<List<CourseScheduleModel>> ObtenerTablaHorarios()
        {
            return await bd.Set<CourseScheduleModel>().ToListAsync();
        }

        public virtual async Task<ObservableCollection<CourseScheduleModel>> gethorarios()
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
            for(int i = 0; i < CurrentUser.Cursos.Count; i++)
            {
                for(int j = 0; j < CurrentUser.Cursos[i].Horarios.Count;j++)
                {
                    horarios.Add(CurrentUser.Cursos[i].Horarios[j]);
                }
            }
            return horarios;
        }
    }
}
