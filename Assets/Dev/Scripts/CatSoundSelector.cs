using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CatSoundSelector : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] m_CatMeowClips = null;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        int clipIdx = Random.Range(0, m_CatMeowClips.Length);
        m_AudioSource.clip = m_CatMeowClips[clipIdx];
        m_AudioSource.Play();
        Debug.Log("Played cat sound");
    }
}