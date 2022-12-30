using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Caracteristica", menuName = "Haggling/Caracteristica")]
public class Caracteristica : ScriptableObject, ICaracteristica
{
    [SerializeField] private List<Caracteristica> _caracteristicas = new List<Caracteristica>();

    public bool EsIgual(ICaracteristica caracteristica)
    {
        if (caracteristica == (ICaracteristica)this)
            return true;

        bool esIgual = false;
        foreach (Caracteristica caracteristicaActual in _caracteristicas)
            esIgual |= caracteristicaActual.EsIgual(caracteristica);
        return esIgual;
    }
}
