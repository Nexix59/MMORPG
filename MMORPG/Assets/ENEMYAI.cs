using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYAI : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public float speed = 5f;
    public float attackDistance = 2f;
    public float fovAngle = 90f;
    public float viewDistance = 10f;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Move()
    {
        // Move towards player
        Vector3 direction = player.transform.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    public void Attack()
    {
        // Deal damage to player
        FirstPersonController FirstPersonController = player.GetComponentInChildren<FirstPersonController>();
        if (FirstPersonController != null)
        {
            FirstPersonController.OnTakeDamage(damage);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        // Check if player is within field of view
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float angleToPlayer = Vector3.Angle(directionToPlayer, transform.forward);

        if (angleToPlayer <= fovAngle * 0.5f)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, directionToPlayer, out hitInfo, viewDistance))
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    Attack();
                    return;
                }
            }
        }

        // If player is not within field of view, move towards player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= attackDistance)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }
}
