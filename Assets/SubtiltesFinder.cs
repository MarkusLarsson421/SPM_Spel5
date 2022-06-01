using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SubtiltesFinder : MonoBehaviour
{
    private string fullText;
    private int timeToShowText = 100;
    private string currentText = "";
    private SubsScript ss;
    private SoundManager sM;
    private float delay = 0.1f;
    [SerializeField] private GameObject textBox;
    void Start()
    {
        StartCoroutine(Subtitle(1, "we have to fix the car ", timeToShowText));
    }

    private IEnumerator Subtitle(int startWaitTime, string text, int timeToFinish)
    {
        fullText = text;
        yield return new WaitForSeconds(startWaitTime);
        sM = GameObject.Find("SM").GetComponent<SoundManager>();
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textBox.GetComponent<TextMeshProUGUI>().text = currentText;
            sM.SoundPlaying("subtitlesSound");
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(timeToFinish);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
    }
}
