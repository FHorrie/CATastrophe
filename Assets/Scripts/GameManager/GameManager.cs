using System.Collections.Generic;
using UnityEngine;

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
}
