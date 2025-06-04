using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

enum CollectibleItemType
{
    Wood,
    Rock,
    Gold
}

public class CollectibleItems : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 25f;
    
    [SerializeField] private CollectibleItemType itemType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddItem(itemType);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (transform.position.y < -0.85)
        {
            transform.position = new Vector3(transform.position.x, -0.85f , transform.position.z);
            transform.RotateAround(transform.position,Vector3.up,Time.deltaTime * rotateSpeed);
        }
    }

    void AddItem(CollectibleItemType ItemIndex)
    {
        switch (ItemIndex)
        {
            case CollectibleItemType.Wood:
                StaticPlayerItems.WoodAmount += StaticPlayerItems.stackPerCollectedResources;
                break;
            case CollectibleItemType.Rock:
                StaticPlayerItems.RockAmount+= StaticPlayerItems.stackPerCollectedResources;
                break;
            case CollectibleItemType.Gold:
                StaticPlayerItems.GoldAmount += StaticPlayerItems.stackPerCollectedGold;
                break;
        }
    }
}
