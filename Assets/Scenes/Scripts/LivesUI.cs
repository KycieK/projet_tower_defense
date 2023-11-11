using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;  
    // Update is called once per frame
    void Update()
    {
        livesText.text = "LIVES : " + PlayerStats.Lives.ToString();
    }
}
