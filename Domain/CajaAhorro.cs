using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CajaAhorro : CuentaBancaria
    {
        public CajaAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, TipoCuenta.CajaDeAhorro, titulares)
        {

        }
        new public void Depositar(decimal monto)
        {
            Saldo += monto;
        }

        new public void Retirar(decimal monto)
        {
            if (monto > Saldo)
            {
                throw new Exception("No se puede retirar más de lo que hay en la cuenta");
            }
            Saldo -= monto;
        }

        public void AplicarInteres()
        {

            Saldo += Saldo * TasaDeInteres;

        }
    }
}
