using UnityEngine;
using System;

public class DetectEndOfEntity : MonoBehaviour
{
    public Action EndOfEntity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terka"))
        {
            print("END OF ENTITY");
            EndOfEntity?.Invoke();
        }
    }
}
