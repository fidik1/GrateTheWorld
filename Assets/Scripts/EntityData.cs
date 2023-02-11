using UnityEngine;

[CreateAssetMenu(fileName="Entity", menuName="Entity")]
public class EntityData : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public Mesh Model { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public Material[] Materials { get; private set; }
    [field: SerializeField] public Vector3 Position { get; private set; }
    [field: SerializeField] public Vector3 Rotation { get; private set; }
    [field: SerializeField] public Vector3 PosColliderEnd { get; private set; }
    [field: SerializeField] public Vector3 PosColliderWin { get; private set; }
    [field: SerializeField] public Vector3 ScaleColliderEnd { get; private set; }
    [field: SerializeField] public Vector3 ScaleColliderWin { get; private set; }
}
