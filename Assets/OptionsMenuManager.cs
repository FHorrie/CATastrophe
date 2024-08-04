using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        GameManager.Instance.SetVolume(volume);
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        Debug.Log(isFullscreen);
        if( isFullscreen ) Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        else Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
