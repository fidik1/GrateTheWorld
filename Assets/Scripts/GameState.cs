using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    [SerializeField] private ChoiceEntity _choiceEntity;
    [SerializeField] private DetectEndOfEntity _detectEndOfEntity;
    [SerializeField] private UIController _UIController;
    [SerializeField] private EntityMove _entityMove; 

    public bool IsPlaying { get; private set; }

    public Action GameStarted;
    public Action EndOfGame;
    public Action GameRestarted;
    public Action EntitySliced;
    public Action GameWinned;

    private void Awake()
    {
        print("GAME STATE INITIALIZED");
        Instance = this;
    }

    private void OnEnable()
    {
        _choiceEntity.EntityChoosed += GameStart;
        _detectEndOfEntity.EndOfEntity += GameEnd;
        _UIController.GameRestarted += GameRestart;
        _entityMove.EntityHasSliced += EntityHasSliced;
    }

    private void OnDisable()
    {
        _choiceEntity.EntityChoosed -= GameStart;
        _detectEndOfEntity.EndOfEntity -= GameEnd;
        _UIController.GameRestarted -= GameRestart;
        _entityMove.EntityHasSliced -= EntityHasSliced;
    }

    private void GameStart()
    {
        GameStarted?.Invoke();
        IsPlaying = true;
    }

    private void GameEnd()
    {
        if (IsPlaying)
        {
            EndOfGame?.Invoke();
            IsPlaying = false;
        }
    }

    private void GameRestart()
    {
        GameRestarted?.Invoke();
    }

    private void EntityHasSliced()
    {
        if (IsPlaying)
        {
            EntitySliced?.Invoke();
            IsPlaying = false;
        }
    }

    private void GameWin()
    {
        GameWinned?.Invoke();
        IsPlaying = false;
    }
}
