using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using static GameManager;
using Random = UnityEngine.Random;

[System.Serializable]
public class Level
{
    public GameObject gameObject;
    public int numFish;

    public Level(GameObject gameObject, int numFish)
    {
        this.gameObject = gameObject;
        this.numFish = numFish;
    }
}

public class GameManager : Singleton<GameManager>
{

    public enum CatType
    {
        Standard,
        Boom,
        Fat,
        Momcat
    }

    private List<CatType> m_Cats = null;
    private const int m_MaxCats = 6;
    private GameObject m_CurrentProjectile = null;

    private bool shouldLoadNextLevel = false;

    public List<CatType> Cats
    {
        get { return m_Cats; }
        set
        {
            if (value.Count < m_MaxCats)
            {
                m_Cats.Capacity = m_MaxCats;
                for (int i = 0; i < m_MaxCats; i++)
                    m_Cats[i] = value[i];
            }
            else
                m_Cats = value;

        }
    }

    public GameObject CurrentProjectile
    {
        get { return m_CurrentProjectile; }
        set { m_CurrentProjectile = value; }
    }

    [SerializeField] private List<Level> Levels;
    private GameObject CurrentLevel;
    private int CurrentIndex = 0;
    private int CurrentFish;

    private void Start() {
        Default(); //TODO: remove
    }

    public void HandleFishMurder()
    {
        --CurrentFish;
        if (CurrentFish <= 0)
        {
            ++CurrentIndex;
            shouldLoadNextLevel = true;
            // LoadLevel(CurrentIndex);
        }
    }

    private bool doOnce;

    public void  LoadLevel(int levelIndex)
    {
        if (levelIndex >= Levels.Count)
        {
            //Show the win screen
            SceneManager.LoadScene("WinScene");
            levelIndex = 0;
        }

        if (CurrentLevel != null)
        {
            Destroy(CurrentLevel);
        }
        CurrentFish = Levels[CurrentIndex].numFish;
        CurrentLevel = Instantiate(Levels[CurrentIndex].gameObject);
        m_Cats = new List<CatType>();
        for (int i = 0; i < m_MaxCats; i++)
        {
            m_Cats.Add((CatType)Random.Range(0, 4));
        }
        
        foreach (var cat in m_Cats)
        {
            Debug.Log(cat);
        }
        var temp = GameObject.FindGameObjectsWithTag("catNode");
        //Sort based on Node Index on the script
        for (var i = 0; i < temp.Length; i++) {
            temp[i].GetComponent<CatPreviewNodeScript>().SetCat(m_Cats[temp[i].GetComponent<CatPreviewNodeScript>().m_NodeIndex]);
        }
    }

    private void Update() {
        if (Cats.Count == 0 && CurrentProjectile == null) {
            SceneManager.LoadScene("Scenes/LooseScene");
        }
        if (shouldLoadNextLevel && GameManager.Instance.CurrentProjectile == null)
        {
            shouldLoadNextLevel = false;
            LoadLevel(CurrentIndex);
        }
    }


    public void updatePreviewNodes() {
        foreach (var cat in m_Cats)
        {
            Debug.Log(cat);
        }
        var temp = GameObject.FindGameObjectsWithTag("catNode");
        //Sort based on Node Index on the script
        for (var i = 0; i < temp.Length; i++) {
            try {
                CatType? cat = m_Cats[temp[i].GetComponent<CatPreviewNodeScript>().m_NodeIndex] as CatType?;
                temp[i].GetComponent<CatPreviewNodeScript>().SetCat(cat);
            }
            catch (Exception e) {
                temp[i].GetComponent<CatPreviewNodeScript>().SetCat(null);
            }
        }
    }

    public void Default()
    {
        CurrentIndex = 0;
        m_Cats = new List<CatType>();
        for (int i = 0; i < m_MaxCats; i++)
        {
            m_Cats.Add((CatType)Random.Range(0, 4));
        }

        updatePreviewNodes();
    }
}
