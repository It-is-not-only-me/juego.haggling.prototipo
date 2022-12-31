using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Haggling
{
    [CreateAssetMenu(fileName = "Tag", menuName = "Haggling/Datos/Tag")]
    public class DatosTagSO : ScriptableObject, ITag
    {
        [SerializeField] private string _nombre;
        [SerializeField] private DatosTagSO[] _relacionadas;

        public bool TieneRelacionCon(ITag tag)
        {
            bool tieneRelacion = EsIgual(tag);
            if (tieneRelacion)
                return true;

            foreach (ITag tagActual in _relacionadas)
                tieneRelacion |= tagActual.TieneRelacionCon(tag);

            return tieneRelacion;
        }

        public bool EsIgual(ITag tag)
        {
            return (tag as DatosTagSO).EsIgual(this);
        }

        private bool EsIgual(DatosTagSO tag)
        {
            return GetInstanceID() == tag.GetInstanceID();
        }
    }
}
