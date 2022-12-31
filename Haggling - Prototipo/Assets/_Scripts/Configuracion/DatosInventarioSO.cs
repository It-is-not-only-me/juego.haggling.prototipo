using UnityEngine;

namespace Haggling
{
    [CreateAssetMenu(fileName = "Datos de inventario", menuName = "Haggling/Configuracion/Datos de inventario")]
    public class DatosInventarioSO : ScriptableObject
    {
        [SerializeField] private int _cantidadSlots;

        public int CantidadSlots { get => _cantidadSlots; }
    }
}