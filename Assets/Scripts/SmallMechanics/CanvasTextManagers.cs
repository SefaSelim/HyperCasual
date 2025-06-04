using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasTextManagers : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> TextList = new List<TextMeshProUGUI>();

    private void Update()
    {
        TextList[0].text = StaticPlayerItems.WoodAmount.ToString();
        TextList[1].text = StaticPlayerItems.RockAmount.ToString();
        TextList[2].text = StaticPlayerItems.GoldAmount.ToString();

    }
    
}
