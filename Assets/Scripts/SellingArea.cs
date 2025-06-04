using System;
using UnityEngine;
using UnityEngine.UI;

public class SellingArea : MonoBehaviour
{
    [SerializeField] private CollectibleItemType ItemType;
    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float hexRadius = 0.5f; 
    private float fillSpeed = 0.5f;
    [SerializeField] private Image hexImage;

    private float currentFill = 1f;
    

    void Update()
    {
        if (ItemType == CollectibleItemType.Wood)
        {
            fillSpeed = StaticPlayerItems.woodSellingSpeed;
        }

        if (ItemType == CollectibleItemType.Rock)
        {
            fillSpeed = StaticPlayerItems.rockSellingSpeed;
        }
        
        
        Vector3 hexCenter = transform.position;
        Vector3 playerXZ = new Vector3(playerTransform.position.x, 0f, playerTransform.position.z);
        Vector3 hexXZ = new Vector3(hexCenter.x, 0f, hexCenter.z);

        float distance = Vector3.Distance(playerXZ, hexXZ);

        if (distance < hexRadius)
        {
            currentFill -= fillSpeed * Time.deltaTime;
            currentFill = Mathf.Clamp01(currentFill);
            hexImage.fillAmount = currentFill;

            if (hexImage.fillAmount == 0)
            {
                if (ItemType == CollectibleItemType.Wood)
                {
                    if (StaticPlayerItems.WoodAmount > 0)
                    {
                        StaticPlayerItems.WoodAmount -= 1;
                        StaticPlayerItems.GoldAmount += StaticPlayerItems.WoodPrice;
                    
                    }
                }

                if (ItemType == CollectibleItemType.Rock)
                {
                    if (StaticPlayerItems.RockAmount > 0)
                    {
                        StaticPlayerItems.RockAmount -= 1;
                        StaticPlayerItems.GoldAmount += StaticPlayerItems.RockPrice;
                    
                    }
                }
                    currentFill = 1;
                    hexImage.fillAmount = currentFill;

            }
        }
        else
        {
            currentFill = 1f;
            hexImage.fillAmount = currentFill;
        }
    }

}
