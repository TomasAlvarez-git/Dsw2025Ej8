namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public class MontoNoValido : Exception
    {
        public MontoNoValido()
            : base("El monto ingresado no es valido para la operacion solicitada.")
        {
        }
    }

    public class CuentaNoActiva : Exception
    {
        public CuentaNoActiva(Estado estadoActual)
            : base($"No se puede operar con la cuenta {estadoActual}")
        {

        }
    }

    public class SaldoInsuficiente : Exception
    {
        public SaldoInsuficiente(string numero)
            : base($"La cuenta nro {numero} no cuenta con saldo para la operación solicitada. Fue Suspendida")
        {

        }
    }

    public TipoCuenta Tipo { get; private set; }
    public string Numero { get; private set; }
    public decimal Saldo { get; protected set;  }
    public Estado Estado { get; set; }
    protected decimal TasaDeInteres { get; set; } = 1.5M;
    protected decimal LimiteDeDescubierto { get; set; } = 500M;
    private decimal Comision { get; set; }
    public string[] Titulares { get; private set; }

    public CuentaBancaria(string numero, decimal saldo, TipoCuenta tipo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Tipo = tipo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }
     

    public virtual void Depositar(decimal monto)
    {

    }

    public virtual void Retirar(decimal monto)
    {


    }
}
