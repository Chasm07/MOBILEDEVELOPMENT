using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveF = 10f;

    [SerializeField]
    private float jumpF = 11f;

    private float xMovement;

    private SpriteRenderer sr;

    private Rigidbody2D rd;

    private bool isGrounded;

    private string check_ground = "Ground";

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();


        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMove()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(xMovement, 0f, 0f) * moveF * Time.deltaTime;
    }

    

    void PlayerJump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rd.velocity = new Vector2(rd.velocity.x, jumpF);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(check_ground))
        {
            isGrounded = true;
        }
    }

}
