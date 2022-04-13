using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathCanvasHandler : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        tryAgainButton.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {
    }
    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }
}
