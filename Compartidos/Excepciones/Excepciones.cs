namespace Compartidos.Excepciones;

public class RegistroNoEncontrado : Exception
{
    public RegistroNoEncontrado() : base() { }

    public RegistroNoEncontrado(string mensaje) : base(mensaje) { }
}

public class Error : Exception
{
    public Error() : base() { }

    public Error(string mensaje) : base(mensaje) { }
}