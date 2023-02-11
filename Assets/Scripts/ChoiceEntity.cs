using UnityEngine;
using System;
using UnityEngine.UI;

public class ChoiceEntity : MonoBehaviour
{
    [SerializeField] private Entity _entity;
    [SerializeField] private EntityMove _entityMove;
    [SerializeField] private ParticlesCreator _particlesCreator;

    [SerializeField] private EntityData[] _entityDatas;

    [SerializeField] private Image[] _images;
    [SerializeField] private EntityData[] _entityDatasButton;

    public Action EntityChoosed;

    private void OnEnable()
    {
        GameState.Instance.GameRestarted += UpdateChoices;
        GameState.Instance.EntitySliced += EntitySliced;
        GameState.Instance.EntitySliced += UpdateChoices;
    }

    private void OnDisable()
    {
        GameState.Instance.GameRestarted -= UpdateChoices;
        GameState.Instance.EntitySliced -= EntitySliced;
        GameState.Instance.EntitySliced -= UpdateChoices;
    }

    private void Start()
    {
        SetChoice();
        UpdateChoices();
    }

    private void UpdateChoices()
    {
        _entity.UpdateObject(_entityDatas[0]);
        SetChoice();
    }

    private void EntitySliced()
    {
        _entity.UpdateObject(_entityDatas[0]);
    }

    private void SetChoice()
    {
        for (int i = 0; i < _images.Length; i++)
        {
            int rand = UnityEngine.Random.Range(1, _entityDatas.Length);
            _images[i].sprite = _entityDatas[rand].Icon;
            _entityDatasButton[i] = _entityDatas[rand];
        }
    }

    public void FirstButton()
    {
        Choice(_entityDatasButton[0]);
    }

    public void SecondButton()
    {
        Choice(_entityDatasButton[1]);
    }

    public void ThirdButton()
    {
        Choice(_entityDatasButton[2]);
    }

    private void Choice(EntityData entity)
    {
        _entity.UpdateObject(entity);
        EntityChoosed?.Invoke();
        _particlesCreator.CreateParticleSpawnEntity();
    }
}
