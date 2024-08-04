using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoundByte : MonoBehaviour
{
    [SerializeField] private GameObject _soundTemplate = null;

    public void SpawnSound()
    {
        if(_soundTemplate != null)
            Instantiate(_soundTemplate);
    }
}
