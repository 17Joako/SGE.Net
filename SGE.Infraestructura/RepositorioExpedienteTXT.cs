public class RepositorioExpedienteTXT
{
    private string rutaArchivo;

    // lo hacemos asi para que el repositorio sea reutilizable y no dependa de una ruta fija, sino que se le pueda pasar la ruta al crear una instancia del repositorio  
    public RepositorioExpedienteTXT(string rutaArchivo)
    {
        this.rutaArchivo = rutaArchivo;
    }
    // primero agrego el id, y luego agrego el resto de datos
    public void Agregar(Expediente expediente)
    {
        using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
        {
            sw.WriteLine($"{expediente.Id};{expediente.Nombre};{expediente.FechaCreacion}");
        }
    }

    public void Eliminar(int id)
    {
        var expedientes = BuscarTodos();
        expedientes.RemoveAll(e => e.Id == id);
        GuardarTodos(expedientes);
    }

    public Expediente Buscar(int id)
    {
        var expedientes = BuscarTodos();
        return expedientes.FirstOrDefault(e => e.Id == id);
    }

    private List<Expediente> BuscarTodos()
    {
        var expedientes = new List<Expediente>();
        if (File.Exists(rutaArchivo))
        {
            var lineas = File.ReadAllLines(rutaArchivo);
            foreach (var linea in lineas)
            {
                var partes = linea.Split(';');
                if (partes.Length == 3)
                {
                    expedientes.Add(new Expediente
                    {
                        Id = int.Parse(partes[0]),
                        Nombre = partes[1],
                        FechaCreacion = DateTime.Parse(partes[2])
                    });
                }
            }
        }
        return expedientes;
    }

    private void GuardarTodos(List<Expediente> expedientes)
    {
        using (StreamWriter sw = new StreamWriter(rutaArchivo, false))
        {
            foreach (var expediente in expedientes)
            {
                sw.WriteLine($"{expediente.Id};{expediente.Nombre};{expediente.FechaCreacion}");
            }
        }
    }
}