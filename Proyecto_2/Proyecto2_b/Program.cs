using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_2
{
    // Edson Galdamez Marcos 1247324
    class Proyecto
    {
        static List<Transaccion> transacciones = new List<Transaccion>();
        static void Main(string[] args)
        {
            int conta = 0;
            double saldo = 2500;
            double pos = 0;
            double tasaInt = 0.02;
            int diasM = 30;
            string moneda = "";
            string simboloMoneda = "";
            List<CuentaTercero> cuentasTerceros = new List<CuentaTercero>();
            while (true)
            {
                Console.WriteLine("Ingrese el tipo de moneda (Q para Quetzales, $ para Dólares):");
                moneda = Console.ReadLine().ToUpper();
                if (moneda == "Q")
                {
                    simboloMoneda = "Q";
                    break;
                }
                else if (moneda == "$")
                {
                    simboloMoneda = "$";
                    break;
                }
                else
                {
                    Console.WriteLine("Tipo de moneda no válido. Intente de nuevo.");
                }
            }
            string cuenta;
            while (true)
            {
                Console.WriteLine("Ingrese su tipo de cuenta:");
                cuenta = Console.ReadLine();
                if (IsAllLetters(cuenta))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("El tipo de cuenta debe contener solo letras. Intente de nuevo.");
                }
            }
            string nombre;
            while (true)
            {
                Console.WriteLine("Ingrese su nombre:");
                nombre = Console.ReadLine();
                if (IsAllLetters(nombre))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("El nombre debe contener solo letras. Intente de nuevo.");
                }
            }
            string dpi;
            while (true)
            {
                Console.WriteLine("Ingrese el valor de DPI (5 dígitos):");
                dpi = Console.ReadLine();
                if (IsValidDPI(dpi))
                {
                    Console.WriteLine("El DPI ingresado es válido.");
                    break;
                }
                else
                {
                    Console.WriteLine("El DPI ingresado no es válido. Debe contener exactamente 5 dígitos. Por favor, intente de nuevo.");
                }
            }
            string direccion;
            while (true)
            {
                Console.WriteLine("Ingrese su Dirección:");
                direccion = Console.ReadLine();
                if (IsValidAddress(direccion))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("La dirección debe contener solo letras y espacios. Intente de nuevo.");
                }
            }
            string telefono;
            int tel;
            while (true)
            {
                Console.WriteLine("Ingrese su número de teléfono (8 dígitos):");
                telefono = Console.ReadLine();
                if (telefono.Length == 8 && int.TryParse(telefono, out tel))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Número de teléfono inválido. Debe contener exactamente 8 dígitos. Intente de nuevo.");
                }
            }
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                          * MENÚ *                         ║");
                Console.WriteLine("╠══════════════════════════════╦════════════════════════════╣");
                Console.WriteLine("║  1. Información de cuenta    ║  2. Comprar producto       ║");
                Console.WriteLine("╠══════════════════════════════╬════════════════════════════╣");
                Console.WriteLine("║  3. Vender producto          ║  4. Abonar cuenta          ║");
                Console.WriteLine("╠══════════════════════════════╬════════════════════════════╣");
                Console.WriteLine("║  5. Simular tiempo           ║  6. Cuentas de terceros    ║");
                Console.WriteLine("╠══════════════════════════════╬════════════════════════════╣");
                Console.WriteLine("║  7. Transferencias           ║  8. Pago de servicios      ║");
                Console.WriteLine("╠══════════════════════════════╬════════════════════════════╣");
                Console.WriteLine("║  9. Informe de transacciones ║  10. Salir                 ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
                Console.Write("Selecciona la opción a seguir: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine($"Su nombre es {nombre}, su tipo de cuenta es {cuenta}, su DPI es {dpi}, su dirección es {direccion}, su saldo es {simboloMoneda}{saldo}, y su teléfono es {tel}");
                        break;
                    case "2":
                        double gasto = saldo * 0.10;
                        saldo -= gasto;
                        RegistrarTransaccion(gasto, "Débito", "Compra de producto");
                        Console.WriteLine($"Su saldo actual es {simboloMoneda}{saldo}");
                        break;
                    case "3":
                        pos = saldo * 0.11;
                        if (saldo < 500)
                        {
                            Console.WriteLine($"Error, el saldo es muy bajo, su saldo actual es de {simboloMoneda}{saldo}");
                        }
                        else
                        {
                            saldo += pos;
                            RegistrarTransaccion(pos, "Crédito", "Venta de producto");
                            Console.WriteLine($"Su saldo actual es {simboloMoneda}{saldo}, la ganancia fue de {simboloMoneda}{pos}");
                        }
                        break;
                    case "4":
                        if (saldo < 500)
                        {
                            if (conta < 2)
                            {
                                double abono = saldo;
                                saldo *= 2;
                                RegistrarTransaccion(abono, "Crédito", "Abono a cuenta");
                                Console.WriteLine($"Tu nuevo saldo es de {simboloMoneda}{saldo}");
                                conta++;
                            }
                            else
                            {
                                Console.WriteLine("Esta acción no se puede repetir más de 2 veces");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, su saldo es demasiado alto");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Seleccione el periodo de capitalización:");
                        Console.WriteLine("1. Una vez al mes");
                        Console.WriteLine("2. Dos veces al mes");
                        int periodoCap = Convert.ToInt32(Console.ReadLine());
                        if (periodoCap == 1)
                        {
                            double interes = saldo * tasaInt * diasM / 360;
                            saldo += interes;
                            RegistrarTransaccion(interes, "Crédito", "Interés mensual");
                            Console.WriteLine($"Día 30: Saldo bancario (actualizado) = {simboloMoneda}{saldo:C}");
                        }
                        else if (periodoCap == 2)
                        {
                            double interes = saldo * tasaInt * (diasM / 2) / 360;
                            saldo += interes;
                            RegistrarTransaccion(interes, "Crédito", "Interés quincenal");
                            Console.WriteLine($"Día 15: Saldo bancario (actualizado) = {simboloMoneda}{saldo:C}");
                            interes = saldo * tasaInt * (diasM / 2) / 360;
                            saldo += interes;
                            RegistrarTransaccion(interes, "Crédito", "Interés quincenal");
                            Console.WriteLine($"Día 30: Saldo bancario (actualizado) = {simboloMoneda}{saldo:C}");
                        }
                        else
                        {
                            Console.WriteLine("Periodo de capitalización no válido.");
                        }
                        break;
                    case "6":
                        MantenimientoCuentasTerceros(cuentasTerceros, simboloMoneda);
                        break;
                    case "7":
                        RealizarTransferencias(cuentasTerceros, ref saldo, simboloMoneda);
                        break;
                    case "8":
                        PagoDeServicios(ref saldo, simboloMoneda);
                        break;
                    case "9":
                        MostrarInformeDeTransacciones();
                        break;
                    case "10":
                        Console.WriteLine("Has elegido salir de la aplicación");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("La opción seleccionada no es válida");
                        break;
                }
            }
        }
        static bool IsValidDPI(string dpi)
        {
            return dpi.Length == 5 && int.TryParse(dpi, out _);
        }
        static bool IsAllLetters(string input)
        {
            return input.All(char.IsLetter);
        }
        static bool IsValidAddress(string address)
        {
            return address.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
        static void MantenimientoCuentasTerceros(List<CuentaTercero> cuentasTerceros, string moneda)
        {
            while (true)
            {
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║        * Mantenimiento Cuentas *       ║");
                Console.WriteLine("╠════════════════════════════════════════╣");
                Console.WriteLine("║  1. Crear Cuenta                       ║");
                Console.WriteLine("║  2. Eliminar Cuenta                    ║");
                Console.WriteLine("║  3. Actualizar Cuenta                  ║");
                Console.WriteLine("║  4. Regresar al Menú Principal         ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.Write("Selecciona la opción a seguir: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearCuentaTercero(cuentasTerceros, moneda);
                        break;
                    case "2":
                        EliminarCuentaTercero(cuentasTerceros);
                        break;
                    case "3":
                        ActualizarCuentaTercero(cuentasTerceros);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void CrearCuentaTercero(List<CuentaTercero> cuentasTerceros, string moneda)
        {
            Console.WriteLine("Ingrese el nombre del cuentahabiente:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el número de cuenta:");
            string numeroCuenta = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del banco:");
            string banco = Console.ReadLine();
            int id = cuentasTerceros.Count + 1;
            CuentaTercero cuentaTercero = new CuentaTercero(id, nombre, numeroCuenta, banco, 0, moneda);
            cuentasTerceros.Add(cuentaTercero);
            Console.WriteLine("Cuenta de tercero creada exitosamente.");
        }

        static void EliminarCuentaTercero(List<CuentaTercero> cuentasTerceros)
        {
            Console.WriteLine("Ingrese el ID de la cuenta a eliminar:");
            int id = int.Parse(Console.ReadLine());
            CuentaTercero cuenta = cuentasTerceros.FirstOrDefault(c => c.Id == id);
            if (cuenta != null)
            {
                cuentasTerceros.Remove(cuenta);
                Console.WriteLine("Cuenta eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("Cuenta no encontrada.");
            }
        }

        static void ActualizarCuentaTercero(List<CuentaTercero> cuentasTerceros)
        {
            Console.WriteLine("Ingrese el ID de la cuenta a actualizar:");
            int id = int.Parse(Console.ReadLine());

            CuentaTercero cuenta = cuentasTerceros.FirstOrDefault(c => c.Id == id);
            if (cuenta != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre del cuentahabiente:");
                cuenta.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo número de cuenta:");
                cuenta.NumeroCuenta = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo nombre del banco:");
                cuenta.Banco = Console.ReadLine();
                Console.WriteLine("Cuenta de tercero actualizada exitosamente.");
            }
            else
            {
                Console.WriteLine("Cuenta no encontrada.");
            }
        }

        static void RealizarTransferencias(List<CuentaTercero> cuentasTerceros, ref double saldo, string simboloMoneda)
{
    Console.WriteLine("Cuentas de Terceros:");
    foreach (var cuenta in cuentasTerceros)
    {
        Console.WriteLine($"ID: {cuenta.Id}, Nombre: {cuenta.Nombre}, Número de Cuenta: {cuenta.NumeroCuenta}, Banco: {cuenta.Banco}, Monto:  {cuenta.Moneda}{cuenta.Monto}");
    }

    int id;
    while (true)
    {
        Console.WriteLine("Ingrese el ID de la cuenta a la que desea transferir:");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out id))
        {
            if (cuentasTerceros.Any(c => c.Id == id))
            {
                break; 
            }
            else
            {
                Console.WriteLine("ID no encontrado. Intente de nuevo.");
            }
        }
        else
        {
            Console.WriteLine("Ingrese un valor numérico válido.");
        }
    }
            CuentaTercero cuentaTercero = cuentasTerceros.FirstOrDefault(c => c.Id == id);
            if (cuentaTercero != null)
            {
                Console.WriteLine("Seleccione el monto a transferir (entre 200 y 2000):");
                double montoTransferencia = double.Parse(Console.ReadLine());

                if (montoTransferencia > 199 && montoTransferencia < 2001)
                {
                    if (saldo >= montoTransferencia)
                    {
                        saldo -= montoTransferencia;
                        DateTime now = DateTime.Now;
                        Console.WriteLine($"Transferencia realizada exitosamente a la cuenta {cuentaTercero.NumeroCuenta} por un monto de {simboloMoneda}{montoTransferencia}. Fecha y hora: {now}");
                        transacciones.Add(new Transaccion(now, montoTransferencia, "Débito", $"Transferencia a cuenta {cuentaTercero.NumeroCuenta}"));
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
                    }
                }
                else
                {
                    Console.WriteLine("Monto de transferencia no válido. Debe ser entre 200 y 2000.");
                }
            }
            else
            {
                Console.WriteLine("Cuenta no encontrada.");
            }
        }

        static void PagoDeServicios(ref double saldo, string simboloMoneda)
        {
            Console.WriteLine("Seleccione el servicio a pagar:");
            Console.WriteLine("1. Empresa de Agua");
            Console.WriteLine("2. Empresa Eléctrica");
            Console.WriteLine("3. Telefónica");

            string opcionServicio = Console.ReadLine();
            string servicio = "";
            switch (opcionServicio)
            {
                case "1":
                    servicio = "Empresa de Agua";
                    break;
                case "2":
                    servicio = "Empresa Eléctrica";
                    break;
                case "3":
                    servicio = "Telefónica";
                    break;
                default:
                    Console.WriteLine("Opción de servicio no válida. Intente de nuevo.");
                    return;
            }

            Console.WriteLine($"Ingrese el monto a pagar para {servicio}");
            double montoPago = double.Parse(Console.ReadLine());

            if (saldo >= montoPago)
            {
                saldo -= montoPago;
                DateTime now = DateTime.Now;
                Console.WriteLine($"Pago realizado exitosamente a {servicio} por un monto de {simboloMoneda}{montoPago}. Fecha y hora: {now}");
                transacciones.Add(new Transaccion(now, montoPago, "Débito", $"Pago a {servicio}"));
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para realizar el pago.");
            }
        }

        static void MostrarInformeDeTransacciones()
        {
            Console.WriteLine("Informe de Transacciones:");
            foreach (var transaccion in transacciones)
            {
                Console.WriteLine($"{transaccion.FechaHora} - {transaccion.Tipo} - {transaccion.Monto} - {transaccion.Detalle}");
            }
        }

        static void RegistrarTransaccion(double monto, string tipo, string detalle)
        {
            DateTime now = DateTime.Now;
            transacciones.Add(new Transaccion(now, monto, tipo, detalle));
        }

        public class CuentaTercero
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string NumeroCuenta { get; set; }
            public string Banco { get; set; }
            public double Monto { get; set; }
            public string Moneda { get; set; }

            public CuentaTercero(int id, string nombre, string numeroCuenta, string banco, double monto, string moneda)
            {
                Id = id;
                Nombre = nombre;
                NumeroCuenta = numeroCuenta;
                Banco = banco;
                Monto = monto;
                Moneda = moneda;
            }
        }

        public class Transaccion
        {
            public DateTime FechaHora { get; set; }
            public double Monto { get; set; }
            public string Tipo { get; set; }
            public string Detalle { get; set; }

            public Transaccion(DateTime fechaHora, double monto, string tipo, string detalle)
            {
                FechaHora = fechaHora;
                Monto = monto;
                Tipo = tipo;
                Detalle = detalle;
            }
        }
    }
}
