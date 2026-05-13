public class Program
{
    public static void Main(string[] args)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Numero: {i}");
        }
        foreach (var numero in Enumerable.Range(1, 10))
        {
            Console.WriteLine($"Numero: {numero}");
        }
    }
}