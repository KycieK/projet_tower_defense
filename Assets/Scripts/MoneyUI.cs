using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;  
    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
