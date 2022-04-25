using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Denna klass innehåller en kö för gameobjects och metoder för att lägga till, ta bort osv.
 * Används för att spawna pickups och annat med object pooling.
 */
public class GameObjectPool : MonoBehaviour
{
    private GameObject objToSpawn;
    private Queue<GameObject> objects = new Queue<GameObject>();

    //konstruktor?
}
