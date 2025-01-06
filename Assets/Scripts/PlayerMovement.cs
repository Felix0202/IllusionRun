using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 20f;
    private bool isGrounded;
    private float xInput;
    public Rigidbody2D body;

    // Start is called before the first frame update
    // do not set rigidbody2d in start, it will not work
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal") * speed;
        body.velocity = new Vector2(xInput, body.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}