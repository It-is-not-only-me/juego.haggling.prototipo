using System.Collections.Generic;

public class InventarioIlimitado : IInventario
{
    private List<IObjeto> _objetos;

    public InventarioIlimitado()
    {
        _objetos = new List<IObjeto>();
    }

    public bool AgregarObjeto(IObjeto objeto)
    {
        _objetos.Add(objeto);
        return true;
    }

    public bool SacarObjeto(IObjeto objeto)
    {
        return _objetos.Remove(objeto);
    }
}