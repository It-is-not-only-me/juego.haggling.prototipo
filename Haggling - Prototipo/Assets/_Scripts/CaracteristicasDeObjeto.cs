using UnityEngine;

public class CaracteristicasDeObjeto : ScriptableObject
{
    [SerializeField] private int _precioBase;

    public int PrecioBase { get => _precioBase; }

}
