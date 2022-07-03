using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Application QUIT!");
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameMaster.PLAYER_ALIVE = true;
        WaveUI.SCORE_TO_BE_WRITTEN = false;
        Enemy.TOTAL_ENEMIS_KILLED = 0;
    }
}
