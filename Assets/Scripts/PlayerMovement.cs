using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public float JumpForce = 1f;

    private Rigidbody2D _rigidbody;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    private enum MovementState { idle, running, jumping, falling }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateAnimation();
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckInteraction();
        }

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            Jump();
        }
    }

    private void UpdateAnimation()
    {
        MovementState state;
        //movement with transition & animation
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector2(-1, 1);
            state = MovementState.running;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(1, 1);
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (_rigidbody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (_rigidbody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.GetComponent<Interact2D>())
                {
                    hit.transform.GetComponent<Interact2D>().Interact();
                    return;
                }
            }
        }
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    }
}

