using System.Reflection.Emit;
{
    double vf= 0.0,vi =0.0,a =0.0,t=0.0;

    Console.WriteLine("Resuelva la ecuación cuadratica para a, b, c " +
    "Expresion : x = (-b +- raizCuadrada((b*b)-4ac))/(2a)");

    Console.WriteLine("Ingrese la velocidad inicial");
    vi = Double.Parse(Console.ReadLine());
    Console.WriteLine("La velocidad inicial es = " + vi);

    Console.WriteLine("Ingrese el tiempo");
    t = Double.Parse(Console.ReadLine());
    Console.WriteLine("El tiempo es = " + t);

    Console.WriteLine("Ingrese la aceleracion");
    a = Double.Parse(Console.ReadLine());
    Console.WriteLine("El valor de c es = " + a);
    vf=vi+a*t;
    Console.WriteLine("La velocidad final es: " + vf);
}