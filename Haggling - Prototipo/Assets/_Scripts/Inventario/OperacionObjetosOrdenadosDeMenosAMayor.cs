using System;
using System.Collections.Generic;

namespace Haggling
{
    public class OperacionObjetosOrdenadosDeMenosAMayor : IOperacion
    {
        public List<Tuple<int, IObjeto>> Objetos { get; private set; }
        private Persona _persona;

        public OperacionObjetosOrdenadosDeMenosAMayor(Persona persona)
        {
            _persona = persona;

            Objetos = new List<Tuple<int, IObjeto>>();
        }

        public void Aplicar(IObjeto objeto)
        {
            int precioObjeto = _persona.PrecioSubjetivo(objeto);
            int posicionFinal = 0;

            bool sePudoAgregar = false;

            for (int i = 0; i < Objetos.Count && !sePudoAgregar; i++)
            {
                int precioActual = Objetos[i].Item1;
                posicionFinal = i;
                sePudoAgregar |= precioActual > precioObjeto;
            }

            Objetos.Insert(posicionFinal, new Tuple<int, IObjeto>(precioObjeto, objeto));
        }
    }
}
