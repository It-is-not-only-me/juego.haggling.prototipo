using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Haggling
{
    [RequireComponent(typeof(RectTransform), typeof(Image))]
    public class ItemUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Canvas _canvas;
        
        private Image _imagen;
        private RectTransform _posicion;

        private IObjeto _objeto;

        private SlotUI _padre;
        private Transform _padreTransform;

        private void Awake()
        {
            _posicion = GetComponent<RectTransform>();
            _imagen = GetComponent<Image>();
        }

        public void Inicializar(IObjeto objeto, Canvas canvas)
        {
            _objeto = objeto;
            _canvas = canvas;
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
            VincularAPadre();
            _padre?.AgregarObjeto(_objeto);
            _imagen.raycastTarget = true;
        }

        public void SetearNuevoPadre(SlotUI nuevoPadre)
        {
            _padre = nuevoPadre;
            _padreTransform = _padre.transform;
        }

        public void VincularAPadre()
        {
            transform.SetParent(_padreTransform);
        }
    }

}