using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip coinCollect;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip webShoot;
    [SerializeField] private AudioClip spidermanTheme;
    [SerializeField] private AudioClip spidermanMeme;
    [SerializeField] private AudioSource bgAudioSource;
    private AudioSource eventAudioSource;
    private float audioLength;
    private bool isPowerUp = false;

    private void Start()
    {
        eventAudioSource = Camera.main.GetComponent<AudioSource>();
        bgAudioSource.enabled = true;
        eventAudioSource.enabled = true;
        audioLength = spidermanMeme.length;
    }
    public void onCoinsCollect()
    {
        eventAudioSource.PlayOneShot(coinCollect);
    }
    public void onWebShoot()
    {
        eventAudioSource.PlayOneShot(webShoot);
    }
    public void onPowerUp()
    {
        bgAudioSource.Pause();
        eventAudioSource.PlayOneShot(spidermanMeme);
        isPowerUp = true;
    }
    public void onPowerDefault()
    {
        bgAudioSource.UnPause();
        isPowerUp = false;
    }
    public void onGameOver()
    {
        eventAudioSource.PlayOneShot(gameOver);
        bgAudioSource.enabled = false;
        StartCoroutine(Timer(Mathf.FloorToInt(gameOver.length)));
    }
    private void Update()
    {
        if (isPowerUp)
        {
            if (audioLength > 0)
            {
                audioLength -= Time.deltaTime;
            }
            else
            {
                onPowerDefault();
                audioLength = spidermanMeme.length;
            }
        }
    }
    private IEnumerator Timer(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        eventAudioSource.enabled = false;
    }
}
