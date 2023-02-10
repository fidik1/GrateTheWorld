using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ChoiceEntity _choiceEntity;
    [SerializeField] private GameObject _canvasMain, _canvasChoice, _textHoldToPlay;
    [SerializeField] private Animator _textAnimator;

    private bool _firstClick;

    private void OnEnable() => _choiceEntity.StartGame += OnStartGame;

    private void OnStartGame()
    {
        _canvasChoice.SetActive(false);
        _canvasMain.SetActive(true);
    }

    public void OnPlay()
    {
        if (!_firstClick)
        {
            _firstClick = true;
            _textAnimator.SetBool("isPlaying", true);
        }
    }
}
