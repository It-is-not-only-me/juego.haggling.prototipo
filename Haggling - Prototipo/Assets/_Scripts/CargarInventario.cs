using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Haggling
{
    [RequireComponent(typeof(InventarioUI))]
    public class CargarInventario : MonoBehaviour
    {
        [SerializeField] private DatosPersonaSO _datosPersona;
        [SerializeField] private GameObject _itemPrefab;

        private InventarioUI _inventario = null;
        private InventarioUI _getInventario
        {
            get
            {
                if (_inventario == null)
                    _inventario = GetComponent<InventarioUI>();
                return _inventario;
            }
        }

        private void Start()
        {
            foreach (DatosObjetoSO objeto in _datosPersona.Objetos)
            {
                GameObject itemGameObject = Instantiate(_itemPrefab);
                itemGameObject.name = objeto.Nombre;

                ItemUI item = itemGameObject.GetComponent<ItemUI>();
                item.Inicializar(objeto);
                _getInventario.AgregarItem(item);
            }
        }
    }
}