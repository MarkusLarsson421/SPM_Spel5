using UnityEngine;

public class GeneratorBreakerFirstTIme : MonoBehaviour
{
    [SerializeField] private SubsScript ss;
	[SerializeField] private Generator gen;
    private PickupPool pool;

    private void Start()
    {
        pool = GameObject.Find("PickupPool").GetComponent<PickupPool>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Debug.Log("triggar?");
            ss.SetGeneratorBreakFirstTime(true);
			gen.GetComponent<Generator>().SetFuel(0.0f);
            Destroy(gameObject);
            pool.SetAmountOfScraps(7);
            pool.SetScrapsActive();
            
        }
        
    }
}
