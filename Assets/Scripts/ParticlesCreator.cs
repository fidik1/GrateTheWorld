using UnityEngine;

public class ParticlesCreator : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private Transform _particleParent;

    [SerializeField] private Material _material;

    [SerializeField] private Entity _entity;
    private EntityData _entityData;

    [SerializeField] private DetectCollision _detectCollision;

    private float _timer;
    [SerializeField] private float _timeToParticle = 1;

    [SerializeField] private Vector3 _particleMinPosition, _particleMaxPosition;
    [SerializeField] private Vector3 _particleMinRotation, _particleMaxRotation;

    private void OnEnable()
    {
        _detectCollision.Stay += CreateParticles;
        _entity.EntityUpdated += ChangeEntityData;
    }

    private void OnDisable()
    {
        _detectCollision.Stay -= CreateParticles;
        _entity.EntityUpdated -= ChangeEntityData;
    }

    private void Start()
    {
        _entityData = _entity.EntityData;
        _entity.EntityUpdated += EntityUpdated;
    }

    private void ChangeEntityData()
    {
        _entityData = _entity.EntityData;
        _material.color = _entityData.Color;
    }

    private void CreateEntityParticles()
    {
        GameObject particle = Instantiate(_particlePrefab, _particleParent);
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

    private void CreateParticles()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeToParticle)
        {
            for (int i = 0; i < Random.Range(4, 9); i++)
                CreateEntityParticles();
            _timer = 0;
        }
    }

    private void EntityUpdated() => _entityData = _entity.EntityData;
}
