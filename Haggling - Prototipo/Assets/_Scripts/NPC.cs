using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Haggling
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] private DatosPersonaSO _datosPersona;
        [SerializeField] private ConfiguracionInventarioSO _datosInventario;

        private Persona _persona;
        private List<IObjeto> _inventario;

        private void Awake()
        {
            _persona = new Persona(_datosPersona.Nombre, _datosPersona.Trabajo);
            _inventario = new List<IObjeto>();

            for (int i = 0; i < _datosPersona.Objetos.Count && i < _datosInventario.CantidadSlots; i++)
            {
                _inventario.Add(_datosPersona.Objetos[i]);
            }
        }

        private void OnEnable()
        {
            if (_datosInventario.AgregarObjeto != null)
                _datosInventario.AgregarObjeto.Evento += Agregar;

            if (_datosInventario.SacarObjeto != null)
                _datosInventario.SacarObjeto.Evento += Sacar;
        }

        private void OnDisable()
        {
            if (_datosInventario.AgregarObjeto != null)
                _datosInventario.AgregarObjeto.Evento -= Agregar;

            if (_datosInventario.SacarObjeto != null)
                _datosInventario.SacarObjeto.Evento -= Sacar;
        }

        private void Agregar(IObjeto objeto)
        {
            if (_inventario.Count >= _datosInventario.CantidadSlots)
                return;

            _inventario.Add(objeto);
        }

        private void Sacar(IObjeto objeto)
        {
            if (_inventario.Count <= 0)
                return;

            _inventario.Remove(objeto);
        }
    }
}
