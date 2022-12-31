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

        private bool _tieneItem = false;

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

            item.SetearNuevoPadre(this);
        }

        public bool AgregarItem(ItemUI item)
        {
            if (_tieneItem)
                return false;

            item.SetearNuevoPadre(this);
            item.VincularAPadre();
            _tieneItem = true;
            return true;
        }

        public void AgregarObjeto(IObjeto objeto) => _agregarObjeto?.Invoke(objeto);

        public void SacarObjeto(IObjeto objeto) => _sacarObjeto?.Invoke(objeto);
    }
}
