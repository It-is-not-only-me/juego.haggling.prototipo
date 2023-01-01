namespace Haggling
{
    public interface INegociar
    {
        public enum Estado
        {
            Seguir,
            Rechazar,
            Satisfecho
        }

        /// <summary>
        ///     La intención es ver el estado actual de la transaccion y determinar que hacer despues, esto puede ser:
        ///      * Agregar un elemento propio a la mesa del otro, o la propia
        ///      * Sacar un elemento propio o del otro
        ///      * O determinar que todo esta perfecto
        /// </summary>
        /// <returns>
        ///     Devuelve true si esta todo perfecto o false si se hizo alguna modificacion
        /// </returns>
        public Estado HacerNegocios(IInventario inventarioPropio, IInventario mesaPropia, IInventario mesaOtro, IInventario inventarioOtro);
    }
}
