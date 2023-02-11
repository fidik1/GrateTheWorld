using UnityEngine;
using System;

public class ChoiceEntity : MonoBehaviour
{
    [SerializeField] private Entity _entity;
    [SerializeField] private EntityMove _entityMove;

    public Action EntityChoosed;

    public void Choice(EntityData entity)
    {
        _entity.UpdateObject(entity);
        EntityChoosed?.Invoke();
    }
}
