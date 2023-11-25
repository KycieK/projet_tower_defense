using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Overlays;

public class ToggleShop : MonoBehaviour
{

    public GameObject shopIcons;
    
    private void Start()
    {
        if(shopIcons != null) shopIcons.SetActive(true);
    }

    public void ToggleShopUI()
    {
        if(shopIcons != null)
        {
            shopIcons.SetActive(!shopIcons.activeSelf);
        }
    }
}
