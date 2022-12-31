using Haggling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Haggling
{
    public class Persona
    {
        private string _nombre;
        private ITrabajo _trabajo;

        public Persona(string nombre, ITrabajo trabajo)
        {
            _nombre = nombre;
            _trabajo = trabajo;
        }

        public int PrecioSubjetivo(IObjeto objeto)
        {
            int precioFinal = objeto.PrecioBase;
            if (_trabajo == null)
                return precioFinal;

            foreach (ITag tag in ObtenerTags())
            {
                if (!objeto.TieneVinculoConTag(tag))
                    continue;
                precioFinal++;
            }

            return precioFinal;
        }

        private IEnumerable ObtenerTags()
        {
            return _trabajo.ObtenerTags();
        }
    }
}
