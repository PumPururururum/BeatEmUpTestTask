using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour, IPooledObject
{
    private NavMeshAgent agent;
    private Transform playerPosition;
    private Animator animator;
    public LayerMask whatIsGround, whatIsPlayer;
    
    public float attackRange;
    public float attackRate;
    private bool playerInAttackRange;
    private bool followPlayer;
    private bool attacking;
    private bool canMove;
    public int maxHealth;
    private int currentHealth;
  
    // Start is called before the first frame update
    public void OnObjectSpawn()
    {
    
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        followPlayer = true;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInAttackRange && followPlayer)
        {
            ChasePlayer();
            RotateEnemy();
        }
        if (playerInAttackRange && followPlayer ) AttackPlayer();

    }
    private void ChasePlayer()
    {
        agent.SetDestination(playerPosition.position);
        animator.SetFloat("Speed", 1);

    }
    private void AttackPlayer()
    {
        transform.LookAt(playerPosition);
        agent.SetDestination(transform.position);
        animator.SetFloat("Speed", 0);
        ;
        if (!attacking)
        {
            RandomAttackAnimation();
            attacking = true;
            Invoke(nameof(ResetAttack), attackRate);
        }
    }
    private void ResetAttack()
    {
        attacking = false;
    }

    private void RandomAttackAnimation()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
            animator.SetTrigger("Punch");
        else
            animator.SetTrigger("Kick");
    }
    private void RotateEnemy()
    {
        agent.updateRotation = false;
        // transform.LookAt(playerPosition);
        Vector3 normalizedMovement = agent.desiredVelocity.normalized;
        if (normalizedMovement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, Mathf.Abs(90), 0);
        }
        else
       if (normalizedMovement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -Mathf.Abs(90), 0);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        animator.SetTrigger("Death");
        followPlayer = false;
        Invoke(nameof(DestroyEnemy), 3f);
    }
    public void DestroyEnemy()
    {
        gameObject.SetActive(false);
    }
    public void LockMovement()
    {
        canMove = false;
    }
    public void UnlockMovement()
    {
        canMove = true;
    }

   
}
