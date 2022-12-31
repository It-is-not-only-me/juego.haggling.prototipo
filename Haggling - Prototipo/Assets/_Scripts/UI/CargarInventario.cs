using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Haggling
{
    [RequireComponent(typeof(InventarioUI))]
    public class CargarInventario : MonoBehaviour
    {
        [SerializeField] private EventoObjeto _agregarObjeto;

        [Space]

        [SerializeField] private Canvas _canvas;
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

        private void OnEnable()
        {
            if (_agregarObjeto != null)
                _agregarObjeto.Evento += AgregarObjeto;
        }

        private void OnDisable()
        {
            if (_agregarObjeto != null)
                _agregarObjeto.Evento -= AgregarObjeto;
        }

        public void AgregarObjeto(IObjeto objeto)
        {
            GameObject itemGameObject = Instantiate(_itemPrefab);
            itemGameObject.name = objeto.Nombre;

            ItemUI item = itemGameObject.GetComponent<ItemUI>();
            item.Inicializar(objeto, _canvas);
            _getInventario.AgregarItem(item);
        }
    }
}