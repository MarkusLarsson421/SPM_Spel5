using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health; // set the amount of health in unity
    [SerializeField] private int stamina; //set the stamina of health in unity
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject CanvasObject;
    [SerializeField] private GameObject deathCanvasObject;
    [SerializeField] private Button tryAgainButton;

    void Start()
    {
        health = 100;
    }

    void Update()
    {
        SetHealthText();
        if (health <= 0)
        {
            health = 0;
            PlayerDeath();
        }
    }

    public int GetHealth()  { return health; }
    public int GetStamina() { return stamina; }
    private void SetHealthText() { healthText.text = health.ToString(); }
    //private void setStaminaText() { staminaText.text = stamina.ToString(); }


    public void HitByZombie()
    {
        // Hur mycket skada man tar av en zombie varierar
        int randomNr = Random.Range(15, 26);
        health -= randomNr;
        Debug.Log(health);

    }
    private void PlayerDeath()
    {
        //Mest till för att testa, inte bestämt vad som ska hända när man dör
        Debug.Log("dead");
        GetComponent<Movement>().enabled = false;
    }
}
