using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winbutton : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene(0);
    }
}
