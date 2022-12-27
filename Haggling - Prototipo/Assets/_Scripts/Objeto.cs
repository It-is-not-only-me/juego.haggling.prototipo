using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Objeto : IObjeto
{
    private CaracteristicasDeObjeto _caracteristicasDelObjeto;
    
    private List<ICaracteristica> _caracteristicas;

    public Objeto(List<ICaracteristica> caracteristicas, CaracteristicasDeObjeto caracteristicasDelObjeto)
    {
        _caracteristicasDelObjeto = caracteristicasDelObjeto;
        _caracteristicas = caracteristicas; 
    }

    public int PrecioBase => _caracteristicasDelObjeto.PrecioBase;

    public CaracteristicasDeObjeto Caracteristicas => _caracteristicasDelObjeto;

    public int PrecioSubjetivo(IPersona persona) => persona.PrecioSubjetivo(this);

    public bool TieneCaracteristica(ICaracteristica caracteristica) => _caracteristicas.Any(caracteristicaParticula => caracteristicaParticula.EsIgual(caracteristica));
}
