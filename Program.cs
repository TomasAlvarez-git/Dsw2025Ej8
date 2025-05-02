using System;
using System.Collections.Generic;
using Dsw2025Ej8.Domain;

class Program
{
    static void Main()
    {
       
        var cuentas = new List<CuentaBancaria>
        {
            new CajaAhorro("CA001", 1000, new[] { "Ana", "Luis" }),
            new CajaAhorro("CA002", 200, new[] { "Juan" }),
            new CuentaCorriente("CC001", 300, new[] { "María" }),
            new CuentaCorriente("CC002", 50, new[] { "Pedro", "Lucía" })
        };

        foreach (var cuenta in cuentas)
        {
            Console.WriteLine($"\n-- Operando con cuenta {cuenta.Numero} --");

            try
            {
                cuenta.Depositar(500);
                Console.WriteLine($"[OK] Depósito exitoso en cuenta {cuenta.Numero}. Saldo actual: {cuenta.Saldo:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Depósito fallido en cuenta {cuenta.Numero}: {ex.Message}");
            }

            
            try
            {
                cuenta.Retirar(300);
                Console.WriteLine($"[OK] Retiro exitoso en cuenta {cuenta.Numero}. Saldo actual: {cuenta.Saldo:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Retiro fallido en cuenta {cuenta.Numero}: {ex.Message}");
            }

            
            try
            {
                cuenta.Depositar(0); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MontoNoValido] {ex.Message}");
            }

            
            try
            {
                cuenta.Estado = Estado.Inactiva;
                cuenta.Depositar(100); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CuentaNoActiva] {ex.Message.Replace("{Estado}", cuenta.Estado.ToString())}");
            }

            finally
            {
                cuenta.Estado = Estado.Activa; 
            }

            
            try
            {
                cuenta.Retirar(10_000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SaldoInsuficiente] {ex.Message}");
            }
        }

        Console.WriteLine("\n--- ESTADO FINAL DE LAS CUENTAS ---");

        
        foreach (var cuenta in cuentas)
        {
            var resumen = new
            {
                cuenta.Numero,
                Tipo = cuenta.Tipo.ToString(),
                Estado = cuenta.Estado.ToString(),
                cuenta.Saldo
            };

            Console.WriteLine($"Cuenta: {resumen.Numero}, Tipo: {resumen.Tipo}, Estado: {resumen.Estado}, Saldo: {resumen.Saldo:C}");
        }
    }
}
