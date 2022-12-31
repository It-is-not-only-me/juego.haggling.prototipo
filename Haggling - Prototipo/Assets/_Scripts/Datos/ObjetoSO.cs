using UnityEngine;

namespace Haggling
{
    [CreateAssetMenu(fileName = "Objeto", menuName = "Haggling/Objeto")]
    public class ObjetoSO : ScriptableObject, IObjeto
    {
        [SerializeField] private string _nombre;
        [SerializeField] private ITag[] _tags;
        [SerializeField] private int _precio;

        public string Nombre { get => _nombre; }

        public int PrecioBase => _precio;

        public bool TieneVinculoConTag(ITag tag)
        {
            bool tieneVinculo = false;
            foreach (ITag tagActual in _tags)
                tieneVinculo |= tag.TieneRelacionCon(tagActual);
            return tieneVinculo;
        }
    }
}
