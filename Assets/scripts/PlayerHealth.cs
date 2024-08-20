using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    private int currenHealth;
    public int maxHealth;
    private Animator animator;
    private PlayerMovement playerMovement;

    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();    
        currenHealth = maxHealth;
        healthBar.SetMaxHealth(currenHealth);
    }
    public void TakeDamage(int damage)
    {
        currenHealth -= damage;
        healthBar.SetHealth(currenHealth);
        if (currenHealth <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        animator.SetTrigger("Death");
        playerMovement.LockMovement();
        isDead = true;
        Invoke(nameof(GameOver),3);
    }

    private void GameOver()
    { 
        UIManager uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        uiManager.TurnOnGameOver();
    }
   
}
