public class Tramite
{
    private enum etiqueta{
        EscritoPresentado, 
        PaseAEstudio, 
        Despacho, 
        Resolucion, 
        Notificacion,   
        PaseAlArchivo
        
    }
    public Guid Id { get;}//guid1
    public Guid ExpedienteId { get;}//guid2
    public etiqueta Etiqueta { get;}//esto es enumerativo
    public String Contenido{get; set; }//aca se almacenan los datos de texto o string
    public DateTime FechaCreacion { get;}//cuando se creo
    public DateTime FechaUltimaModificacion{ get; set; }//cuando se modifico la ultima vez la entidad
    public Guid UsuarioUltimoCambio {get; set; }

    public Tramite(string contenido)
    {
        Id = Guid.NewGuid();
        ExpedienteId =  Guid.NewGuid();;
        Etiqueta = 0;
        Contenido = contenido;
        FechaCreacion = DateTime.Now;
        FechaUltimaModificacion = this.FechaCreacion;
        UsuarioUltimoCambio = this.Id;
    }
}