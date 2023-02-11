using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private DetectCollision _detectCollision;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _shakeDuration = 0.3f;
    [SerializeField] private float _shakeStrength = 1f;

    private void OnEnable()
    {
        _detectCollision.Collided += StartShaking;
    }

    private void OnDisable()
    {
        _detectCollision.Collided -= StartShaking;
    }

    private void StartShaking()
    {
        StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        if (_detectCollision.IsCollided)
        {
            _cameraTransform.DOShakePosition(_shakeDuration, _shakeStrength, 10, 90, false, true);
            yield return new WaitForSeconds(_shakeDuration);
        }
    }
}
