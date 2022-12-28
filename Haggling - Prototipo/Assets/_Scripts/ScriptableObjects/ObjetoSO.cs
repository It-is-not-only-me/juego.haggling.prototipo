using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoSO : ScriptableObject, IObjeto
{
    [SerializeField] private CaracteristicasDeObjeto _caracteristicasDelObjeto;

    private IObjeto _objeto;

    private void OnEnable()
    {
        _objeto = new Objeto(new List<ICaracteristica>(), _caracteristicasDelObjeto);
    }

    public int PrecioBase => _objeto.PrecioBase;

    public CaracteristicasDeObjeto Caracteristicas => _objeto.Caracteristicas;

    public int PrecioSubjetivo(IPersona persona) => _objeto.PrecioSubjetivo(persona);

    public bool TieneCaracteristica(ICaracteristica caracteristica) => _objeto.TieneCaracteristica(caracteristica);
}
