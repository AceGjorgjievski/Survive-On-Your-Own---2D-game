using UnityEngine.UI;
using UnityEngine;
using System;

public class WaveUI : MonoBehaviour
{

    [SerializeField]
    WaveSpawner spawner;
    [SerializeField]
    Animator waveAnimator;
    [SerializeField]
    Text waveCountdownText;
    [SerializeField]
    Text waveCountText;


    public static WaveUI instance;
    public static bool SCORE_TO_BE_WRITTEN = false;

    private WaveSpawner.SpawnState previousState;
    // Start is called before the first frame update
    void Start()
    {
        if(this.spawner == null)this.enabled = false;
        if(this.waveAnimator == null)this.enabled = false;
        if(this.waveCountdownText == null)this.enabled = false;
        if(this.waveCountText == null)this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(this.spawner.State)
        {
            case WaveSpawner.SpawnState.COUNTING:
                this.UpdateCountingUI();
                break;
            case WaveSpawner.SpawnState.SPAWNING:
                this.UpdateSpawingUI();
                break;
        }
        this.previousState = this.spawner.State;
    }
    private void UpdateCountingUI()
    {
        if(this.previousState != WaveSpawner.SpawnState.COUNTING)
        {
            this.waveAnimator.SetBool("WaveIncoming", false);
            this.waveAnimator.SetBool("WaveCountdown", true);
            Debug.Log("Counting...");
        }

        this.waveCountdownText.text = (((int)this.spawner.WaveCountdown)+1).ToString();
    }
    private void UpdateSpawingUI()
    {
        if(this.previousState != WaveSpawner.SpawnState.SPAWNING)
        {
            SCORE_TO_BE_WRITTEN = true;

            this.waveAnimator.SetBool("WaveIncoming", true);
            this.waveAnimator.SetBool("WaveCountdown", false);
            this.waveCountText.text = (this.spawner.NextWave+1).ToString();
            Debug.Log("Spawning...");
        }
    }
}
