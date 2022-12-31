using System.Collections.Generic;
using UnityEngine;

namespace Haggling
{
    [CreateAssetMenu(fileName = "Persona", menuName = "Haggling/Datos/Persona")]
    public class DatosPersonaSO : ScriptableObject
    {
        [SerializeField] private string _nombre;
        [SerializeField] private DatosTrabajoSO _trabajo;
        [SerializeField] private List<DatosObjetoSO> _objetos;

        public string Nombre { get => _nombre; }
        public ITrabajo Trabajo { get => _trabajo; }
        public List<DatosObjetoSO> Objetos { get => _objetos; }
    }
}
