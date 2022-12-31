using Haggling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Haggling
{
    public class SlotUI : MonoBehaviour, IDropHandler
    {
        [SerializeField] private EventoObjeto _agregarObjeto, _sacarObjeto;

        [SerializeField] private ItemUI _itemPrefab;

        public void Inicializar(EventoObjeto agregarObjeto, EventoObjeto sacarObjeto)
        {
            _agregarObjeto = agregarObjeto;
            _sacarObjeto = sacarObjeto;
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject suelta = eventData.pointerDrag;
            if (!suelta.TryGetComponent(out ItemUI item))
                return;

            AgregarItem(item);
        }

        public void CrearObjeto(IObjeto objeto)
        {
            ItemUI item = Instantiate(_itemPrefab);
            item.Inicializar(objeto);
            item.transform.name = objeto.Nombre;
            AgregarItem(item);
        }

        public void EliminarObjeto()
        {
            while (transform.childCount > 0)
                Destroy(transform.GetChild(0));
        }

        private void AgregarItem(ItemUI item)
        {
            item.SetearNuevoPadre(this);
        }

        public void AgregarObjeto(IObjeto objeto) => _agregarObjeto?.Invoke(objeto);

        public void SacarObjeto(IObjeto objeto) => _sacarObjeto?.Invoke(objeto);
    }
}
