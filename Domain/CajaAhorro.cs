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
            Saldo += monto;
        }

        public override void Retirar(decimal monto)
        {
            VerificarCuentaActiva();

            if (monto <= 0)
            {
                throw new MontoNoValido();
            }

            if (monto > Saldo)
            {
                Estado = Estado.Suspendida;

                throw new SaldoInsuficiente(Numero);
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
