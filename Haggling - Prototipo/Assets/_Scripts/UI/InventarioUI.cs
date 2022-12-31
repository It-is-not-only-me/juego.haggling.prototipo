using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazyDato<TTipo> where TTipo : class
{
    public TTipo Dato 
    { 
        get
        {
            if (_dato == null)
                _dato = _obtenerDato.Invoke();
            return _dato;
        }
    }

    private TTipo _dato;
    private Func<TTipo> _obtenerDato;

    public LazyDato(Func<TTipo> obtenerDato)
    {
        _obtenerDato = obtenerDato;
        _dato = null;
    }

    public void Actualizar() => _dato = null;
}

[RequireComponent(typeof(GridLayoutGroup))]
public class InventarioUI : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefav;

    [Space]

    [SerializeField] private int _cantidadSlots;
    [SerializeField] private DatosSlotSO _datos;

    private LazyDato<GridLayoutGroup> _layout => new LazyDato<GridLayoutGroup>( () => GetComponent<GridLayoutGroup>() );

    private void Start()
    {
        GenerarInventario();
    }

    [ContextMenu("Recalcular inventario")]
    private void GenerarInventario()
    {
        EliminarHijos();
        GridLayoutGroup layout = _layout.Dato;
        layout.cellSize = _datos.Dimensiones;
        layout.spacing = _datos.Espaciado;
        layout.childAlignment = _datos.PosicionDeSlot;

        for (int i = 0; i < _cantidadSlots; i++)
        {
            GameObject slot = Instantiate(_slotPrefav, transform);
            slot.name = $"Slot ({i})";
        }
    }

    private void EliminarHijos()
    {
        Transform transformacion = transform;
        while (transform.childCount > 0)
        {
            if (Application.isEditor)
                DestroyImmediate(transformacion.GetChild(0).gameObject);
            else
                Destroy(transformacion.GetChild(0).gameObject);
        }
    }

}
