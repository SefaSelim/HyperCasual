using UnityEngine;

public static class StaticPlayerItems
{
    public static float TimeBetweenAttacks = 2.5f; // min val is 1
    
    public static int stackPerCollectedResources = 1;
    public static int stackPerCollectedGold = 1;

    public static int spawnAmountPerHit = 1;

    
    public static int WoodAmount = 0;
    public static int RockAmount = 0;
    public static int GoldAmount = 0;

    public static float woodSellingSpeed = 0.5f;
    public static float rockSellingSpeed = 0.5f;

    public static int WoodPrice = 1;
    public static int RockPrice = 1;

        


    public static bool isAttacking;
}
