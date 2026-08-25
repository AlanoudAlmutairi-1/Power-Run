using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform player;

    public float speed = 2f;
    public float detectionRange = 5f;
    public float attackRange = 1.5f;

    public int damage = 10;
    public float attackCooldown = 1f;

    bool goingToB = true;
    float attackTimer = 0f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            AttackPlayer();
        }
        else if (distance <= detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (goingToB)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                pointB.position,
                speed * Time.deltaTime
            );

            if (transform.position == pointB.position)
            {
                goingToB = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                pointA.position,
                speed * Time.deltaTime
            );

            if (transform.position == pointA.position)
            {
                goingToB = true;
            }
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }

    void AttackPlayer()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            PlayerHealth health = player.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }

            attackTimer = attackCooldown;
        }
    }
}