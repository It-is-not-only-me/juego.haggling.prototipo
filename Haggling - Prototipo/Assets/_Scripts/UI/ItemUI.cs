using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class ItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image _imagen;

    [Space]

    [SerializeField] private ObjetoSO _objeto;
    
  
    private RectTransform _posicion;

    private SlotUI _padre;
    private Transform _padreTransform;

    private void Awake()
    {
        _posicion = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _imagen.raycastTarget = false;
        _padre?.SacarObjeto(_objeto);
        _padreTransform = transform.parent;
        
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        float factorDeEscala = (_canvas == null) ? 1 : _canvas.scaleFactor;
        _posicion.anchoredPosition += eventData.delta / factorDeEscala;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_padreTransform);
        _padre?.AgregarObjeto(_objeto);
        _imagen.raycastTarget = true;
    }

    public void SetearNuevoPadre(SlotUI nuevoPadre)
    {
        _padre = nuevoPadre;
        _padreTransform = _padre.transform;
    }
}
