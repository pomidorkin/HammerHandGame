using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "ScriptableObjects/AudioDataScriptableObject", order = 1)]
public class AudioDataScriptableObject : ScriptableObject
{
    [SerializeField] public int bufferBand = 1;
    [SerializeField] public float triggerValue = 2f;
    [SerializeField] public float timeLimit = 0.15f;
    [SerializeField] public AudioClip loudTrack;
    [SerializeField] public AudioClip silentBeatTrack;
}