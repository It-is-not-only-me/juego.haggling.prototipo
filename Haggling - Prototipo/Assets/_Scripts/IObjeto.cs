public interface IObjeto
{
    public int PrecioBase { get; }

    public CaracteristicasDeObjeto Caracteristicas { get; }

    public int PrecioSubjetivo(IPersona persona);

    public bool TieneCaracteristica(ICaracteristica caracteristica);
}
