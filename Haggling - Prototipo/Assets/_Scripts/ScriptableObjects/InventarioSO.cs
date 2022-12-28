using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioSO : ScriptableObject
{
    [SerializeField] private EventoObjeto _sacarObjeto, _agregarObjeto;

    [SerializeField] private int _cantidadMaxima;
    private IInventario _inventario;

    private void OnEnable()
    {
        _inventario = new InventarioLimitado(_cantidadMaxima);

        _sacarObjeto.Evento += SacarObjeto;
        _agregarObjeto.Evento += AgregarObjeto; 
    }

    private void OnDisable()
    {
        _sacarObjeto.Evento -= SacarObjeto;
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
