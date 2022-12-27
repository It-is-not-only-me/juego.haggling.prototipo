using System.Collections.Generic;

public class InventarioLimitado : IInventario
{
    private List<IObjeto> _objetos;
    private int _cantidadMaxima;

    public InventarioLimitado(int cantidadMaxima)
    {
        _objetos = new List<IObjeto>();
        _cantidadMaxima = cantidadMaxima;
    }

    private int CantidadElementos { get => _objetos.Count; }

    public bool AgregarObjeto(IObjeto objeto)
    {
        if (CantidadElementos >= _cantidadMaxima)
            return false;

        _objetos.Add(objeto);
        return true;
    }

    public bool SacarObjeto(IObjeto objeto)
    {
        return _objetos.Remove(objeto);
    }
}
