using System.Collections.Generic;

public class Persona : IPersona
{
    List<IPreferencia> _preferencias;

    public Persona(List<IPreferencia> preferencias)
    {
        _preferencias = preferencias;
    }

    public int PrecioSubjetivo(IObjeto objeto)
    {
        int precioSubjetivo = objeto.PrecioBase;

        foreach (IPreferencia preferencia in _preferencias)
            precioSubjetivo = preferencia.ModificarPrecio(precioSubjetivo, objeto);

        return precioSubjetivo;
    }
}
