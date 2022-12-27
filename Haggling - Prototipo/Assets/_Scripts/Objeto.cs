using System.Collections;
using UnityEngine;

public class CaracteristicasDeObjeto : ScriptableObject
{
    [SerializeField] private int _precioBase;

    public int PrecioBase { get => _precioBase; }

}

public class Objeto : IObjeto
{
    private CaracteristicasDeObjeto _caracteristicas;

    public Objeto(CaracteristicasDeObjeto caracteristicas)
    {
        _caracteristicas = caracteristicas;
    }

    public int PrecioBase => _caracteristicas.PrecioBase;
}

public interface IObjeto
{
    public int PrecioBase { get; }
}

public class Promesa : IObjeto
{
    private IObjeto _objeto;

    public Promesa(IObjeto objeto)
    {
        _objeto = objeto;
    }

    public int PrecioBase => _objeto.PrecioBase;
}
