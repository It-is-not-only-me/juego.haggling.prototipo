using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private EventoObjeto _agregarObjeto, _sacarObjeto;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject suelta = eventData.pointerDrag;
        if (!suelta.TryGetComponent(out ItemUI item))
            return;

        item.SetearNuevoPadre(this);
    }

    public void AgregarObjeto(IObjeto objeto) => _agregarObjeto?.Invoke(objeto);

    public void SacarObjeto(IObjeto objeto) => _sacarObjeto?.Invoke(objeto);
}
