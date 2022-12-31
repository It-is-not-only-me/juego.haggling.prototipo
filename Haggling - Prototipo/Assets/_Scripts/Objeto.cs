namespace Haggling
{
    public class Objeto
    {
        private string _nombre;
        private ITag[] _tags;
        private int _precio;

        public Objeto(string nombre, ITag[] tags, int precio)
        {
            _nombre = nombre;
            _tags = tags;
            _precio = precio;
        }

        public string Nombre { get => _nombre; }

        public int PrecioBase() => _precio;

        public bool TieneVinculoConTag(ITag tag)
        {
            bool tieneVinculo = false;
            foreach (ITag tagActual in _tags)
                tieneVinculo |= tag.TieneRelacionCon(tagActual);
            return tieneVinculo;
        }
    }
}
