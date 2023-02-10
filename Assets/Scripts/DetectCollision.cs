using System;
using System.Collections;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private Vector3 _startPosObject;
    public bool IsCollided { get; private set; }

    private bool _canSlice = true;

    private void Start()
    {
        _startPosObject = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terka"))
        {
            print("COLIDE");
            IsCollided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IsCollided = false;
    }
}
