using System.Collections;

namespace Proyecto_1
//Edson Galdamez Marcos 1247324
//Marc Wilhelm Schaub Garcia 1243424
{
    class Proyecto
    {
        static void Main(String[] args)
        {
            int conta=0;
            double saldo=2500;
            double pos=0;
            double tasaInt = 0.02;
            int diasM= 30;
            int diasT= 0;
            Console.WriteLine("Ingrese su tipo de cuenta");
            String cuenta = Console.ReadLine();
            Console.WriteLine("Ingrese su nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su dpi");
            int dpi = int.Parse (Console.ReadLine());
            Console.WriteLine("Ingrese su Dirección");
            string Direccion = Console.ReadLine();
            Console.WriteLine("Ingrese su numero de telefono");
            int tel = int.Parse (Console.ReadLine());
            bool salir = false;
            while(!salir)
            {
                Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                          * MENÚ *                         ║");
                Console.WriteLine("╠══════════════════════════════╦════════════════════════════╣");
                Console.WriteLine("║  1. Informacion  de cuenta   ║  2. Comprar producto       ║");
                Console.WriteLine("╠══════════════════════════════╬════════════════════════════╣");
                Console.WriteLine("║   3. Vender producto         ║   4. Abonar cuenta         ║");
                Console.WriteLine("╠══════════════════════════════╬════════════════════════════╣");
                Console.WriteLine("║    5. Simular tiempo         ║    6. Salir                ║");
                Console.WriteLine("╚══════════════════════════════╩════════════════════════════╝");
                Console.Write("Selecciona la opcion a seguir:");

                string opcion = Console.ReadLine();
                switch(opcion)
                {
                    case "1":
                    Console.WriteLine("Su nombre es " + nombre + ", su tipo de cuenta es " + cuenta + ", su dpi es " + dpi + ", su direccion es " + Direccion + ", su saldo es " + saldo + ", y su telefono es " + tel);
                    break;
                    case "2":
                    saldo = saldo - (saldo * 0.10);
                    Console.WriteLine("Su saldo actual es " + saldo);
                    break;
                    case "3":
                    pos=saldo*0.11;
                    if (saldo < 500)
                    {Console.WriteLine("Error, el saldo es muy bajo, su saldo actual es de " + saldo);}
                    else
                    {saldo = saldo + (saldo * 0.11);
                    Console.WriteLine("Su saldo actual es " + saldo + ", la ganancia fue de " + pos);}
                    break;
                    case"4":
                    if (saldo < 500)
                    {
                    if (conta < 2)
                    {
                        saldo=saldo*2;
                        Console.WriteLine("Tu nuevo saldo es de "+ saldo);
                    }
                    else {Console.WriteLine("Esta accion no se puede repetir mas de 2 veces");}
                    conta=conta+1;
                    }
                    else {Console.WriteLine("Error, su saldo es demasiado alto");}
                    break;
                    case "5":
                     Console.WriteLine("Seleccione el periodo de capitalización:");
                     Console.WriteLine("1. Una vez al mes");
                     Console.WriteLine("2. Dos veces al mes");
                     int periodoCap = Convert.ToInt32(Console.ReadLine());
                     if (periodoCap == 1)
                    {
                    while (diasT < diasM)
                    {
                        double interes = saldo * tasaInt * (diasT + 1)/360;
                        saldo += interes;
                        diasT++;
                        if (periodoCap == 1 && diasT == 30) 
                        {
                            Console.WriteLine($"Día 30: Saldo bancario (actualizado) = {saldo:C}");
                        }
                    }
                    };;;;;
                    if (periodoCap == 2)
                    {
                    while (diasT < diasM/2)
                    {
                        double interes = saldo * tasaInt * (diasT + 1)/360;
                        saldo += interes;
                        diasT++;
                        
                        if (periodoCap == 2 && diasT == 15)
                        {
                        interes = saldo * tasaInt * (diasT)/360;
                        saldo += interes;
                        Console.WriteLine($"Día 15: Saldo bancario (actualizado) = {saldo:C}");
                        }
                    }
                    }

                    break;
                    case "6":
                    Console.WriteLine("Has elegido salir de la aplicacion");
                    salir = true;
                    break;
                    default:
                Console.WriteLine("La opcion seleccionada no es valida");
                break;
                }
            }
        }
    }
}