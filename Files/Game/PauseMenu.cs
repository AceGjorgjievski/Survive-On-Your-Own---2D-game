using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    public static PauseMenu instance;
    void Awake()
    {
        instance = this;
    }


    //  https://prnt.sc/y4E_dxDBh_EA

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        Enemy.TOTAL_ENEMIS_KILLED = 0;
        SceneManager.LoadScene(sceneID);
    }

}
