using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    private static float actionSpeed = 1;
 

    public static void ChangeActionSpeed()
    {
        actionSpeed ++;

        if(actionSpeed > 3) 
        {
            actionSpeed = 1;
        }   
    }

    public static float getActionSpeed()
    {
        return actionSpeed;
    }
}
