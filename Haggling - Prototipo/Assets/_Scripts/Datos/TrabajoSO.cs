using System.Collections;
using UnityEngine;

namespace Haggling
{
    [CreateAssetMenu(fileName = "Trabajo", menuName = "Haggling/Trabajo")]
    public class TrabajoSO : ScriptableObject, ITrabajo
    {
        [SerializeField] private string _nombre;
        [SerializeField] private TagSO[] _preferencias;

        public IEnumerable ObtenerTags()
        {
            foreach (ITag tag in _preferencias)
                yield return tag;
        }
    }
}
