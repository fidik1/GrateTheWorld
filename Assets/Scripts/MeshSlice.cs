using UnityEngine;
using MeshMakerNamespace;

public class MeshSlice : MonoBehaviour
{
    [SerializeField] private Entity _entity;
    [SerializeField] private MeshFilter _entityMeshFilter;
    [SerializeField] private GameObject _grater;

    [SerializeField] private EntityMove _entityMove;
    [SerializeField] private DetectCollision _detectCollision;

    private void OnEnable() => _entityMove.Slice += OnFingerRelease;

    private void OnDisable() => _entityMove.Slice -= OnFingerRelease;

    private void OnFingerRelease()
    {
        if (_detectCollision.IsCollided && GameState.Instance.IsPlaying)
        {
            print("SLICE");
            Slice(_entityMeshFilter);
        }
    }

    private void Slice(MeshFilter objectMesh)
    {
        Mesh mesh = CSG.Subtract(objectMesh.gameObject, _grater, true, true);
        objectMesh.sharedMesh = mesh;
    }
}
