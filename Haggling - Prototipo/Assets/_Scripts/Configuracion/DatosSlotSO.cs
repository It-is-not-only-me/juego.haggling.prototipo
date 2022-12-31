using UnityEngine;

[CreateAssetMenu(fileName = "Datos de slot", menuName = "Haggling/Configuracion/Datos de slot")]
public class DatosSlotSO : ScriptableObject
{
    [SerializeField] private Vector2 _dimensiones, _espaciado;
    [SerializeField] private TextAnchor _posicionDeSlot;

    public Vector2 Dimensiones { get => _dimensiones; }
    public Vector2 Espaciado { get => _espaciado; }
    public TextAnchor PosicionDeSlot { get => _posicionDeSlot; }
}
