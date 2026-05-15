public class CaratulExpedientes
{
    private string texto { get; set; }//se deberia usar set o init? preguntar mañana

    public CaratulaExpedientes(string texto)
    {
        if (!string.IsNullOrEmpty(texto))
        {
            this.texto = texto;
        }
        else
        {
            throw new ArgumentException("La carátula no puede estar vacía.");
        }
    }
}