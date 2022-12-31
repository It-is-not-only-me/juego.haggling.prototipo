using System.Collections.Generic;
using UnityEngine;

namespace Haggling
{
    public class Pila<TTipo> where TTipo : class
    {
        private List<TTipo> _elementos;
        private int _contadorActual;

        public Pila()
        {
            _elementos = new List<TTipo>();
            _contadorActual = 0;
        }

        public TTipo Elemento { get => _elementos[_contadorActual]; }

        public void Avanzar() => _contadorActual = Mathf.Min(_contadorActual + 1, _elementos.Count);

        public void Retroceder() => _contadorActual = Mathf.Max(_contadorActual - 1, 0);

        public void Agregar(TTipo valor)
        {
            _elementos.Add(valor);
        }

        public void Clear()
        {
            _contadorActual = 0;
            _elementos.Clear();
        }
    }

}