using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenJamWebsite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSite() {
        Application.OpenURL("https://itch.io/jam/mini-jam-164-destruction");
    }
}
