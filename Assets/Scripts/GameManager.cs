using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private ChoiceEntity _choiceEntity;
    [SerializeField] private DetectEndOfEntity _detectEndOfEntity;

    public bool IsPlaying { get; private set; }

    public Action GameStarted;
    public Action EndOfGame;

    private void Awake()
    {
        print("GAME MANAGER INITIALIZED");
        Instance = this;
    }

    private void OnEnable()
    {
        _choiceEntity.EntityChoosed += GameStart;
        _detectEndOfEntity.EndOfEntity += GameEnd;
    }

    private void OnDisable()
    {
        _choiceEntity.EntityChoosed -= GameStart;
        _detectEndOfEntity.EndOfEntity -= GameEnd;
    }

    private void GameStart()
    {
        GameStarted?.Invoke();
        IsPlaying = false;
    }

    private void GameEnd()
    {
        EndOfGame?.Invoke();
        IsPlaying = false;
    }
}
