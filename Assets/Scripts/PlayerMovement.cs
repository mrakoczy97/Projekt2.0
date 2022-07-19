using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public float playerRadius;
    public Animator animator;
    public SpriteRenderer _renderer;
    public AnimationCurve movementSpeed;
    private float time = 0;
  
    // Start is called before the first frame update
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        ProcessAnimation();

        if(Input.GetKeyDown(KeyCode.Space))
        {
           // Dash();
        }
    }
    void FixedUpdate()
    {
        Move();

    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void ProcessAnimation()
    {

        float vertical=Mathf.Abs(Input.GetAxisRaw("Vertical"));
        float horizontal = Input.GetAxisRaw("Horizontal");
        // obracanie sprite dla Lewo/Prawo
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _renderer.flipX = false;
            
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _renderer.flipX = true;
        }
        // Góra/Dó³
        if (vertical != 0)
        {
            if (horizontal == 0)
            {
                animator.SetBool("GoUD", true);
                animator.SetBool("GoLR", false);
            }
            else
            {
                animator.SetBool("GoLR", true);
                animator.SetBool("GoUD", false);
            }
        }
        else
        {
            animator.SetBool("GoUD", false);
        }

        // Lewo/Prawo
        if (horizontal != 0)
        {
            animator.SetBool("GoLR", true);
        }
        else
        {
            animator.SetBool("GoLR", false);
        }
    }

    void Move()
    {
        
        time += Time.deltaTime;
        Debug.Log(moveDirection);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
       // rb.MovePosition((rb.position+ moveDirection * moveSpeed  * Time.fixedDeltaTime ) * movementSpeed.Evaluate(time));
    }



}
