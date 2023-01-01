using System;
using System.Collections.Generic;

namespace Haggling
{
    public class NegociarNPC : INegociar
    {
        private Persona _persona;
        private int _rangoAceptable;

        public NegociarNPC(Persona persona, int rangoAceptable)
        {
            _persona = persona;
            _rangoAceptable = rangoAceptable;   
        }

        public INegociar.Estado HacerNegocios(IInventario inventarioPropio, IInventario mesaPropia, IInventario mesaOtro, IInventario inventarioOtro)
        {
            OperacionPrecioTotal operacionPrecio = new OperacionPrecioTotal(_persona);
            mesaPropia.AplicarOperacion(operacionPrecio);

            int precioPropio = operacionPrecio.Precio;

            operacionPrecio.Reinicializar(_persona);
            mesaOtro.AplicarOperacion(operacionPrecio);

            int precioOtro = operacionPrecio.Precio;

            if (EnRangoAceptable(precioPropio, precioOtro))
                return INegociar.Estado.Satisfecho;

            int cantidadElementos = mesaPropia.CapacidadTotal - mesaPropia.CantidadElementos;

            if (cantidadElementos <= 0)
                return INegociar.Estado.Rechazar;

            OperacionObjetosOrdenadosDeMenosAMayor operacionLista = new OperacionObjetosOrdenadosDeMenosAMayor(_persona);
            inventarioPropio.AplicarOperacion(operacionLista);

            List<Tuple<int, IObjeto>> objetosPropios = operacionLista.Objetos;
            List<Tuple<int, IObjeto>> moverObjetos = new List<Tuple<int, IObjeto>>();

            foreach (Tuple<int, IObjeto> objetoPrecio in objetosPropios)
            {
                if (moverObjetos.Count >= cantidadElementos)
                {
                    precioPropio -= moverObjetos[0].Item1;
                    moverObjetos.RemoveAt(0);
                }

                moverObjetos.Add(objetoPrecio);
                precioPropio += objetoPrecio.Item1;

                if (EnRangoAceptable(precioPropio, precioOtro))
                    break;
            }
            
            return INegociar.Estado.Seguir;
        }

        private bool EnRangoAceptable(int precioPropio, int precioOtro)
        {
            return precioOtro - _rangoAceptable < precioPropio;
        }
    }
}
