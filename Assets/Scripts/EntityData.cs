using UnityEngine;

[CreateAssetMenu(fileName="Entity", menuName="Entity")]
public class EntityData : ScriptableObject
{
    [field: SerializeField] public Mesh Model { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }
}
