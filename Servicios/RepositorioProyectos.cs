using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }

    public class RepositorioProyectos : IRepositorioProyectos
    {


        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {
                    Titulo = "Workflow",
                    Descripcion = "workflow desarrollado en ASP.NET Core",
                    Link = "https://workflowTeam.net/",
                    ImageUrl = "/images/amazon.png"
                },
                new Proyecto
                {
                    Titulo = "Gestion Documental",
                    Descripcion = "Gestor documental desarrollado en ASP.NET Core",
                    Link = "https://workflowTeam.net/",
                    ImageUrl = "/images/nyt.png"
                },
                new Proyecto
                {
                    Titulo = "Nómina",
                    Descripcion = "Software de Nómina desarrollado en ASP.NET Core",
                    Link = "https://workflowTeam.net/",
                    ImageUrl = "/images/reddit.png"
                },
                new Proyecto
                {
                    Titulo = "Web API",
                    Descripcion = "WEb API Restfull desarrollado en ASP.NET Core",
                    Link = "https://workflowTeam.net/",
                    ImageUrl = "/images/steam.png"
                },
            };
        }
    }
}
