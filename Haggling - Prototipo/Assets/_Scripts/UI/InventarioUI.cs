using UnityEngine;
using UnityEngine.UI;

namespace Haggling
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class InventarioUI : MonoBehaviour
    {
        [SerializeField] private GameObject _slotPrefav;

        [Space]

        [SerializeField] private DatosInventarioSO _datosInventario;
        [SerializeField] private DatosSlotSO _datos;

        private LazyDato<GridLayoutGroup> _layout => new LazyDato<GridLayoutGroup>(() => GetComponent<GridLayoutGroup>());

        private LazyDato<Pila<SlotUI>> _slots = new LazyDato<Pila<SlotUI>>(() => new Pila<SlotUI>());

        private void Start()
        {
            GenerarInventario();
        }

        public void AgregarObjeto(ObjetoSO objeto)
        {
            _slots.Dato.Elemento.AgregarObjeto(objeto);
            _slots.Dato.Avanzar();
        }

        public void SacarOBjeto()
        {
            _slots.Dato.Elemento.EliminarObjeto();
            _slots.Dato.Retroceder();
        }

        [ContextMenu("Recalcular inventario")]
        private void GenerarInventario()
        {
            EliminarHijos();
            GridLayoutGroup layout = _layout.Dato;
            layout.cellSize = _datos.Dimensiones;
            layout.spacing = _datos.Espaciado;
            layout.childAlignment = _datos.PosicionDeSlot;

            for (int i = 0; i < _datosInventario.CantidadSlots; i++)
            {
                GameObject slotGameObject = Instantiate(_slotPrefav, transform);
                slotGameObject.name = $"Slot ({i})";

                SlotUI slot = slotGameObject.GetComponent<SlotUI>();
                slot.Inicializar(_datosInventario.AgregarObjeto, _datosInventario.SacarObjeto);
                _slots.Dato.Agregar(slot);
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
            _slots.Dato.Clear();
        }

    }

}