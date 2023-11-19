using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WorldTime : MonoBehaviour
{
    public static float actionSpeed = 1;
    private static int nmbreClics = 1;
 

    public static void ChangeActionSpeed()
    {
        nmbreClics ++;

        if(nmbreClics > 3) 
        {
            actionSpeed = 1;
            nmbreClics = 1;

        } else 
        {
            actionSpeed = nmbreClics;
        }
    }
}
