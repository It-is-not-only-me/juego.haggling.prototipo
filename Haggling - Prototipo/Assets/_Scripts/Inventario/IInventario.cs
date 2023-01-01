namespace Haggling
{
    public interface IInventario
    {
        public int CantidadElementos { get; }
        public int CapacidadTotal { get; }

        public bool AgregarObjeto(IObjeto objeto);
        public bool SacarObjeto(IObjeto objeto);
        public void AplicarOperacion(IOperacion operacion);
    }
}
