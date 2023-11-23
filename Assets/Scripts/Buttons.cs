using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Buttons : MonoBehaviour
{
    public float waitToPlayTime;
    public float fadeMusic;
    public float targetVol;

    public GameObject background;
    public VideoPlayer vid;

    public GameObject playBut;
    public GameObject quitBut;

    public GameObject introVid;
    public AudioSource audioSource;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

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
        background.SetActive(false);
        StartCoroutine(FadeMusic());
        playBut.SetActive(false);
        quitBut.SetActive(false);
        introVid.SetActive(true);
        vid.Play();
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
