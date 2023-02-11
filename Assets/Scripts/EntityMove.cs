using System.Collections;
using System;
using UnityEngine;
using DG.Tweening;

public class EntityMove : MonoBehaviour
{
    [SerializeField] private ChoiceEntity _choiceEntity;
    [SerializeField] private Transform _object;
    [SerializeField] private DetectEntityWin _detectEntityWin;

    [SerializeField] private float _shiftAmountY = 4f;
    [SerializeField] private float _shiftAmount = 10f;

    [SerializeField] private float _animationDuration = 1f;

    private Vector3 _startPos;
    private Vector3 _startPosObject;

    private float _maxObjectPosX = 0.3f;    

    private bool _firstPress = true;
    private bool _fingerPressed;
    private bool _isPlaying;

    public Action Slice;
    public Action EntityHasSliced;

    private void OnEnable()
    {
        GameState.Instance.GameStarted += StartGame;
        GameState.Instance.EndOfGame += EndOfGame;
        GameState.Instance.GameRestarted += StartGame;
    }

    private void OnDisable()
    {
        GameState.Instance.GameStarted -= StartGame;
        GameState.Instance.EndOfGame -= EndOfGame;
        GameState.Instance.GameRestarted -= StartGame;
    }

    private void Start()
    {
        _startPos = transform.position;
        _startPosObject = _object.transform.localPosition;
    }

    private void Update()
    {
        if (_isPlaying)
        {
            if (Input.touchCount > 0)
            {
                _fingerPressed = true;
                if (_firstPress)
                    StartCoroutine(AnimateObject());
                _firstPress = false;
                _maxObjectPosX = Mathf.Max(_object.localPosition.x, _maxObjectPosX);
            }
            else
            {
                if (_fingerPressed)
                {
                    Slice?.Invoke();
                    _fingerPressed = false;
                    _firstPress = true;
                    if (_detectEntityWin.IsWin)
                    {
                        EntityHasSliced?.Invoke();
                        _isPlaying = false;
                    }
                }
                ReleaseFinger();
            }
        }
    }

    private IEnumerator AnimateObject()
    {
        while (_fingerPressed)
        {
            transform.DOMoveY(transform.position.y - _shiftAmountY, _animationDuration)
                .SetRelative(true)
                .SetEase(Ease.InOutQuad);
            if (_object.localPosition.x < _maxObjectPosX)
                _object.DOLocalMoveX(_maxObjectPosX, _animationDuration / 2).SetEase(Ease.InOutQuad);
            else
                _object.DOLocalMoveX(_object.localPosition.x + _shiftAmount, _animationDuration / 2).SetEase(Ease.InOutQuad);
            yield return new WaitForSeconds(_animationDuration / 2);
            transform.DOMove(_startPos, _animationDuration / 2).SetEase(Ease.InOutQuad);
            yield return new WaitForSeconds(_animationDuration / 2);
        }
    }

    private void ReleaseFinger() 
    {
        transform.DOMove(_startPos, 0.15f);
        _object.DOLocalMove(_startPosObject, 0.15f);
    }

    private void StartGame()
    {
        _isPlaying = true;
        transform.position = _startPos;
        _object.position = _startPosObject;
        _maxObjectPosX = 0.3f;
    }

    private void EndOfGame()
    {
        Slice?.Invoke();
        _isPlaying = false;
        _fingerPressed = false;
        _firstPress = true;
    }
}
