namespace Haggling
{
    public interface IObjeto
    {
        public string Nombre { get; }

        public int PrecioBase { get; }

        public bool TieneVinculoConTag(ITag tag);
    }
}
