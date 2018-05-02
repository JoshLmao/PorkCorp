using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VehicleController : MonoBehaviour
{
    public event System.Action<GameObject> OnVehicleFinished;

    public ISellVehicle Info { get; set; }

    Vector3 m_stopTarget;
    Vector3 m_endTarget;

    float m_travelCounter = 0f;

    bool m_isMoving;
    bool m_hasReachedTarget = false;
    bool m_hasReachedEnd = false;
    bool m_isWaiting = false;

    NavMeshAgent m_agent = null;
    Vector3 m_targetPosition = Vector3.zero;
    Coroutine m_deliverCoroutine = null;

    const float TRAVEL_TIME_SECONDS = 10f;
    const float DROP_OFF_TIME_SECONDS = 5f;

    protected virtual void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Start()
    {
        SetTargetPosition(m_stopTarget);
    }

    protected virtual void Update()
    {
        if (m_isMoving)
            m_agent.SetDestination(m_targetPosition);

        float dist = m_agent.remainingDistance;
        if (!m_agent.pathPending)
        {
            if (dist != Mathf.Infinity && m_agent.pathStatus == NavMeshPathStatus.PathComplete && m_agent.remainingDistance == 0)
            {
                m_isMoving = false;

                if(!m_hasReachedTarget)
                {
                    OnReachedTarget();
                    m_hasReachedTarget = true;
                    
                }
                else if(!m_hasReachedEnd && m_deliverCoroutine == null)
                {
                    OnReachedEnd();
                    m_hasReachedEnd = true;
                }
            }
        }
    }

    IEnumerator WaitDeliver(Vector3 newTargetPosition)
    {
        yield return new WaitForSeconds(DROP_OFF_TIME_SECONDS);

        SetTargetPosition(m_endTarget);
        m_deliverCoroutine = null;
    }

    void SetTargetPosition(Vector3 pos)
    {
        m_targetPosition = pos;
        m_isMoving = true;
    }

    /// <summary>
    /// Target position where the vehicle will stop and wait
    /// </summary>
    /// <param name="target"></param>
    public void SetStop(Vector3 target)
    {
        m_stopTarget = target;
    }

    /// <summary>
    /// End position where to vehicle will be destoryed (off screen)
    /// </summary>
    /// <param name="end"></param>
    public void SetEnd(Vector3 end)
    {
        m_endTarget = end;
    }

    protected virtual void OnReachedTarget()
    {
        if (m_deliverCoroutine == null)
        {
            m_deliverCoroutine = StartCoroutine(WaitDeliver(m_endTarget));
        }
    }

    protected virtual void OnReachedEnd()
    {
        OnVehicleFinished?.Invoke(this.gameObject);
    }
}
