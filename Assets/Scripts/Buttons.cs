using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public float waitToPlayTime;
    public float imageFadetime = 2;
    public float fadeMusic;
    public float targetVol;

    public GameObject introText;
    public Image introImage;
    public GameObject introIm;

    public AudioSource audioSource;

    public void OnPlay()
    {
        StartCoroutine(PlayIntro());
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    private IEnumerator PlayIntro()
    {
        introIm.SetActive(true);

        for (float i = 0; i <= imageFadetime; i += Time.deltaTime)
        {
            // set color with i as alpha
            introImage.color = new Color(0, 0, 0, i);
            yield return null;
        }

        introText.SetActive(true);


        StartCoroutine(FadeMusic());
        yield return new WaitForSeconds(waitToPlayTime);
        SceneManager.LoadScene(1);
    }

    private IEnumerator FadeMusic()
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < fadeMusic)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVol, currentTime / fadeMusic);
            yield return null;
        }
        yield break;
    }
}
