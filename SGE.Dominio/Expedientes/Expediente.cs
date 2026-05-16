public class Expediente
{
    // datos de Expediente
    public Guid Id { get; } // id único de cada expediente
    public CaratulaExpedientes Caratula { get; private set; }
    public DateTime FechaCreacion { get; }
    public DateTime FechaUltimaModificacion { get; private set; } // fecha del ultimo cambio realizado al expediente
    public Guid UsuarioUltimoCambio { get; private set; } // id del usuario que realizó el último cambio al expediente
    public EstadoExpedientes Estado  { get; private set; } // tipo Enumerativo de posibles estados del expediente
    // constructor de Expediente
    public Expediente(Guid id, CaratulaExpedientes caratula, DateTime fechaCreacion, DateTime fechaUltimaModificacion, Guid usuarioUltimoCambio)
    {
        this.Id = id;
        this.Caratula = caratula;
        this.FechaCreacion = fechaCreacion;
        this.FechaUltimaModificacion = fechaUltimaModificacion;
        this.UsuarioUltimoCambio = usuarioUltimoCambio;
        this.Estado = EstadoExpedientes.RecienIniciado;
    }

    // Modificar caratula de expediente en caso de error al momento de la creación
    public void ModificarCaratula(CaratulaExpedientes nuevaCaratula, Guid idUsuario)
    {
        this.Caratula = nuevaCaratula;
        this.UsuarioUltimoCambio = idUsuario;
        this.FechaUltimaModificacion = DateTime.Now;
    }

    // todavía por terminar
    public bool ActualizarEstado (Etiquetas? ultimaEtiqueta, Guid idUsuario) //por implementar: acceso a último trámite
    {
        bool aux = true;
        if (ultimaEtiqueta == null)
        {
            Estado = EstadoExpedientes.RecienIniciado;
        }
        else if (ultimaEtiqueta == Etiquetas.Resolucion)
        {
            Estado = EstadoExpedientes.ConResolucion;
        }
        else if (ultimaEtiqueta == Etiquetas.PaseAEstudio)
        {
            Estado = EstadoExpedientes.ParaResolver;
        }
        else if (ultimaEtiqueta == Etiquetas.PaseAlArchivo)
        {
            Estado = EstadoExpedientes.Finalizado;
        }
        else aux = false;
        UsuarioUltimoCambio=idUsuario;
        FechaUltimaModificacion = DateTime.Now;
        return aux;
    }

    // todavía por terminar: cambiar estado del expediente
    public void CambiarEstado(EstadoExpedientes nuevoEstado, Guid idUsuario) //preguntar mañana si es mejor un booleano retornado o una excepcion
    {
        
        bool encontreUsuario=false;
        using (StreamReader reader = new StreamReader("ruta_del_archivo_de_estados.txt"))
        {
            //ESTO DE ACA tiene que pedir a la base de datos, la base de datos es un txt por ahora
            while ((!reader.EndOfStream) && (!encontreUsuario))
            {
                if(reader.ReadLine()==idUsuario.ToString())
                {
                    //deberia modificar los archivos
                    encontreUsuario=true;
                }
            }
        }
    }
}