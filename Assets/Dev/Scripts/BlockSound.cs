using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BlockSoundScript : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] m_SoundClips;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        int clipIdx = Random.Range(0, m_SoundClips.Length);
        m_AudioSource.clip = m_SoundClips[clipIdx];
        m_AudioSource.Play();
        Debug.Log("Played sound");
    }
}
