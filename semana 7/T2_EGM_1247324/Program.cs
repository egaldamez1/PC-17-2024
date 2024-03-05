using System;

class Program
{
    static void Main(string[] args)
    {
        // Pedir al usuario su nombre
        Console.Write("Ingrese su nombre: ");
        string nombre = Console.ReadLine();

        // Pedir al usuario su carne
        Console.Write("Ingrese su carne: ");
        string carne = Console.ReadLine();

        // Pedir al usuario la cantidad en quetzales
        Console.Write("Ingrese la cantidad en quetzales (entre 0 y 999.99): ");
        double cantidad = Convert.ToDouble(Console.ReadLine());

        // Validar que la cantidad esté dentro del rango permitido
        if (cantidad < 0 || cantidad > 999.99)
        {
            Console.WriteLine("La cantidad ingresada no está dentro del rango permitido.");
            return;
        }

        // Calcular el equivalente en billetes y monedas
        int billetes100 = (int)(cantidad / 100);
        cantidad %= 100;

        int billetes50 = (int)(cantidad / 50);
        cantidad %= 50;

        int billetes20 = (int)(cantidad / 20);
        cantidad %= 20;

        int billetes10 = (int)(cantidad / 10);
        cantidad %= 10;

        int billetes5 = (int)(cantidad / 5);
        cantidad %= 5;

        int monedas1 = (int)cantidad;
        cantidad -= monedas1;

        int centavos = (int)(cantidad * 100);

        // Mostrar el resultado
        Console.WriteLine("\nEquivalente en billetes y monedas:");
        Console.WriteLine($"Billetes de 100: {billetes100}");
        Console.WriteLine($"Billetes de 50: {billetes50}");
        Console.WriteLine($"Billetes de 20: {billetes20}");
        Console.WriteLine($"Billetes de 10: {billetes10}");
        Console.WriteLine($"Billetes de 5: {billetes5}");
        Console.WriteLine($"Monedas de 1 quetzal: {monedas1}");
        Console.WriteLine($"Monedas de 25 centavos: {centavos / 25}");
        Console.WriteLine($"Monedas de 1 centavo: {centavos % 25}");

        // Mostrar el nombre y carne del usuario
        Console.WriteLine($"\nNombre: {nombre}");
        Console.WriteLine($"Carne: {carne}");
    }
}
