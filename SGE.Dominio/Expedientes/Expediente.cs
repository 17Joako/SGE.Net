public class Expediente
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltimaActualizacion { get; set; }
    public string Estado { get; set; }
}