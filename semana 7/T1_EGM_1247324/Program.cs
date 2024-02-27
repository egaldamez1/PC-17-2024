class programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mi segundo programa");

        Console.WriteLine("Ingresa tu nombre");
        string sNombre = Console.ReadLine();

         Console.WriteLine("Ingresa tu edad");
        string sEdad = Console.ReadLine();

         Console.WriteLine("Ingresa tu carrera");
        string scarrera = Console.ReadLine();

         Console.WriteLine("Ingresa tu carné");
        string scarne = Console.ReadLine();

        Console.WriteLine("Soy " + sNombre + " tengo " + sEdad + ", años y estudio la carrera de " + scarrera);

        Console.WriteLine("Mi carné es " + scarne);
    }
}