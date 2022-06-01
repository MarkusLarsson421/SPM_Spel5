using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShootListener : MonoBehaviour
{
    private int headShotCounter = 0;
    void Start()
    {
        HeadShootEvent.RegisterListener(IncreaseHeadShotCounter);
    }

    private void IncreaseHeadShotCounter(HeadShootEvent info)
    {
        ++headShotCounter;
    }
    public int GetHeadShotCounter()
    {
        return headShotCounter;
    }
}
