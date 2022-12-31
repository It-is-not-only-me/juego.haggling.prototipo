using System;

namespace Haggling
{
    public class LazyDato<TTipo> where TTipo : class
    {
        public TTipo Dato
        {
            get
            {
                if (_dato == null)
                    _dato = _obtenerDato.Invoke();
                return _dato;
            }
        }

        private TTipo _dato;
        private Func<TTipo> _obtenerDato;

        public LazyDato(Func<TTipo> obtenerDato)
        {
            _obtenerDato = obtenerDato;
            _dato = null;
        }

        public void Actualizar() => _dato = null;
    }

}