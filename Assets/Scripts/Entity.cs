using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    [field: SerializeField] public EntityData EntityData { get; private set; }
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private Transform _detectEnd;
    [SerializeField] private Transform _detectWin;

    public Action EntityUpdated;

    private void UpdateMesh(Mesh mesh)
    {
        _meshFilter.mesh = mesh;
    }

    private void UpdateMaterials(Material[] materials)
    {
        _meshRenderer.materials = materials;
    }
    
    private void UpdateColliders(Vector3 end, Vector3 win, Vector3 scaleEnd, Vector3 scaleWin)
    {
        UpdateCollider(_detectEnd, end, scaleEnd);
        UpdateCollider(_detectWin, win, scaleWin);
    }

    private void UpdateCollider(Transform collider, Vector3 pos, Vector3 scale)
    {
        collider.localPosition = pos;
        collider.localScale = scale;
    }

    private void UpdateRotation(Vector3 rotation)
    {
        _meshRenderer.transform.localRotation = Quaternion.Euler(rotation);
    }

    private void UpdatePosition(Vector3 position)
    {
        _meshRenderer.transform.localPosition = position;
    }

    public void UpdateObject(EntityData obj)
    {
        EntityData = obj;
        UpdateMesh(EntityData.Model);
        UpdateMaterials(EntityData.Materials);
        EntityUpdated?.Invoke();
        UpdateColliders(EntityData.PosColliderEnd, EntityData.PosColliderWin, EntityData.ScaleColliderEnd, EntityData.ScaleColliderWin);
        UpdateRotation(EntityData.Rotation);
        UpdatePosition(EntityData.Position);
    }
}
