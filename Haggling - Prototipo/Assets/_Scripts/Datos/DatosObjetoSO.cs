using System.Collections.Generic;
using UnityEngine;

namespace Haggling
{
    [CreateAssetMenu(fileName = "Objeto", menuName = "Haggling/Datos/Objeto")]
    public class DatosObjetoSO : ScriptableObject, IObjeto
    {
        [SerializeField] private string _nombre;
        [SerializeField] private int _precio;
        [SerializeField] private List<DatosTagSO> _tags;

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
