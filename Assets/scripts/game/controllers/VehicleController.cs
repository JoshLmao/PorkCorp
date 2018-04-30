using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public event System.Action<GameObject> OnVehicleFinished;

    public ISellVehicle Info { get; set; }

    Vector3 m_startPosition;
    Vector3 m_stopTarget;
    Vector3 m_endTarget;

    float m_travelCounter = 0f;

    bool m_reachedStopTarget;
    bool m_reachedEndTarget;

    const float TRAVEL_TIME_SECONDS = 10f;
    const float DROP_OFF_TIME_SECONDS = 5f;

    private void Start()
    {
        m_startPosition = this.transform.position;
        StartCoroutine(MoveVehicleToTarget());
    }

    private void Update()
    {
        //if (!m_reachedStopTarget)
        //{
        //    Vector3 lerped = Vector3.Lerp(m_startPosition, m_stopTarget, m_travelCounter);
        //    transform.position = new Vector3(lerped.x, m_startPosition.y, lerped.z);
        //    m_travelCounter += Time.deltaTime / TRAVEL_TIME_SECONDS;

        //    if (m_travelCounter >= 1f)
        //    {
        //        m_travelCounter = 0f;
        //        m_reachedStopTarget = true;
        //        StartCoroutine(WaitDeliver());
        //    }
        //}
        //else if(!m_reachedEndTarget)
        //{
        //    Vector3 lerped = Vector3.Lerp(m_startPosition, m_stopTarget, m_travelCounter);
        //    transform.position = new Vector3(lerped.x, m_startPosition.y, lerped.z);
        //    m_travelCounter += Time.deltaTime / TRAVEL_TIME_SECONDS;

        //    if (m_travelCounter >= 1f)
        //    {
        //        m_reachedEndTarget = true;
        //        OnVehicleFinished?.Invoke(this.gameObject);
        //    }
        //}
    }

    public void SetTarget(Vector3 target)
    {
        m_stopTarget = target;
    }

    public void SetEnd(Vector3 end)
    {
        m_endTarget = end;
    }

    IEnumerator MoveVehicleToTarget()
    {
        bool reachedTarget = false;
        while (!reachedTarget)
        {
            Vector3 lerped = Vector3.Lerp(m_startPosition, m_stopTarget, m_travelCounter);
            transform.position = new Vector3(lerped.x, m_startPosition.y, lerped.z);
            m_travelCounter += Time.deltaTime / TRAVEL_TIME_SECONDS;

            if (m_travelCounter >= 1f)
            {
                m_travelCounter = 0f;
                reachedTarget = true;
                StartCoroutine(WaitDeliver());
            }

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator WaitDeliver()
    {
        yield return new WaitForSeconds(DROP_OFF_TIME_SECONDS);
        StartCoroutine(MoveVehicleToEnd());
    }

    IEnumerator MoveVehicleToEnd()
    {
        bool reachedTarget = false;
        while(!reachedTarget)
        {
            Vector3 lerped = Vector3.Lerp(m_stopTarget, m_endTarget, m_travelCounter);
            transform.position = new Vector3(lerped.x, m_startPosition.y, lerped.z);
            m_travelCounter += Time.deltaTime / TRAVEL_TIME_SECONDS;

            if (m_travelCounter >= 1f)
            {
                reachedTarget = true;
            }

            yield return new WaitForFixedUpdate();
        }

        OnVehicleFinished?.Invoke(this.gameObject);
    }
}
