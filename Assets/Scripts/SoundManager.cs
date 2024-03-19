using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip coinCollect;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip spidermanTheme;
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
    public void onGameOver()
    {
        eventAudioSource.PlayOneShot(gameOver);
        bgAudioSource.enabled = false;
    }
}
