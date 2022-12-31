using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image _imagen;


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
        _imagen.raycastTarget = true;
    }

    public void SetearNuevoPadre(SlotUI nuevoPadre)
    {
        _padre = nuevoPadre;
        _padreTransform = _padre.transform;
    }
}
