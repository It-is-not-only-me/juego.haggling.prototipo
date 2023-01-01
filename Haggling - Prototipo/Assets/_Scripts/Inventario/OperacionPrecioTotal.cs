namespace Haggling
{
    public class OperacionPrecioTotal : IOperacion
    {
        public int Precio { get; private set; }

        private Persona _persona;

        public OperacionPrecioTotal(Persona persona) => Reinicializar(persona);

        public void Aplicar(IObjeto objeto)
        {
            Precio += _persona.PrecioSubjetivo(objeto);
        }

        public void Reinicializar(Persona persona)
        {
            _persona = persona;
            Precio = 0;
        }
    }
}
