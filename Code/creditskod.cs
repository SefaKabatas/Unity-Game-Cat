using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditskod : MonoBehaviour
{
    public void back()
    {
        SceneManager.LoadScene("Scenes/Giris");
        Time.timeScale = 1.0f;
    }
}
