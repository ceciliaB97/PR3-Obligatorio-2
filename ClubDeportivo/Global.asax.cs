using Auxiliar;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ClubDeportivo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var repoConfig = FabricaRepositorios.ObtenerRepoConfig();
            Configuration configuration =  repoConfig.Buscar(1);
            Facade.Configuration = configuration;
            //agregar precarga de usuarios
            Facade.PrecargaUsuarios();
            //agregar precarga de actividades, con socios con horarios ya cargados


            Facade.ActualizarActividadesClub();

            //Session["LogueadoMail"] = null;
            //Session["Logueado"] = null;


        }
    }
}
