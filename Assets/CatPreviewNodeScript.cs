using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPreviewNodeScript : MonoBehaviour
{
    
    [SerializeField] public int m_NodeIndex = 0;
    
    [SerializeField] private GameObject[] m_PossibleCats = null;
    
    //Current cat we are showing
    private GameManager.CatType? m_CurrentCat = null;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        // GameManager.Instance.Cats[m_NodeIndex]
        // if (GameManager.Instance.Cats[m_NodeIndex] != m_CurrentCat) {
        //     SetCat(GameManager.Instance.Cats[m_NodeIndex]);
        // }
    }
    
    public void SetCat(GameManager.CatType? cat) {
        Debug.Log("Setting cat: " + cat + " My index is " + m_NodeIndex);

        if (cat == null) {
            for (int i = 0; i < m_PossibleCats.Length; i++) {
                m_PossibleCats[i].SetActive(false);
            }

            return;
        }
        m_CurrentCat = cat;
        m_PossibleCats[(int)cat].SetActive(true);
        //Set the other cats to false
        for (int i = 0; i < m_PossibleCats.Length; i++) {
            if (i != (int)cat) {
                m_PossibleCats[i].SetActive(false);
            }
        }
    }
}
