using System.Collections;
using System;
using UnityEngine;
using DG.Tweening;

public class EntityMove : MonoBehaviour
{
    [SerializeField] private ChoiceEntity _choiceEntity;
    [SerializeField] private Transform _object;

    [SerializeField] private float _shiftAmountY = 4f;
    [SerializeField] private float _shiftAmount = 10f;

    [SerializeField] private float _animationDuration = 1f;

    private Vector3 _startPos;
    private Vector3 _startPosObject;

    private float _maxObjectPosX = 0.3f;    

    private bool _firstPress = true;
    private bool _fingerPressed;
    private bool _isPlaying;

    public Action FingerReleased;

    private void OnEnable()
    {
        print(GameManager.Instance);
        GameManager.Instance.GameStarted += StartGame;
        GameManager.Instance.EndOfGame += EndOfGame;
    }

    private void OnDisable()
    {
        GameManager.Instance.GameStarted -= StartGame;
        GameManager.Instance.EndOfGame -= EndOfGame;
    }

    private void Start()
    {
        _startPos = transform.position;
        _startPosObject = _object.localPosition;
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
                    FingerReleased?.Invoke();
                    _fingerPressed = false;
                    _firstPress = true;
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
        print("RELEASE FINGER");
        transform.DOMove(_startPos, 0.15f);
        _object.DOLocalMove(_startPosObject, 0.15f);
    }

    public void StartGame() => _isPlaying = true;
    public void EndOfGame()
    { 
        _isPlaying = false;
        _fingerPressed = false;
        _firstPress = true;
    }
}
