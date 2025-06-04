using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    void Update()
    {
        if (playerTransform != null)
        {
            transform.LookAt(playerTransform);
        }
    }
}