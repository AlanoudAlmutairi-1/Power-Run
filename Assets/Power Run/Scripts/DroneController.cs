using UnityEngine;
using UnityEngine.AI;

public class DroneController : MonoBehaviour
{
    public Transform player;
    public bool isChasing = false;

    public int damage = 10;
    public float attackDistance = 2f;
    public float damageTime = 1f;

    private NavMeshAgent agent;
    private PlayerHealth playerHealth;
    private float timer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (isChasing)
        {
            agent.SetDestination(player.position);

            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= attackDistance)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    playerHealth.TakeDamage(damage);
                    timer = damageTime;
                }
            }
        }
    }
}