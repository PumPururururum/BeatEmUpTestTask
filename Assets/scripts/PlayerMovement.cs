using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerHealth health;
    private Animator animator;
    public FixedJoystick joystick;
    private Rigidbody rb;

    public float attackRate = 1f;
    public float moveSpeed;
    private float rotationY = 90f;
    private Vector3 movement;

    private bool canMove = true;
    public bool attacking = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        health = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        RotatePlayer();

        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    private void MovePlayer()
    {
        movement = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y);
        if (movement.magnitude >= 0.1f && canMove)
        {

            characterController.Move(movement * Time.deltaTime * moveSpeed);

        }
    }
    private void RotatePlayer()
    {
        if (movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, Mathf.Abs(rotationY), 0);
        }
        else
        if (movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -Mathf.Abs(rotationY), 0);
        }
        //Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    public void Punch()
    {
        if (!attacking && !health.isDead)
        {
            animator.SetTrigger("Punch");
            Attack();
        }
    }

    public void Kick()
    {
        if (!attacking && !health.isDead)
        {
            animator.SetTrigger("Kick");
            Attack();
        }
    }
    private void Attack()
    {
        attacking = true;
        Invoke(nameof(ResetAttack), attackRate);
    }
    private void ResetAttack()
    {
        attacking = false;
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
