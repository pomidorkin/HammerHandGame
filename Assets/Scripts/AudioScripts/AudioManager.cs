using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource audioSourceMuted;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float delayLength = 1.0f;
    private AudioDataSelector audioDataSelector;

    private void Awake()
    {
        audioDataSelector = FindObjectOfType<AudioDataSelector>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("MyExposedParam", -80.0f);
        //audioSource.PlayDelayed(delayLength);
        ConfigureAudioData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioSource GetAudioSource()
    {
        return audioSourceMuted;
    }

    private void ConfigureAudioData()
    {
        audioSource.clip = audioDataSelector.audioDataObjects[0].loudTrack;
        audioSourceMuted.clip = audioDataSelector.audioDataObjects[0].silentBeatTrack;
        audioSourceMuted.Play();
        audioSource.PlayDelayed(delayLength);
    }
}
