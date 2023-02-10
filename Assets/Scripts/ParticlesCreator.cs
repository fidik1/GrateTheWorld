using UnityEngine;

public class ParticlesCreator : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _objectParticles;
    private int _objectParticlesIndex;

    [SerializeField] private Entity _entity;
    private EntityData _entityData;

    private void Start()
    {
        _entityData = _entity.EntityData;
        _entity.EntityUpdate += EntityUpdated;
    }

    public void CreateVegetableParticles()
    {
        ParticleSystem particle = _objectParticles[_objectParticlesIndex];
        _objectParticlesIndex = _objectParticlesIndex > _objectParticles.Length ? _objectParticlesIndex++ : _objectParticlesIndex = 0;
        particle.startColor = _entityData.Color;
        particle.Play();
    }

    private void EntityUpdated() => _entityData = _entity.EntityData;
}
