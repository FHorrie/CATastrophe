using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_CamPos = null;
    private Vector3 m_Offset = Vector3.zero;
    [SerializeField] private float m_CamDistance = 2f;
    private float m_StendoDistance = 0f;

    [SerializeField] private Transform m_FallBackTargetTransform = null;

    private GameObject m_Target = null;
    private ProjectileData m_TargetData = null;

    private Vector3 m_LockPos = Vector3.zero;
    private bool m_Locked = false;

    private bool m_CheckNewTarget = false;
    private const string PROJECTILETAG = "Projectile";

    private void Awake()
    {
        m_StendoDistance = m_CamDistance;
    }

    private void Start()
    {
        if(m_CamPos == null)
            m_CamPos = transform;
        transform.LookAt(m_FallBackTargetTransform);
    }

    private void Update()
    {
        if (m_Target != null)
        {
            if(m_TargetData.HitPart && !m_Locked)
            {
                m_LockPos = m_Target.transform.position;
                m_Locked = true;
            }

            if(m_TargetData.HitPart)
            {
                transform.position = m_LockPos + m_Offset;
                m_StendoDistance = m_StendoDistance + Time.deltaTime * 0.3f;
                m_Offset = m_Offset.normalized * m_StendoDistance;
            }
            else
                transform.position = m_Target.transform.position + m_Offset;
        }
        else if (m_Locked)
        {
            m_Locked = false;
            m_LockPos = Vector3.zero;
            m_StendoDistance = m_CamDistance;
        }
        else if (!m_CheckNewTarget)
        {
            m_CheckNewTarget = true;
            transform.position = m_CamPos.position;
            transform.rotation = m_CamPos.rotation;
        }

        if(m_CheckNewTarget)
        {
            transform.position = m_CamPos.position;
            transform.rotation = m_CamPos.rotation;
            var projectile = GameManager.Instance.CurrentProjectile;

            if (projectile != null)
            {
                LinkTarget(projectile);
            }
        }
    }

    private void LinkTarget(GameObject projectile)
    {
        var unitOffset = (m_CamPos.position - projectile.transform.position).normalized;
        m_Offset = unitOffset * m_CamDistance;
        m_TargetData = projectile.GetComponent<ProjectileData>();
        m_CheckNewTarget = false;
        m_Target = projectile;
    }
}
