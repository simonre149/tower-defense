using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public int detectRadius;
    public float closeThreshold;

    NavMeshAgent agent;
    SphereCollider detectCollider;
    GameObject target;

    void Start()
    {
        detectCollider = GetComponent<SphereCollider>();
        detectCollider.radius = detectRadius;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target)
        {
            agent.destination = target.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        if (otherGameObject.tag == "Enemy")
        {
            if (target)
            {
                float distanceToOther = Vector3.Distance(transform.position, otherGameObject.transform.position);
                float distanceToCurrentTarget = Vector3.Distance(transform.position, target.transform.position);
                if (distanceToCurrentTarget < distanceToOther) return;
            }
            target = otherGameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        if (otherGameObject == target)
        {
            target = null;
        }
    }
}
