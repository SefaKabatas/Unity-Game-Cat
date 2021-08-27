using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class giriskod : MonoBehaviour
{
   public void basla()
    {
        SceneManager.LoadScene("Scenes/tanıtım");
        Time.timeScale = 1.0f;
    }
   public void credits()
    {
        SceneManager.LoadScene("Scenes/credits");
        Time.timeScale = 1.0f;
    }
    public void qoıt()
    {
        Application.Quit();
    }


}
