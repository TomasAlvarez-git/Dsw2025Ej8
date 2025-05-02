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

        private void VerificarCuentaActiva()
        {
            if (Estado != Estado.Activa)
            {
                throw new CuentaNoActiva(Estado);
            }
        }

        public override void Depositar(decimal monto)
        {
            VerificarCuentaActiva();

            if (monto <= 0)
            {
                throw new MontoNoValido();
            }

            monto -= monto * _comision;
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            VerificarCuentaActiva();

            if (monto <= 0)
            {
                throw new MontoNoValido();
            }


            if (monto > Saldo + LimiteDeDescubierto)
            {
                throw new SaldoInsuficiente(Numero);
            }
            Saldo -= monto;

            if (Saldo < 0)
            {
                Estado = Estado.Suspendida;

                throw new SaldoInsuficiente(Numero);
                
            }
        }
    }
}
