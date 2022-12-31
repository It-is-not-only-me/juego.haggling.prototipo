using UnityEngine;

namespace Haggling
{
    [CreateAssetMenu(fileName = "Datos de inventario", menuName = "Haggling/Configuracion/Datos de inventario")]
    public class DatosInventarioSO : ScriptableObject
    {
        [SerializeField] private int _cantidadSlots;
        [SerializeField] private EventoObjeto _agregarObjeto, _sacarObjeto;

        public int CantidadSlots { get => _cantidadSlots; }

        public EventoObjeto AgregarObjeto { get => _agregarObjeto; }

        public EventoObjeto SacarObjeto { get => _sacarObjeto; }
    }
}