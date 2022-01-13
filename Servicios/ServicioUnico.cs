namespace Portafolio.Servicios
{
    //Siempre va a ser único para toda la app
    public class ServicioUnico
    {
        public ServicioUnico()
        {
            ObtenerGuid = Guid.NewGuid();
        }

        public Guid ObtenerGuid { get; set; }
    }

    //Dentro de la misma peticion HTTP van a ser iguales
    public class ServicioDelimitado
    {
        public ServicioDelimitado()
        {
            ObtenerGuid = Guid.NewGuid();
        }

        public Guid ObtenerGuid { get; set; }
    }

    //cambia cada vez que se refresque la p'agina
    public class ServicioTransitorio
    {
        public ServicioTransitorio()
        {
            ObtenerGuid = Guid.NewGuid();
        }

        public Guid ObtenerGuid { get; set; }
    }
}
