using UnityEngine;
using System;

public class ChoiceEntity : MonoBehaviour
{
    [SerializeField] private Entity _entity;
    [SerializeField] private EntityMove _entityMove;

    public Action StartGame;
    public bool GameStarted { get; private set; }

    public void Choice(EntityData entity)
    {
        _entity.UpdateObject(entity);
        StartGame?.Invoke();
        GameStarted = true;
    }
}
