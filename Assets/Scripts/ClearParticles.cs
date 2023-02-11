using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearParticles : MonoBehaviour
{
    private void OnEnable()
    {
        GameState.Instance.GameRestarted += Clear;
    }

    private void OnDisable()
    {
        GameState.Instance.GameRestarted -= Clear;
    }

    private void Clear()
    {
        foreach (Transform child in transform) Destroy(child.gameObject);
    }
}
