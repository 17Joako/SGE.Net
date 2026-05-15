public class Tramite
{   public Guid Id { get;}//guid1
    public Guid ExpedienteId { get;}//recibe 
    public Etiquetas Etiqueta { get;}//esto es enumerativo
    public ContenidoTramite Contenido { get; init; }//aca se almacenan los datos de texto o string
    public DateTime FechaCreacion { get;}//cuando se creo
    public DateTime FechaUltimaModificacion{ get;private set; }//cuando se modifico la ultima vez la entidad
    public Guid UsuarioUltimoCambio {get;private set; }

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
        // Aquí no se genera un Guid nuevo ni se obliga a que el estado sea "Abierto".
        // Simplemente se "rehidrata" el objeto con los datos históricos de la BD.
        return new Expediente
        {
            Id = id,
            ExpedienteId = expedienteId,
            Etiqueta=etiqueta,
            Eti
        };
    }
}