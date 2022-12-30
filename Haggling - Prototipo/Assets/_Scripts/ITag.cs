namespace Haggling
{
    public interface ITag
    {
        public bool TieneRelacionCon(ITag tag);

        public bool EsIgual(ITag tag);
    }
}