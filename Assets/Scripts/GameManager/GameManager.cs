using System.Collections.Generic;
using UnityEngine;
using static GameManager;

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

    public struct Level
    {
        public string name;
        public int numFish;

        public Level(string name, int numFish)
        {
            this.name = name;
            this.numFish = numFish;
        }
    }

    private List<Level> Levels;
    private Level CurrentLevel;
    private int CurrentFish;

    private void Start()
    {
        Levels = new List<Level>();

        Levels.Add(new Level("Level_1", 1));
        Levels.Add(new Level("Level_2", 3));
        Levels.Add(new Level("Level_3", 4));
        Levels.Add(new Level("Level_4", 7));
        Levels.Add(new Level("Level_5", 9));

        CurrentLevel = Levels[0];
        CurrentFish = CurrentLevel.numFish;

        foreach (var level in Levels)
        {
            Debug.Log("Level Name: " + level.name + ", Number of Fish: " + level.numFish);
        }
    }
    
    public void HandleFishMurder()
    {
        --CurrentFish;
        Debug.Log("Current num fish" + CurrentFish);

        if (CurrentFish <= 0)
        {
            Debug.Log("Next level!!!" + CurrentFish);
        }
    }

    private void Update()
    {

    }
}
