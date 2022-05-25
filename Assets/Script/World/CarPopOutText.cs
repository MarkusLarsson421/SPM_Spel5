using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventCallbacks;

public class CarPopOutText : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject playerOne;
    private GameObject playerTwo;
    private float distance1;
    private float distance2;
    [SerializeField] private Transform playerTransform;
    float distance;

    private void Update()
    {
        ClosestPlayer();
        distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance < 5)
        {
            PlayeIsNearTheCarEvent playerGetHitByZombie = new PlayeIsNearTheCarEvent();
            playerGetHitByZombie.FireEvent();
        }
    }
    private void ClosestPlayer()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player1");
        if (playerOne != null)
        {
            playerTransform = playerOne.transform;
            playerTwo = GameObject.FindGameObjectWithTag("Player2");
            if (playerTwo != null)
            {
                distance1 = Vector3.Distance(transform.position, playerOne.transform.position);
                distance2 = Vector3.Distance(transform.position, playerTwo.transform.position);
                if (distance2 < distance1)
                {
                    playerTransform = playerTwo.transform;
                }
            }
        }
    }


}
