using System;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

public class HitareaDetection : MonoBehaviour
{
    public static HitareaDetection instance;

    public event EventHandler<EventTransformHandler> OnDetectWithFarmables;
    public class  EventTransformHandler : EventArgs
    {
        public Vector3 position;
    }
    
    

    private void Awake()
    {
        instance = this;
    }


    public void CheckHit()
    {
        OnDetectWithFarmables?.Invoke(this, new EventTransformHandler { position = transform.position });
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Farmable"))
        {
            StaticPlayerItems.isAttacking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Farmable"))
        {
            StaticPlayerItems.isAttacking = false;
        }
    }

    
    
}
