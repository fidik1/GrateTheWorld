using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticlesCreator : MonoBehaviour
{
    [SerializeField] private GameObject _slicePrefab;
    [SerializeField] private ParticleSystem _particleSpawnEntity;
    [SerializeField] private ParticleSystem _particleSlice;
    [SerializeField] private Transform _particleParent;

    [SerializeField] private Material _material;

    [SerializeField] private Entity _entity;
    private EntityData _entityData;

    [SerializeField] private DetectCollision _detectCollision;

    [SerializeField] private float _timeToParticle = 1;

    [SerializeField] private Vector3 _particleMinPosition, _particleMaxPosition;
    [SerializeField] private Vector3 _particleMinRotation, _particleMaxRotation;

    private void OnEnable()
    {
        _detectCollision.Collided += CreateSlices;
        _entity.EntityUpdated += ChangeEntityData;
        _entity.EntityUpdated += EntityUpdated;
    }

    private void OnDisable()
    {
        _detectCollision.Collided -= CreateSlices;
        _entity.EntityUpdated -= ChangeEntityData;
        _entity.EntityUpdated -= EntityUpdated;
    }

    private void Start()
    {
        _entityData = _entity.EntityData;
    }

    private void ChangeEntityData()
    {
        _entityData = _entity.EntityData;
        _particleSlice.startColor = _entityData.Color;
    }

    private void InstantiateSlices()
    {
        GameObject particle = Instantiate(_slicePrefab, _particleParent);
        particle.GetComponent<MeshRenderer>().material.color = _entityData.Color;
        Vector3 position = new(
            Random.Range(_particleMinPosition.x, _particleMaxPosition.x),
            Random.Range(_particleMinPosition.y, _particleMaxPosition.y),
            Random.Range(_particleMinPosition.z, _particleMaxPosition.z)
            );
        Quaternion rotation = new(
            Random.Range(_particleMinRotation.x, _particleMaxRotation.x),
            Random.Range(_particleMinRotation.y, _particleMaxRotation.y),
            Random.Range(_particleMinRotation.z, _particleMaxRotation.z),
            0
            );

        particle.transform.SetPositionAndRotation(position, rotation);
    }

    private void CreateSlices()
    {
        StartCoroutine(CreateEntitySlices());
    }

    private IEnumerator CreateEntitySlices()
    {
        while (_detectCollision.IsCollided)
        {
            if (!GameState.Instance.IsPlaying) break;
            for (int i = 0; i < Random.Range(6, 12); i++)
                InstantiateSlices();
            CreateParticleSlice();
            yield return new WaitForSeconds(_timeToParticle);
        }
    }

    public void CreateParticleSpawnEntity()
    {
        _particleSpawnEntity.Play();
    }

    private void CreateParticleSlice()
    {
        _particleSlice.Play();
    }

    private void EntityUpdated() => _entityData = _entity.EntityData;
}
