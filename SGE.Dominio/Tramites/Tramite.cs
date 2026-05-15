public class Tramite
{   private Guid Id { get;}//guid1
    private Guid ExpedienteId { get; private set;}//recibe 
    private Etiquetas Etiqueta { get; private set;}//esto es enumerativo
    private ContenidoTramite Contenido { get; init; }//aca se almacenan los datos de texto o string
    private DateTime FechaCreacion { get;private set;}//cuando se creo
    private DateTime FechaUltimaModificacion{ get;private set; }//cuando se modifico la ultima vez la entidad
    private Guid UsuarioUltimoCambio {get;private set; }

    public Tramite(Guid expedienteID,ContenidoTramite contenido)
    {
        Id = Guid.NewGuid();
        ExpedienteId=expedienteID ;
        Etiqueta = 0;
        Contenido = contenido;
        FechaCreacion = DateTime.Now;
        FechaUltimaModificacion = this.FechaCreacion;
        UsuarioUltimoCambio = this.Id;
    }
    public static Expediente Reconstruir(Guid id, Guid expedienteId, Etiquetas etiqueta,ContenidoTramite contenido,DateTime fechaCreacion,DateTime fechaUltimaModificacion,Guid usuarioUltimoCambio)
    {
        //me mandan los datos desde la BD y yo reconstruyo el objeto
        return new Expediente
        {
            Id = id,
            ExpedienteId = expedienteId,
            Etiqueta=etiqueta,
            Etiqueta=etiqueta,
            Contenido=contenido,
            FechaCreacion=fechaCreacion,
            FechaUltimaModificacion= fechaUltimaModificacion,
        };
    }
}