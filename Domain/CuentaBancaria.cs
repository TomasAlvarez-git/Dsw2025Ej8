namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public TipoCuenta Tipo { get; private set; }
    public string Numero { get; private set; }
    public decimal Saldo { get; protected set;  }
    protected Estado Estado { get; set; }
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
     

    public void Depositar(decimal monto)
    {

    }

    public void Retirar(decimal monto)
    {


    }
}
