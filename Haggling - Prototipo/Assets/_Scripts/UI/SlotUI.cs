using Haggling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotUI : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject suelta = eventData.pointerDrag;
        if (!suelta.TryGetComponent(out ItemUI item))
            return;

        item.SetearNuevoPadre(this);
    }
}
