using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Haggling
{
    public class PersonaBehaviour : MonoBehaviour
    {
        [SerializeField] private EventoObjeto _agregarObjetoInventario;

        [Space]

        [SerializeField] private DatosPersonaSO _datosPersona;
        [SerializeField] private ConfiguracionInventarioSO _datosInventario;

        private Persona _persona;
        private List<IObjeto> _inventario;

        private void Start()
        {
            _persona = new Persona(_datosPersona.Nombre, _datosPersona.Trabajo);
            _inventario = new List<IObjeto>();

            for (int i = 0; i < _datosPersona.Objetos.Count && i < _datosInventario.CantidadSlots; i++)
            {
                IObjeto objeto = _datosPersona.Objetos[i];
                _inventario.Add(objeto);
                _agregarObjetoInventario?.Invoke(objeto);
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
