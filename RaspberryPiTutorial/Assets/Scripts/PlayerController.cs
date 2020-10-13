using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Movement
    public int walkSpeed;
    public int runSpeed;
    int speed;
    public Rigidbody rb;
    Vector3 direction;

    // Jumping
    public float jumpSpeed;
    public Transform groundCheck;
    public float groundDistance;
    bool isGrounded;
    public LayerMask groundMask;

    public Camera cam;

    // Interaction
    public bool canInteract;
    public Text interactText;

    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        interactText.enabled = canInteract;

        if (Input.GetButton("Sprint"))
        {
            speed = runSpeed;
        } else {
            speed = walkSpeed;
        }

        Move();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Interact") && canInteract)
        {
            Interact();
        }
    }

    void Move()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + transform.TransformDirection(direction * speed * Time.deltaTime));
    }

    void Jump()
    {
        rb.velocity = new Vector3(0f, jumpSpeed, 0f);
    }

    void Interact()
    {
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10))
        {
            Interactables interactable = hit.collider.GetComponent<Interactables>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
