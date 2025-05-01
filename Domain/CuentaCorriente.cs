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
            _saldo += monto;
        }

        new public void Retirar(decimal monto)
        {
            if (monto > _saldo + _limiteDeDescubierto)
            {
                throw new Exception("No se puede retirar más de lo que hay en la cuenta");
            }
            _saldo -= monto;
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
            }
        }
    }
}
