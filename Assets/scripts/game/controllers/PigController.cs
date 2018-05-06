using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PigController : MonoBehaviour
{
    public Transform TargetTransform { get; private set; }

    public float Speed { get; set; }

    NavMeshAgent m_agent;

    private void Start ()
    {
        m_agent = GetComponent<NavMeshAgent>();

        if(m_agent != null)
        {
            if (Speed > 0f)
                m_agent.speed = Speed;
        }
        else
        {
            Debug.LogError("Unable to find agent on Pig prefab");
        }
    }

    private void FixedUpdate ()
    {
        m_agent.SetDestination(TargetTransform.position);
    }

    public void SetTargetPosition(Transform t)
    {
        TargetTransform = t;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.isTrigger && collider.tag == TagConstants.HOUSE_TRIGGER_TAG)
        {
            HouseController houseController = collider.gameObject.GetComponentInParent<HouseController>();
            houseController.RemoveTransit(1);
            houseController.AddPigs(1);
            Destroy(this.gameObject);
        }
    }
}
