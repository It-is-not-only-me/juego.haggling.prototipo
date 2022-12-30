using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventario", menuName = "Haggling/Inventario")]
public class InventarioSO : ScriptableObject
{
    [SerializeField] private EventoObjeto _sacarObjeto, _agregarObjeto;

    [SerializeField] private int _cantidadMaxima;
    private IInventario _inventario;

    private void OnEnable()
    {
        _inventario = new InventarioLimitado(_cantidadMaxima);

        if (_sacarObjeto != null)
            _sacarObjeto.Evento += SacarObjeto;

        if (_agregarObjeto != null)
            _agregarObjeto.Evento += AgregarObjeto; 
    }

    private void OnDisable()
    {
        if (_sacarObjeto != null)
            _sacarObjeto.Evento -= SacarObjeto;

        if (_agregarObjeto != null)
            _agregarObjeto.Evento -= AgregarObjeto;
    }

    private void AgregarObjeto(IObjeto objeto)
    {
        _inventario.AgregarObjeto(objeto);
    }

    private void SacarObjeto(IObjeto objeto)
    {
        _inventario.SacarObjeto(objeto);
    }
}
