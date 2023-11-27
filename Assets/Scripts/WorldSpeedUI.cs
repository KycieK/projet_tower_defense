using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldSpeedUI : MonoBehaviour
{
    public TextMeshProUGUI actionSpeedText;

    void Update()
    {
        actionSpeedText.text = "x" + WorldTime.getActionSpeed().ToString();
    }
}
