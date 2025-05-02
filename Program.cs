using System;
using System.Collections.Generic;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<CuentaBancaria> cuentas = new List<CuentaBancaria>();

            
            CajaAhorro ca1 = new CajaAhorro("1", 5000, new string[] { "Juan Pérez" });
            CajaAhorro ca2 = new CajaAhorro("2", 10000, new string[] { "Ana Gómez" });
            CuentaCorriente cc1 = new CuentaCorriente("3", 2000, new string[] { "Carlos López" });
            CuentaCorriente cc2 = new CuentaCorriente("4", 3000, new string[] { "Lucía Díaz" });

            
            cuentas.Add(ca1);
            cuentas.Add(ca2);
            cuentas.Add(cc1);
            cuentas.Add(cc2);

            
            try
            {
                ca1.Depositar(1500);
                ca1.Retirar(2000);

                ca2.Depositar(1000);
                ca2.Retirar(12000); 

                cc1.Depositar(500);
                cc1.Retirar(6000); 

                cc2.Retirar(10000); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            
            Console.WriteLine("\nResumen de cuentas:");
            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.GetType().Name,
                    Saldo = cuenta.Saldo,
                    Estado = cuenta.Estado
                };

                Console.WriteLine($"Número: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo}, Estado: {resumen.Estado}");
            }

            Console.ReadKey();
        }
    }
}
