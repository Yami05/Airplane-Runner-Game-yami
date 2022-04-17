using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pause;
    
    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Home(int sceneID)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneID);
    }
}
