using UnityEngine;

public class DetectEntityWin : MonoBehaviour
{
    public bool IsWin { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terka"))
        {
            IsWin = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Terka"))
        {
            IsWin = false;
        }
    }
}
