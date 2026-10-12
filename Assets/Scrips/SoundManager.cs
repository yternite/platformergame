using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bron;
    public AudioClip springGeluid;
    public AudioClip landGeluid;
    public AudioClip stapGeluid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bron = GetComponent<AudioSource>();
    }

    public void SpeelSpring()
    {
        bron.PlayOneShot(springGeluid);
    }

    public void SpeelLand()
    {
        bron.PlayOneShot(landGeluid);
    }

    public void SpeelStap()
    {
        bron.PlayOneShot(stapGeluid);
    }

    
    
// Update is called once per frame
    void Update()
    {
        
    }
}
