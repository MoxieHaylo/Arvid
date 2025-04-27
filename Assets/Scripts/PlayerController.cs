using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float flightSpeed;
    public bool isGrounded = true;

    public Transform groundedCheck;
    public float groundedCheckRadius;
    public LayerMask groundLayer;

    public int maxFlightStamina = 1;
    public int currentFlightStamina;
    public FlightStaminaBar flightStaminaBar;

    public float rememberGroundedFor;
    float lastTimeGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentFlightStamina = maxFlightStamina;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fly();
        CheckIfGrounded();
        if(currentFlightStamina == maxFlightStamina)
        {
            flightStaminaBar.UpdateFlightStamina(1f);
        }
    }

    //Move the player left and right
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        // Move the player left and right using our speed
        float moveBy = x * speed;
        rb.linearVelocity = new Vector2(moveBy, rb.linearVelocity.y);



        // Flip the player sprite based on movement direction
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing right
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing left
        }
    }

    //Make the player jump
    void Fly()
    {
        // Press space to jump. Check to see if we're on the ground
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || currentFlightStamina > 0))
        {
            Debug.Log("flap flap");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, flightSpeed);
            currentFlightStamina--;
            flightStaminaBar.UpdateFlightStamina((float)currentFlightStamina/(float)maxFlightStamina);
        }
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || currentFlightStamina < 1))
        {
            Debug.Log("I can't fly. Need hugs!");
        }

    }

    //Check if we're on the ground layer.
    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundedCheck.position, groundedCheckRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }
}
