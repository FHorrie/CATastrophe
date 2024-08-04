using UnityEngine;

public class AutoKill : MonoBehaviour
{
    [SerializeField] private float m_DestroyTimer = 2f;
    [SerializeField] private float m_ElapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        m_ElapsedTime += Time.deltaTime;
        if(m_ElapsedTime >= m_DestroyTimer)
            Destroy(gameObject);
    }
}