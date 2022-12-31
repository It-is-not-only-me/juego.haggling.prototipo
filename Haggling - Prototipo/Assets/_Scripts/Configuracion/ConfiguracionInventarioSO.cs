using UnityEngine;

namespace Haggling
{
    [CreateAssetMenu(fileName = "Configuracion de inventario", menuName = "Haggling/Configuracion/Configuracion de inventario")]
    public class ConfiguracionInventarioSO : ScriptableObject
    {
        [SerializeField] private int _cantidadSlots;
        [SerializeField] private EventoObjeto _agregarObjeto, _sacarObjeto;

        public int CantidadSlots { get => _cantidadSlots; }

        public EventoObjeto AgregarObjeto { get => _agregarObjeto; }

        public EventoObjeto SacarObjeto { get => _sacarObjeto; }
    }
}