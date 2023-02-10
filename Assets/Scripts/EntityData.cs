using UnityEngine;

[CreateAssetMenu(fileName="Vegetable", menuName="Vegetable")]
public class EntityData : ScriptableObject
{
    [field: SerializeField] public Mesh Model { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }
}
