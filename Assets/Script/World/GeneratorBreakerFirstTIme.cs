using UnityEngine;

public class GeneratorBreakerFirstTIme : MonoBehaviour
{
    [SerializeField] private SubsScript ss;
	[SerializeField] private Generator gen;
    private SoundManager sM; //Simon Hessling Oscarson

    private PickupPool pool;

    private void Start()
    {
        pool = GameObject.Find("PickupPool").GetComponent<PickupPool>();
        sM = GameObject.Find("SM").GetComponent<SoundManager>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            ss = collision.gameObject.transform.Find("SubtiltesManager").GetComponent<SubsScript>();
            sM.SoundPlaying("generatorOff");
            ss.SetGeneratorBreakFirstTime(true);
			gen.GetComponent<Generator>().SetFuel(0.0f);
            Destroy(gameObject);
            pool.SetAmountOfScraps(4);
            pool.SetScrapsActive();
            
        }
        
    }
}
