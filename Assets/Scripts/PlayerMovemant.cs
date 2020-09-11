using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemant : MonoBehaviour
{
    /* Global variables */

    public float movemantSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 _movemant;


    /* Global variables */

    private void Update()
    {
        _movemant.x = Input.GetAxisRaw("Horizontal");
        _movemant.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", _movemant.x);
        animator.SetFloat("Vertical", _movemant.y);
        animator.SetFloat("Speed", _movemant.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movemant * movemantSpeed * Time.fixedDeltaTime);
    }
}
