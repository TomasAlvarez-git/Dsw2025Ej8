using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        private decimal _comision;
        public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, TipoCuenta.CuentaCorriente, titulares)
        {
        }

        new public void Depositar(decimal monto)
        {
            monto -= monto * _comision;
            Saldo += monto;
        }

        new public void Retirar(decimal monto)
        {
            if (monto > Saldo + LimiteDeDescubierto)
            {
                throw new Exception("No se puede retirar más de lo que hay en la cuenta");
            }
            Saldo -= monto;
            if (Saldo < 0)
            {
                Estado = Estado.Suspendida;
            }
        }
    }
}
