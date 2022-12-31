using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Haggling;

public class HagglingTest
{
    public struct ObjetoTest : IObjeto
    {
        private string _nombre;
        private ITag[] _tags;
        private int _precio;

        public ObjetoTest(string nombre, ITag[] tags, int precio)
        {
            _nombre = nombre;
            _tags = tags;
            _precio = precio;
        }

        public string Nombre { get => _nombre; }

        public int PrecioBase => _precio;

        public bool TieneVinculoConTag(ITag tag)
        {
            bool tieneVinculo = false;
            foreach (ITag tagActual in _tags)
                tieneVinculo |= tag.TieneRelacionCon(tagActual);
            return tieneVinculo;
        }
    }

    public struct TagTest : ITag
    {
        private static int _contador = 0;

        private int _id;
        private List<ITag> _relacionadas;

        public TagTest(List<ITag> relacionadas)
        {
            _id = _contador++;

            _relacionadas = relacionadas;
            if (_relacionadas == null)
                _relacionadas = new List<ITag>();
        }

        public bool TieneRelacionCon(ITag tag)
        {
            bool tieneRelacion = EsIgual(tag);
            if (tieneRelacion)
                return true;            

            for (int i = 0; i < _relacionadas.Count; i++)
                tieneRelacion |= _relacionadas[i].TieneRelacionCon(tag);

            return tieneRelacion;
        }

        public bool EsIgual(ITag tag)
        {
            return ((TagTest)tag).EsIgual(this);
        }

        private bool EsIgual(TagTest tag)
        {
            return _id == tag._id;
        }
    }

    public struct TrabajoTest : ITrabajo
    {
        private List<ITag> _preferencias;

        public TrabajoTest(List<ITag> preferencias = null)
        {
            _preferencias = preferencias == null ? new List<ITag>() : preferencias;
        }

        public IEnumerable ObtenerTags()
        {
            foreach (ITag tag in _preferencias)
                yield return tag;
        }
    }

    private ITag _construir, _destruir, _inventar;
    private ITag _crear;
    private ITag _escribir, _dibujar, _cantar;
    private ITag _arte;

    public HagglingTest()
    {
        _construir = new TagTest(null);
        _destruir = new TagTest(null);
        _inventar = new TagTest(null);

        _crear = new TagTest(new List<ITag>
        {
            _construir,
            _destruir,
            _inventar
        });

        _escribir = new TagTest(new List<ITag>
        {
            _crear
        });
        _dibujar = new TagTest(new List<ITag>
        {
            _construir,
            _destruir
        });
        _cantar = new TagTest(new List<ITag>
        {
            _construir,
            _inventar
        });

        _arte = new TagTest(new List<ITag>
        {
            _escribir,
            _dibujar,
            _cantar
        });
    }

    [Test]
    public void Test01PersonaSinTrabajoNoModificaElValor()
    {
        Persona juan = new Persona("Juan", null);

        int precioBase = 20;
        ObjetoTest libro = new ObjetoTest("Martillo", new ITag[2] {
            _construir,
            _destruir
        }, precioBase);

        Assert.AreEqual(precioBase, juan.PrecioSubjetivo(libro));
    }

    [Test]
    public void Test02PersonaConTrabajoAumentaElValorAlTenerVinculo()
    {
        TrabajoTest artista = new TrabajoTest(new List<ITag>
        {
            _arte
        });
        Persona juan = new Persona("Juan", artista);

        int precioBase = 20;
        ObjetoTest libro = new ObjetoTest("Martillo", new ITag[2] {
            _construir,
            _destruir
        }, precioBase);

        Assert.Greater(juan.PrecioSubjetivo(libro), precioBase);
    }
}
