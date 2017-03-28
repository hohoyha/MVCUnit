using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5;
    private Animator anim;
    private Rigidbody2D myRigibody;

    private bool playerMoving;
    public Vector2 lastMove;

    private static bool playerExists = false;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        myRigibody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        playerMoving = false;

        if (!attacking)
        {
            if (h > 0.5f || h < -0.5f)
            {
                //transform.Translate(new Vector3(h * moveSpeed * Time.deltaTime, 0, 0));
                myRigibody.velocity = new Vector2(h * moveSpeed, myRigibody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(h, 0);
            }

            if (v > 0.5f || v < -0.5f)
            {
                //  transform.Translate(new Vector3( 0, v * moveSpeed * Time.deltaTime, 0));
                myRigibody.velocity = new Vector2(myRigibody.velocity.x, v * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0, v);
            }

            if (h < 0.5f && h > -0.5f)
            {
                myRigibody.velocity = new Vector2(0, myRigibody.velocity.y);
            }

            if (v < 0.5f && v > -0.5f)
            {
                myRigibody.velocity = new Vector2(myRigibody.velocity.x, 0);
            }
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            attackTimeCounter = attackTime;
            attacking = true;
            myRigibody.velocity = Vector2.zero;
            anim.SetBool("Attack", true);
        }

        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", h);
        anim.SetFloat("MoveY", v);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

        anim.SetBool("Moving", playerMoving);

    }
}
