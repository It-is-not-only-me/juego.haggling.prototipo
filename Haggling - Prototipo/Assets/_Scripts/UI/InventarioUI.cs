using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Haggling
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class InventarioUI : MonoBehaviour
    {
        [SerializeField] private GameObject _slotPrefav;

        [Space]

        [SerializeField] private ConfiguracionInventarioSO _datosInventario;
        [SerializeField] private ConfiguracionSlotSO _datos;

        private GridLayoutGroup _layout = null;
        private GridLayoutGroup _getLayout
        {
            get
            {
                if (_layout == null)
                    _layout = GetComponent<GridLayoutGroup>();
                return _layout;
            }
        }

        private List<SlotUI> _slots = new List<SlotUI>();

        private void Awake()
        {
            GenerarInventario();
        }

        [ContextMenu("Recalcular inventario")]
        private void GenerarInventario()
        {
            EliminarHijos();
            _getLayout.cellSize = _datos.Dimensiones;
            _getLayout.spacing = _datos.Espaciado;
            _getLayout.childAlignment = _datos.PosicionDeSlot;

            for (int i = 0; i < _datosInventario.CantidadSlots; i++)
            {
                GameObject slotGameObject = Instantiate(_slotPrefav, transform);
                slotGameObject.name = $"Slot ({i})";

                SlotUI slot = slotGameObject.GetComponent<SlotUI>();
                slot.Inicializar(_datosInventario.AgregarObjeto, _datosInventario.SacarObjeto);
                _slots.Add(slot);
            }
        }

        public void AgregarItem(ItemUI item)
        {
            bool sePudoAgregar = false;
            for (int i = 0; i < _slots.Count && !sePudoAgregar; i++)
                sePudoAgregar |= _slots[i].AgregarItem(item);
        }

        public void SacarObjeto(IObjeto objeto)
        {
            bool sePuedeSacar = false;
            for (int i = 0; i < _slots.Count && !sePuedeSacar; i++)
                sePuedeSacar |= _slots[i].SacarObjetoDeItem(objeto);
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
            _slots.Clear();
        }

    }

}