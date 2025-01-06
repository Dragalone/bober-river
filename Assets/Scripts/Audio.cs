using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    float music_vol = 1.0f;

    void Update()
    {
        audioSource.volume = music_vol;
    }

    public void SetVolume(float vol)
    {
        music_vol = vol;
    }
}
