using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ChoiceEntity _choiceEntity;
    [SerializeField] private GameObject _textHoldToPlay;

    [SerializeField] private Animator _textHoldToPlayAnimator;
    [SerializeField] private Animator _panelChoiceAnimator;

    private bool _firstClick;

    private void OnEnable()
    {
        GameManager.Instance.GameStarted += OnStartGame;
        GameManager.Instance.EndOfGame += OnEndGame;
    }

    private void OnDisable()
    {
        GameManager.Instance.GameStarted -= OnStartGame;
        GameManager.Instance.EndOfGame -= OnEndGame;
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
    }

    public void OnPlay()
    {
        if (!_firstClick)
        {
            _firstClick = true;
            _textHoldToPlayAnimator.SetBool("isPlaying", true);
        }
    }

    private IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        _textHoldToPlayAnimator.SetBool("Idle", true);
    }
}
