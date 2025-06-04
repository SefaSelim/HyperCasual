using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinConditions : MonoBehaviour
{

    [SerializeField] private string SceneName;
    
    
    public int neededWoodAmount;
    public int neededRock;
    public int neededGold;

    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float hexRadius = 0.5f; 
    private float fillSpeed = 0.5f;
    [SerializeField] private Image hexImage;

    private float currentFill = 1f;
    

    void Update()
    {
        
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
                if (StaticPlayerItems.WoodAmount > neededWoodAmount && StaticPlayerItems.RockAmount > neededRock && StaticPlayerItems.GoldAmount > neededGold)
                {
                    StaticPlayerItems.GoldAmount = 0;
                    StaticPlayerItems.WoodAmount = 0;
                    StaticPlayerItems.RockAmount = 0;
                    StaticPlayerItems.woodSellingSpeed = 0.5f;
                    StaticPlayerItems.rockSellingSpeed = 0.5f;
                    StaticPlayerItems.WoodPrice = 1;
                    StaticPlayerItems.RockPrice = 1;
                    StaticPlayerItems.spawnAmountPerHit = 1;
                    StaticPlayerItems.stackPerCollectedGold = 1;
                    StaticPlayerItems.stackPerCollectedResources = 1;
                    StaticPlayerItems.TimeBetweenAttacks = 2.5f;

                    
                    SceneManager.LoadScene(SceneName);
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
