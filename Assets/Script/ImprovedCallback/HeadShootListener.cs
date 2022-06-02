using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShootListener : MonoBehaviour
{
    private int headShotCounter = 0;
    private int headShotCounter2 = 0;
    private bool checkp2;

    void Start()
    {
        HeadShootEvent.RegisterListener(IncreaseHeadShotCounter);
    }

    private void IncreaseHeadShotCounter(HeadShootEvent player)
    {
        if (player.name == "Player2") 
        { ++headShotCounter2;
            checkp2 = true;
        }
        else ++headShotCounter;
    }
    public int GetHeadShotCounter()
    {
        return headShotCounter;
    }
    public int GetHeadShotCounter2()
    {
        return headShotCounter2;
    }
    public bool CheckPlayer2()
    {
        return checkp2;

    }
}
