using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

enum UpgradeType
{
    AttackSpeed,
    ResourceCollectingAmount,
    DropAmountPerHit,
    WoodSellingSpeed,
    RockSellingSpeed,
    WoodPrice,
    RockPrice
}
public class UpgradeArea : MonoBehaviour
{
    [SerializeField] private UpgradeType upgradeType;
    [SerializeField] private int maxBuyAmount = 1;

    [SerializeField] private int price;
    [SerializeField] private string explanation;

    [SerializeField] private TextMeshProUGUI Price;
    [SerializeField] private TextMeshProUGUI Explanation;
    
    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float hexRadius = 0.5f; 
    private float fillSpeed = 0.5f;
    [SerializeField] private Image hexImage;

    private float currentFill = 1f;


    private void Start()
    {
        Explanation.text = explanation;
        Price.text = price.ToString();
    }

    void Update()
    {
        Vector3 hexCenter = transform.position;
        Vector3 playerXZ = new Vector3(playerTransform.position.x, 0f, playerTransform.position.z);
        Vector3 hexXZ = new Vector3(hexCenter.x, 0f, hexCenter.z);

        float distance = Vector3.Distance(playerXZ, hexXZ);

        if (distance < hexRadius && maxBuyAmount > 0)
        {
            currentFill -= fillSpeed * Time.deltaTime;
            currentFill = Mathf.Clamp01(currentFill);
            hexImage.fillAmount = currentFill;

            if (hexImage.fillAmount == 0 )
            {

                if (StaticPlayerItems.GoldAmount >= price)
                {
                    StaticPlayerItems.GoldAmount -= price;

                    switch (upgradeType)
                    {
                        case UpgradeType.AttackSpeed:
                            StaticPlayerItems.TimeBetweenAttacks -= 0.3f; //max 5
                            break;
                        case UpgradeType.ResourceCollectingAmount:
                            StaticPlayerItems.stackPerCollectedResources++; //max 5
                            break;
                        case UpgradeType.DropAmountPerHit:
                            StaticPlayerItems.spawnAmountPerHit++; // max 3
                            break;
                        case UpgradeType.WoodSellingSpeed:
                            StaticPlayerItems.woodSellingSpeed += 0.5f; // max 5
                            break;
                        case UpgradeType.RockSellingSpeed:
                            StaticPlayerItems.rockSellingSpeed += 0.5f; // max 5
                            break;
                        case UpgradeType.WoodPrice:
                            StaticPlayerItems.WoodPrice++; // max 5
                            break;
                        case UpgradeType.RockPrice:
                            StaticPlayerItems.RockPrice++; // max 5
                            break;
                        default:
                            break;
                    }

                    float newPrice = Random.Range(1.5f, 3f) * price;
                    price = Convert.ToInt16(newPrice);
                    
                    // Updating
                    Explanation.text = explanation; 
                    Price.text = price.ToString();

                    maxBuyAmount--; // bought
                }
                
                    currentFill = 1;
                    hexImage.fillAmount = currentFill;

            }
        }
        else
        {
            if (maxBuyAmount <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                currentFill = 1f;
                hexImage.fillAmount = currentFill;
            }

        }
    }

}
