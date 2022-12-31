using System;
using UnityEngine;

namespace Haggling
{
    [CreateAssetMenu(fileName = "Evento objeto", menuName = "Haggling/Eventos/Evento objeto")]
    public class EventoObjeto : ScriptableObject
    {
        public Action<Objeto> Evento;

        public void Invoke(Objeto objeto) => Evento?.Invoke(objeto);
    }
}
