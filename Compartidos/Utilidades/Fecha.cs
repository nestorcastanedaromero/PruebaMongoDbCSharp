namespace Compartidos.Utilidades;

public class Fecha : IFecha
{
    private DateTime _fecha = DateTime.Now;

    public DateTime Hoy() => _fecha;

    public Fecha(int anio, byte mes, int dia)
    {
        _fecha = new DateTime(anio, mes, dia);
    }

    public Fecha() { }
}

