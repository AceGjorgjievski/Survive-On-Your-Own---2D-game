using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private AudioSource audioSource;
    public AudioClip healthPickUp;
    public AudioClip playerDead;
    public AudioClip ShootingSound;
    public AudioClip EnemyDeadSound;
    public AudioClip PlayerHitSound;

    void Awake()
    {
        Instance = this;
        this.audioSource = GetComponent<AudioSource>();
    }

    public void PlayeHealthPikUpSound()
    {
        this.audioSource.PlayOneShot(healthPickUp);
    }

    public void PlayPlayerDeadSound()
    {
        this.audioSource.PlayOneShot(playerDead);
    }

    public void PlayShootingSound()
    {
        this.audioSource.PlayOneShot(ShootingSound);
    }

    public void PlayEnemyDeadSound()
    {
        this.audioSource.PlayOneShot(EnemyDeadSound);
    }
    public void PlayPlayerHitSound()
    {
        this.audioSource.PlayOneShot(PlayerHitSound);
    }
}
