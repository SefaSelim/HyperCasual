using System;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public float HitDistance = 1f;

    [SerializeField] private SpawnCollectibles spawnCollectibles;
    
    private Animator animator;
    
    private void Start()
    {
        HitareaDetection.instance.OnDetectWithFarmables += Sub_OnDetectWithFarmables;
        animator = transform.parent.GetComponent<Animator>();
    }


    private void Sub_OnDetectWithFarmables(object sender, HitareaDetection.EventTransformHandler e)
    {
        if ((e.position - transform.position).sqrMagnitude < HitDistance)
        {
            animator.SetTrigger("Collect");
            for (int i = 0; i < StaticPlayerItems.spawnAmountPerHit; i++)
            {
                spawnCollectibles.Spawn(i);
            }
            
        }
    }
}
