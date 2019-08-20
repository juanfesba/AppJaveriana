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
    class CourseServices
    {
        private APIService ServicioAPI = new APIService();
        DataBase bd;
        public CourseModel CourseExplore { get; set; }
        public CourseScheduleModel CourseScheduleExplore { get; set; }
        public UserModel CurrentUser { get; set; }

        public ObservableCollection<CourseModel> cursos;

        public List<CourseModel> currentCourses { get; set; }

        public string promedio { get; set; }
        public float promedioFLOAT { get; set; }

        public CourseServices()
        {
            bd = App.DB;
            cursos = new ObservableCollection<CourseModel>();
            promedioFLOAT = 0;
        }

        //Métodos

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

        public async Task<List<CourseModel>> ObtenerTablaCursos()
        {
            return await bd.Set<CourseModel>().ToListAsync();
        }

        public virtual async Task<UserModel> AgregarUsuario(UserModel dato)
        {
            await bd.Set<UserModel>().AddAsync(dato);
            await bd.SaveChangesAsync();
            return dato;
        }

        public virtual async Task<CourseModel> AgregarCurso(CourseModel dato)
        {
            await bd.Set<CourseModel>().AddAsync(dato);
            await bd.SaveChangesAsync();
            return dato;
        }

        public virtual async Task<CourseScheduleModel> AgregarHorario(CourseScheduleModel dato)
        {
            await bd.Set<CourseScheduleModel>().AddAsync(dato);
            await bd.SaveChangesAsync();
            return dato;
        }

        public virtual async Task<CourseModel> ActualizarCurso(CourseModel dato)
        {
            bd.Set<CourseModel>().Update(dato);
            await bd.SaveChangesAsync();
            return dato;
        }

        public virtual async Task<String> getnombre()
        {
            SessionModel currentSession = (await ObtenerTablaSession())[0];
            JArray response = await ServicioAPI.testCallHeaderArray("http://replica.javerianacali.edu.co:8100/WSMobile/mobile/v2/asignaturas", currentSession.TokenSession);

            List<UserModel> currentUsers = await ObtenerTablaUsuario();
            for(int i = 0; i < currentUsers.Count; i++)
            {
                if (currentUsers[i].Codigouser == currentSession.UserSession)
                {
                    CurrentUser = currentUsers[i];
                    break;
                }
            }
            currentCourses = await ObtenerTablaCursos();
            bool flag;
            for (int i = 0; i < response.Count; i++)
            {
                CourseExplore = new CourseModel(response[i]["nom"].ToString(), response[i]["crse_id"].ToString(), response[i]["horario"][0]["doc"].ToString(), response[i]["notp"].ToString(), response[i]["porci"].ToString(), response[i]["class_section"].ToString(), response[i]["peri"].ToString(),CurrentUser);
                flag = false;
                for(int j = 0; j < currentCourses.Count; j++)
                {
                    if (response[i]["crse_id"].ToString()==currentCourses[j].CodCursoCourse && currentCourses[j].User.userModelID==CurrentUser.userModelID)
                    {
                        await ActualizarCurso(currentCourses[j]);
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    await AgregarCurso(CourseExplore);
                    //CourseScheduleExplore = new CourseScheduleModel(CourseExplore.CodCursoCourse, response[i]["horario"][0]["doc"].ToString(), response[i]["horario"][0]["doc"].ToString(), response[i]["horario"][0]["day"].ToString(), response[i]["horario"][0]["doc"].ToString(), CourseExplore);
                    //await AgregarHorario(CourseScheduleExplore);
                }
            }
            string ans = "";
            for(int i = 0; i < CurrentUser.Cursos.Count; i++)
            {
                ans += CurrentUser.Cursos[i].NameCourse;
            }
            currentCourses = await ObtenerTablaCursos();
            //string ans = currentCourses.Count.ToString();
            //string ans = currentCourses.Count.ToString();
            ans = "##";
            ans += CurrentUser.Cursos.Count.ToString();
            ans +="##";
            ans += cursos.Count.ToString();
            return ans;
        }

        public virtual async Task<ObservableCollection<CourseModel>> getcourses()
        {
            SessionModel currentSession = (await ObtenerTablaSession())[0];
            JArray response = await ServicioAPI.testCallHeaderArray("http://replica.javerianacali.edu.co:8100/WSMobile/mobile/v2/asignaturas", currentSession.TokenSession);

            List<UserModel> currentUsers = await ObtenerTablaUsuario();
            for (int i = 0; i < currentUsers.Count; i++)
            {
                if (currentUsers[i].Codigouser == currentSession.UserSession)
                {
                    CurrentUser = currentUsers[i];
                    break;
                }
            }
            currentCourses = await ObtenerTablaCursos();
            bool flag;
            for (int i = 0; i < response.Count; i++) //second response[i]["crse_id"].ToString()
            {
                CourseExplore = new CourseModel(response[i]["nom"].ToString(), response[i]["crse_id"].ToString(), response[i]["horario"][0]["doc"].ToString(), response[i]["notp"].ToString(), response[i]["porci"].ToString(), response[i]["class_section"].ToString(), response[i]["peri"].ToString(), CurrentUser);
                flag = false;
                for (int j = 0; j < currentCourses.Count; j++)
                {
                    if (response[i]["crse_id"].ToString() == currentCourses[j].CodCursoCourse && currentCourses[j].User.userModelID == CurrentUser.userModelID)
                    {
                        await ActualizarCurso(currentCourses[j]);
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    await AgregarCurso(CourseExplore);
                    //CourseScheduleExplore = new CourseScheduleModel(response[i]["crse_id"].ToString(), response[i]["horario"][0]["doc"].ToString(), response[i]["horario"][0]["doc"].ToString(), response[i]["horario"][0]["dia"].ToString(), response[i]["horario"][0]["doc"].ToString(), CourseExplore);
                    //await AgregarHorario(CourseScheduleExplore);
                }
            }
            List<CourseScheduleModel> currentHorarios = await ObtenerTablaHorarios();
            for (int i = 0; i < CurrentUser.Cursos.Count; i++)
            {
                //CurrentUser.Cursos[i].NameCourse = "";
                promedioFLOAT += float.Parse(CurrentUser.Cursos[i].AverageGradeCourse);
                foreach(var hor in response[i]["horario"])
                {
                    //CurrentUser.Cursos[i].NameCourse = CurrentUser.Cursos[i].NameCourse+"##"+ CurrentUser.Cursos[i].CodCursoCourse;
                    flag = true;
                    for(int j = 0; j < currentHorarios.Count; j++)
                    {
                        if (currentHorarios[j].IdCourseSchedule == response[i]["crse_id"].ToString() && currentHorarios[j].Course.User.Codigouser== currentSession.UserSession)
                        {
                            flag = false;
                            //CurrentUser.Cursos[i].NameCourse = CurrentUser.Cursos[i].NameCourse+"$" + currentHorarios[j].IdCourseSchedule + "#a#" + response[i]["crse_id"].ToString() + CurrentUser.Cursos[i].User.Codigouser + "#b#" + currentSession.UserSession + "#f#" + flag.ToString();
                        }
                    }
                    //CurrentUser.Cursos[i].NameCourse = CurrentUser.Cursos[i].NameCourse + "$"+ currentHorarios[j].IdCourseSchedule + "#a#" +response[i]["crse_id"].ToString() + CurrentUser.Cursos[i].User.Codigouser + "#b#" + currentSession.UserSession + "#f#"+flag.ToString();
                    if (flag)
                    {
                        CourseScheduleExplore = new CourseScheduleModel(response[i]["crse_id"].ToString(), hor["hora"].ToString(), hor["hora"].ToString(), hor["dia"].ToString(), hor["saln"].ToString(), CurrentUser.Cursos[i]);
                        await AgregarHorario(CourseScheduleExplore);
                    }
                }
                //CourseScheduleExplore = new CourseScheduleModel(response[i]["crse_id"].ToString(), response[i]["horario"][0]["doc"].ToString(), response[i]["horario"][0]["doc"].ToString(), response[i]["horario"][0]["dia"].ToString(), response[i]["horario"][0]["doc"].ToString(), CurrentUser.Cursos[i]);
                //await AgregarHorario(CourseScheduleExplore);
                //CurrentUser.Cursos[i].NameCourse = CurrentUser.Cursos[i].NameCourse.Substring(0,10) + "#" + CurrentUser.Cursos[i].Horarios.Count.ToString();
                CurrentUser.Cursos[i].NameCourse = CurrentUser.Cursos[i].NameCourse.Substring(0, Math.Min(26, CurrentUser.Cursos[i].NameCourse.Length));
                cursos.Add(CurrentUser.Cursos[i]);
                
                //CourseScheduleExplore = new CourseScheduleModel(response[i]["crse_id"].ToString(), response[i]["horario"][0]["doc"].ToString(), response[i]["horario"][0]["doc"].ToString(), response[i]["horario"][0]["day"].ToString(), response[i]["horario"][0]["doc"].ToString());
                //CourseScheduleExplore = new CourseScheduleModel(response[i]["crse_id"].ToString(), response[i]["horario"][0]["doc"].ToString(), "a","as","a");
            }
            promedioFLOAT /= CurrentUser.Cursos.Count;
            promedio = Convert.ToString(promedioFLOAT);
            promedio = promedio.Substring(0, Math.Min(4, promedio.Length));
            return cursos;
        }

        public virtual async Task<String> GetNamesito(ObservableCollection<CourseModel> entrada)
        {
            /*SessionModel currentSession = (await ObtenerTablaSession())[0];

            List<UserModel> currentUsers = await ObtenerTablaUsuario();
            for (int i = 0; i < currentUsers.Count; i++)
            {
                if (currentUsers[i].Codigouser == currentSession.UserSession)
                {
                    CurrentUser = currentUsers[i];
                    break;
                }
            }*/
            return (entrada.Count + 70).ToString();
        }
    }
}
