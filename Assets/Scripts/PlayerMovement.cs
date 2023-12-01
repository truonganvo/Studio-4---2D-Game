using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

    
{
    [Header("Analytics To Track")]
    [SerializeField] private int numberInteract = 0;


    public float MovementSpeed = 1f;
    public float JumpForce = 1f;

    private Rigidbody2D _rigidbody;
    //public Animator animator;
    //[SerializeField] AudioSource jumpingSound;

    private Vector2 boxSize = new Vector2(0.1f, 1f);

    private enum MovementState { idle, running, jumping, falling }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        //jumpingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateAnimation();
        if (Input.GetKeyDown(KeyCode.E))
        {
            numberInteract++;
            CheckInteraction();
            GameAnalytics.NewDesignEvent("PlayerPressE", numberInteract);
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

        //jumping & animation
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            //jumpingSound.Play();
        }
        if (_rigidbody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (_rigidbody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        //animator.SetInteger("state", (int)state);
    }

    private void CheckInteraction() //This need the Interact2D script to work with
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
}
