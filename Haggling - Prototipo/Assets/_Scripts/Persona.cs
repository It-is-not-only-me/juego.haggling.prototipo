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

    public interface INegociar
    {
        /// <summary>
        ///     La intención es ver el estado actual de la transaccion y determinar que hacer despues, esto puede ser:
        ///      * Agregar un elemento propio a la mesa del otro, o la propia
        ///      * Sacar un elemento propio o del otro
        ///      * O determinar que todo esta perfecto
        /// </summary>
        /// <returns>
        ///     Devuelve true si esta todo perfecto o false si se hizo alguna modificacion
        /// </returns>
        public bool HacerNegocios(IInventario inventarioPropio, IInventario mesaPropia, IInventario mesaOtro, IInventario inventarioOtro);
    }

    public interface IInventario
    {
        public bool AgregarObjeto(IObjeto objeto);

        public bool SacarObjeto(IObjeto objeto);

        
    }



}
