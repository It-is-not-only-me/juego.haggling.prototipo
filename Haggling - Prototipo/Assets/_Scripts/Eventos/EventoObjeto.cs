using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Evento objeto", menuName = "Haggling/Eventos/Evento objeto")]
public class EventoObjeto : ScriptableObject
{
    public Action<IObjeto> Evento;

    public void Invoke(IObjeto objeto) => Evento?.Invoke(objeto);
}
