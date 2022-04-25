using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Denna klass inneh�ller en k� f�r gameobjects och metoder f�r att l�gga till, ta bort osv.
 * Anv�nds f�r att spawna pickups och annat med object pooling.
 */
public class GameObjectPool : MonoBehaviour
{
    private GameObject objToSpawn;
    private Queue<GameObject> objects = new Queue<GameObject>();

    //konstruktor?
}
