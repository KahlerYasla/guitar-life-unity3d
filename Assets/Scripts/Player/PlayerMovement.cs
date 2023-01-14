using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 3f;
    private Rigidbody2D myRigidbody;
    private Vector3 playerMovement;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Get the Raw input from the player
        playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        // Normalize the vector to prevent diagonal movement from being faster
        playerMovement.Normalize();

        UpdateAnimationAndMove();
    }

    private void UpdateAnimationAndMove()
    {
        if (playerMovement != Vector3.zero)
        {
            // Move the player
            MoveCharacter();
            animator.SetFloat("moveX", playerMovement.x);
            animator.SetFloat("moveY", playerMovement.y);
            animator.SetBool("moving", true);
        }
        else
        {
            // Stop the player
            animator.SetBool("moving", false);
        }
    }

    private void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + playerMovement * speed * Time.deltaTime);
    }
}
