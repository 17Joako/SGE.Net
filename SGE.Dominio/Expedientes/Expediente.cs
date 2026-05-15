using Expedientes;
public class Expediente
{
    // datos de Expediente
    private Guid Id { get; set; }
    private CaratulaExpedientes Caratula { get; set; }
    private DateTime FechaCreacion { get; set; }
    private DateTime FechaUltimaModificacion { get; set; }
    private Guid UsuarioUltimoCambio { get; set; }
    
    private EstadoExpediente Estado  { get; set; }
    // constructor de Expediente
    public Expediente(Guid id, CaratulaExpedientes caratula, DateTime fechaCreacion, DateTime fechaUltimaModificacion, Guid usuarioUltimoCambio)
    {
        this.Id = new Guid();
        this.Caratula = new CaratulaExpedientes(caratula);
        this.FechaCreacion = fechaCreacion;
        this.FechaUltimaModificacion = fechaUltimaModificacion;
        this.UsuarioUltimoCambio = new Guid();
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
}