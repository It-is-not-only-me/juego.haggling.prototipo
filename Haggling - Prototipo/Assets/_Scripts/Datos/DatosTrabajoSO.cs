using System.Collections;
using UnityEngine;

namespace Haggling
{
    [CreateAssetMenu(fileName = "Trabajo", menuName = "Haggling/Datos/Trabajo")]
    public class DatosTrabajoSO : ScriptableObject, ITrabajo
    {
        [SerializeField] private string _nombre;
        [SerializeField] private DatosTagSO[] _preferencias;

        public IEnumerable ObtenerTags()
        {
            foreach (ITag tag in _preferencias)
                yield return tag;
        }
    }
}
