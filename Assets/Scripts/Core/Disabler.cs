using UnityEngine;

public class Disabler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
    }
}