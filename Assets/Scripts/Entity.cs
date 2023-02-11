using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    [field: SerializeField] public EntityData EntityData { get; private set; }
    [SerializeField] private MeshFilter _meshRenderer;
    public Action EntityUpdated;

    private void UpdateMesh(Mesh mesh)
    {
        _meshRenderer.mesh = mesh;
    }

    public void UpdateObject(EntityData obj)
    {
        EntityData = obj;
        UpdateMesh(EntityData.Model);
        EntityUpdated?.Invoke();
    }
}
