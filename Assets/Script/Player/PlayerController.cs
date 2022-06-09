using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool doubleJump;
    public float pushForce;
    [SerializeField] public float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public Vector3 move; //Direction
    
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        var forward = Camera.main.transform.forward;
        var right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        move = forward * verticalAxis + right * horizontalAxis;
        controller.Move(move.normalized * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
            //anim.SetBool("isPushing", false);
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            Jump();
            doubleJump = true;
        }
        // Double Jump
        else if (Input.GetButtonDown("Jump") && doubleJump == true)
        {
            Jump();
            doubleJump = false;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
    }

    public void Jump() {
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        anim.SetTrigger("isJumping");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if(rb != null && hit.collider.CompareTag("Box"))
        {
            rb.velocity = hit.moveDirection * pushForce;
        }
    }
}