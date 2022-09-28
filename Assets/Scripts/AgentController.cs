using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public int teamId, detectRadius;
    public float closeThreshold, life = 5, attackAmount = 1, attackCooldown = 1;

    NavMeshAgent agent;
    SphereCollider detectCollider;
    GameObject target;

    float nextPossibleAttackTime;

    void Start()
    {
        detectCollider = GetComponent<SphereCollider>();
        detectCollider.radius = detectRadius;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
        if (target)
        {
            if (Vector3.Distance(target.transform.position, transform.position) > closeThreshold)
            {
                agent.destination = target.transform.position;
            } 
            else
            {
                if (Time.time > nextPossibleAttackTime)
                {
                    attack(target);
                    nextPossibleAttackTime = Time.time + attackCooldown;
                }
            }
        }
    }

    private void attack(GameObject target)
    {
        target.GetComponent<AgentController>().life -= attackAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        if (otherGameObject.tag == "Agent" && otherGameObject.GetComponent<AgentController>().teamId != teamId)
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
