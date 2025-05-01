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

        private void VerificarCuentaActiva()
        {
            if (Estado != Estado.Activa)
            {
                throw new CuentaNoActiva();
            }
        }
        new public void Depositar(decimal monto)
        {
            VerificarCuentaActiva();

            if (monto <= 0)
            {
                throw new MontoNoValido();
            }
            Saldo += monto;
        }

        new public void Retirar(decimal monto)
        {
            VerificarCuentaActiva();

            if (monto <= 0)
            {
                throw new MontoNoValido();
            }

            if (monto > Saldo)
            {
                Estado = Estado.Suspendida;

                throw new SaldoInsuficiente();
            }
            Saldo -= monto;
        }

        public void AplicarInteres()
        {
            VerificarCuentaActiva();

            Saldo += Saldo * TasaDeInteres;

        }
    }
}
