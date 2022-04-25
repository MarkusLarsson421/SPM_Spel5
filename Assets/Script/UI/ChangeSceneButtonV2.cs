using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneButtonV2 : MonoBehaviour
{
    public void changeScene(string sceneName)
    {
        LevelLoaderV2.Instance.LoadScene(sceneName);
    }
}
