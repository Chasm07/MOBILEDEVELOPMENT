using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveF = 10f;

    [SerializeField]
    private float jumpF = 11f;

    private Animator anim;

    private float xMovement;

    private SpriteRenderer sr;

    private Rigidbody2D rd;

    private bool grounded;

    private string check_ground = "Ground";
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    private void Update()
    {

            PlayerMove();


            // flip player
            float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
            rd.velocity = new Vector2(horizontalInput * moveF, rd.velocity.y);
            if (horizontalInput > 0.01f)
                transform.localScale = Vector3.one;
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);

            anim.SetBool("run", horizontalInput != 0);
            anim.SetBool("grounded", grounded);
            
    }

    void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMove()
    {
        xMovement = CrossPlatformInputManager.GetAxis("Horizontal");
        transform.position += new Vector3(xMovement, 0f, 0f) * moveF * Time.deltaTime;
        
    }

    

    void PlayerJump()
    {
        if (CrossPlatformInputManager.GetButton("Jump") && grounded)
        {
            grounded = false;
            anim.SetTrigger("jump");
            rd.velocity = new Vector2(rd.velocity.x, jumpF);
            SoundManager.instance.PlaySound(jumpSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(check_ground))
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Powerups")
        {
            Destroy(collision.gameObject);
            jumpF = 35f;
            moveF = 25f;
            StartCoroutine(ResetPower());
        }
    }

    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(5);
        jumpF = 20;
        moveF = 15;
    }


}
