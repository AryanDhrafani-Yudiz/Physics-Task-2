using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip coinCollect;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip webShoot;
    [SerializeField] private AudioClip spidermanTheme;
    [SerializeField] private AudioClip spidermanMeme;
    [SerializeField] private AudioSource bgAudioSource;
    private AudioSource eventAudioSource;

    private void Start()
    {
        eventAudioSource = Camera.main.GetComponent<AudioSource>();
        bgAudioSource.enabled = true;
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
    }
    public void onGameOver()
    {
        eventAudioSource.PlayOneShot(gameOver);
        bgAudioSource.enabled = false;
    }
}
