using System;
using System.Collections;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public bool IsCollided { get; private set; }
    public Action Collided;
    public Action Stay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terka"))
        {
            print("COLIDE");
            IsCollided = true;
            Collided?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Stay?.Invoke();
    }

    private void OnTriggerExit(Collider other) => IsCollided = false;
}
