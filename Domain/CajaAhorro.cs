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
            _saldo += monto;
        }

        new public void Retirar(decimal monto)
        {
            if (monto > _saldo)
            {
                throw new Exception("No se puede retirar más de lo que hay en la cuenta");
            }
            _saldo -= monto;
        }

        public void AplicarInteres()
        {

            _saldo += _saldo * _tasaDeInteres;

        }
    }
}
