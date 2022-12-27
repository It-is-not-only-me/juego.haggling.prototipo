public class Promesa : IObjeto
{
    private IObjeto _objeto;

    public Promesa(IObjeto objeto)
    {
        _objeto = objeto;
    }

    public int PrecioBase => _objeto.PrecioBase;

    public CaracteristicasDeObjeto Caracteristicas => _objeto.Caracteristicas;

    public int PrecioSubjetivo(IPersona persona) => _objeto.PrecioSubjetivo(persona);

    public bool TieneCaracteristica(ICaracteristica caracteristica) => _objeto.TieneCaracteristica(caracteristica);
}
