using Parabox.CSG;
using UnityEngine;

public class MeshSlice : MonoBehaviour
{
    [SerializeField] private EntityMove _entityMove;
    [SerializeField] private DetectCollision _detectCollision;

    [SerializeField] private SliceMesh _slice;

    [SerializeField] private ParticlesCreator _particlesCreator;

    /*[SerializeField] private GameObject _entity;
    [SerializeField] private GameObject _mask;

    [SerializeField] private GameObject _grater;

    [SerializeField] private Transform _parent;*/

    private void OnEnable() => _entityMove.FingerReleased += OnFingerRelease;

    private void OnDisable() => _entityMove.FingerReleased -= OnFingerRelease;

    private void OnFingerRelease()
    {
        if (_detectCollision.IsCollided)
        {
            print("SLICE");
            _slice.Slice();
            _particlesCreator.CreateVegetableParticles();
        }
    }
/*
    private void DoBooleanOperation()
    {
        Model result;
        result = CSG.Subtract(_entity, _mask);
        GameObject composite = new();
        composite.transform.SetParent(_parent);
        composite.AddComponent<MeshFilter>().sharedMesh = result.mesh;
        composite.AddComponent<MeshRenderer>().sharedMaterials = result.materials.ToArray();
        Destroy(_entity);
        _entity = composite;
    }*/
}
