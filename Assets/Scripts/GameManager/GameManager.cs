using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

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
        Bee,
        Momcat
    }

    private List<CatType> m_Cats = null;
    private const int m_MaxCats = 6;
    private GameObject m_CurrentProjectile = null;

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
    
    public void HandleFishMurder()
    {
        --CurrentFish;
        if (CurrentFish <= 0)
        {
            ++CurrentIndex;
            LoadLevel(CurrentIndex);
        }
    }

    private bool doOnce;

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex >= Levels.Count)
        {
            levelIndex = 0;
            SceneManager.LoadScene("MainMenu");
        }

        if (CurrentLevel != null)
        {
            Destroy(CurrentLevel);
        }
        CurrentFish = Levels[CurrentIndex].numFish;
        CurrentLevel = Instantiate(Levels[CurrentIndex].gameObject);
    }

    public void Default()
    {
        CurrentIndex = 0;
    }
}
