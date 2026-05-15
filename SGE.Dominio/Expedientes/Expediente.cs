using Expedientes;
public class Expediente
{
    // datos de Expediente
    private Guid Id { get; } // id único de cada expediente
    private CaratulaExpedientes Caratula { get; private set; }
    private DateTime FechaCreacion { get; }
    private DateTime FechaUltimaModificacion { get; private set; } // fecha del ultimo cambio realizado al expediente
    private Guid UsuarioUltimoCambio { get; private set; } // id del usuario que realizó el último cambio al expediente
    private EstadoExpediente Estado  { get; private set; } // tipo Enumerativo de posibles estados del expediente
    // constructor de Expediente
    public Expediente(Guid id, CaratulaExpedientes caratula, DateTime fechaCreacion, DateTime fechaUltimaModificacion, Guid usuarioUltimoCambio)
    {
        this.Id = id;
        this.Caratula = new CaratulaExpedientes(caratula);
        this.FechaCreacion = fechaCreacion;
        this.FechaUltimaModificacion = fechaUltimaModificacion;
        this.UsuarioUltimoCambio = usuarioUltimoCambio;
        this.Estado = EstadoExpediente.RecienIniciado;
    }

    // Modificar caratula de expediente en caso de error al momento de la creación
    public bool ModificarCaratula(CaratulaExpedientes nuevaCaratula, Guid idUsuario)
    {
        bool aux = true;
        if (!string.IsNullOrEmpty(nuevaCaratula.getTexto()))
        {
            this.Caratula = nuevaCaratula;
            this.setUsuarioUltimoCambio(idUsuario);
            this.setFechaUltimaModificacion(DateTime.Now);
        }
        else
        {
            aux = false;
            throw new ArgumentException("La carátula no puede estar vacía.");
        }
        return aux;
    }

    // todavía por terminar
    public bool ActualizarEstado (EtiquetaTramite? ultimaEtiqueta, Guid idUsuario) //por implementar: acceso a último trámite
    {
        bool aux = true;
        if (ultimaEtiqueta == null)
        {
            this.setEstado(EstadoExpediente.RecienIniciado);
        }
        else if (ultimaEtiqueta == EtiquetaTramite.Resolucion)
        {
            this.setEstado(EstadoExpediente.ConResolucion);
        }
        else if (ultimaEtiqueta == EtiquetaTramite.PaseAEstudio)
        {
            this.setEstado(EstadoExpediente.ParaResolver);
        }
        else if (ultimaEtiqueta == EstadoExpediente.PaseAlArchivo)
        {
            this.setEstado(EstadoExpediente.Finalizado);
        }
        else aux = false;
        this.setUsuarioUltimoCambio(idUsuario);
        this.setFechaUltimaModificacion(DateTime.Now);
        return aux;
    }

    // todavía por terminar: cambiar estado del expediente
    public void CambiarEstado(EstadoExpediente nuevoEstado, Guid idUsuario) //preguntar mañana si es mejor un booleano retornado o una excepcion
    {
        bool encontreUsuario=false;
        using (StreamReader reader = new StreamReader("ruta_del_archivo_de_estados.txt"))
        {
            //preguntar como saber cual es el id
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