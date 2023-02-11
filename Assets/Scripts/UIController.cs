using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private ChoiceEntity _choiceEntity;
    [SerializeField] private GameObject _textHoldToPlay;

    [SerializeField] private Animator _textHoldToPlayAnimator;
    [SerializeField] private Animator _panelChoiceAnimator;
    [SerializeField] private Animator _panelEndOfGame;

    private bool _firstClick;

    public Action GameRestarted;

    private void OnEnable()
    {
        GameState.Instance.GameStarted += OnStartGame;
        GameState.Instance.EndOfGame += OnEndGame;
        GameState.Instance.EntitySliced += OnEntitySlice;
        GameState.Instance.GameWinned += OnGameWin;
    }

    private void OnDisable()
    {
        GameState.Instance.GameStarted -= OnStartGame;
        GameState.Instance.EndOfGame -= OnEndGame;
        GameState.Instance.EntitySliced -= OnEntitySlice;
        GameState.Instance.GameWinned -= OnGameWin;
    }

    private void OnStartGame()
    {
        _panelChoiceAnimator.SetBool("Hide", true);
        _textHoldToPlayAnimator.SetBool("StartGame", true);
        StartCoroutine(PlayAnimation());
    }

    private void OnEndGame()
    {
        print("UICONTROLLER: END OF GAME");
        _panelEndOfGame.SetBool("End", true);
        _panelEndOfGame.SetBool("GameRestarted", false);
    }

    public void OnPlay()
    {
        if (!_firstClick)
        {
            _firstClick = true;
            _textHoldToPlayAnimator.SetBool("isPlaying", true);
        }
    }

    public void RestartGame()
    {
        GameRestarted?.Invoke();
        _panelEndOfGame.SetBool("End", false);
        _panelEndOfGame.SetBool("GameRestarted", true);
        ShowChoice();
    }

    private void ShowChoice()
    {
        _panelEndOfGame.SetBool("End", false);
        _panelChoiceAnimator.SetBool("Hide", false);
        _firstClick = false;
    }

    private void OnEntitySlice()
    {
        ShowChoice();
    }

    private void OnGameWin()
    {
        
    }

    private IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        _textHoldToPlayAnimator.SetBool("Idle", true);
    }
}
