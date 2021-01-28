using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask plataformLayerMask;
    [SerializeField] private float extraHeight;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;

    private bool lookingRight = true;
    private PlayerController pc;
    private SpriteRenderer sr;
    private Animator animatorPlayer;
    private Rigidbody2D playerRigidbody;
    private Collider2D playerMainCollider;


    private void Awake()
    {

        pc = new PlayerController();
        sr = GetComponentInChildren<SpriteRenderer>();
        animatorPlayer = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerMainCollider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        pc.Terrain.Enable();
    }

    private void OnDisable()
    {
        pc.Terrain.Disable();

    }
    // Start is called before the first frame update
    void Start()
    {
        pc.Terrain.Jump.performed += _ => Jump();
    }

    private void FixedUpdate()
    {
        float movement = pc.Terrain.Move.ReadValue<float>();
        if (movement != 0)
        {
            if ((movement < 0 && lookingRight) || (movement > 0 && !lookingRight))
            {
                lookingRight = !lookingRight;
                transform.Rotate(new Vector3(0, 180, 0), Space.Self);
            }


            // sr.flipX = movement < 0;

            if (IsGrounded())
            {
                animatorPlayer.SetBool("isWalking", true);

            }

        }
        else
        {
            if (IsGrounded())
            {
                animatorPlayer.SetBool("isWalking", false);
            }
        }

        transform.position += new Vector3(movement * Time.deltaTime * speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

        animatorPlayer.SetBool("hasJump", !IsGrounded());
        animatorPlayer.SetFloat("jumpVelocity", playerRigidbody.velocity.y);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerMainCollider.bounds.center, playerMainCollider.bounds.size, 0f, Vector2.down, extraHeight, plataformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        bool result = raycastHit.collider != null;


        Debug.DrawRay(playerMainCollider.bounds.center + new Vector3(playerMainCollider.bounds.extents.x, 0), Vector2.down * (playerMainCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(playerMainCollider.bounds.center - new Vector3(playerMainCollider.bounds.extents.x, 0), Vector2.down * (playerMainCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(playerMainCollider.bounds.center - new Vector3(playerMainCollider.bounds.extents.x, playerMainCollider.bounds.extents.y + extraHeight), Vector2.right * playerMainCollider.bounds.extents.x * 2, rayColor);

        return result;
    }

    private void Jump()
    {
        playerRigidbody.AddForce(Vector2.up * jumpSpeed);

    }


}
