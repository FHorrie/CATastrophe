using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject _icon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Button hover
    private void OnMouseEnter()
    {
        Debug.Log("Shits being hoverd");
        _icon.SetActive(true);
    }
    
    //Button hover
    private void OnMouseExit()
    {
        _icon.SetActive(false);
    }
}
