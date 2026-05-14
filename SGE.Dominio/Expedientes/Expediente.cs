using Expedientes;
public class Expediente
{
    private Guid Id { get; set; }
    private CaratulaExpedientes Caratula { get; set; }
    private DateTime FechaCracion { get; set; }
    private DateTime FechaUltimaModificacion { get; set; }
    private Guid UsuarioUltimoCambio { get; set; }
    
    private EstadoExpediente Estado  { get; set; }

    public Expediente(Guid id, CaratulaExpedientes caratula, DateTime fechaCracion, DateTime fechaUltimaModificacion, Guid usuarioUltimoCambio, EstadoExpediente estado)
    {
        Id = id;
        Caratula = caratula;
        FechaCracion = fechaCracion;
        FechaUltimaModificacion = fechaUltimaModificacion;
        UsuarioUltimoCambio = usuarioUltimoCambio;
        Estado = estado;
    }
}