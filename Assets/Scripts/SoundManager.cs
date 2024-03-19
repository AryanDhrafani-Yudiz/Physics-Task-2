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
        //source.clip = coinCollect;
        //source.Play();
        eventAudioSource.PlayOneShot(coinCollect);
    }
    public void onGameOver()
    {
        //source.clip = gameOver;
        //source.Play();
        eventAudioSource.PlayOneShot(gameOver);
        bgAudioSource.enabled = false;
    }
}
