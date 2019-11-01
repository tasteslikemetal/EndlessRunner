using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public float SPEED = 10;
    public float SUPERSPEED = 20;
    public float JUMPFORCE = 20;
    public float PUSHDOWN = 40;

    public bool isJumping;
    public bool isGrounded;
    public bool isCrouched;
    public bool isSuper;
    public bool canDie;

    public Rigidbody rb;

    Vector3 moveDirection;

    int maxJumps = 2;
    int curJump;

    //public bool canDissolve;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection = Vector3.zero;
        isJumping = false;
        isGrounded = false;
        isCrouched = false;
        isSuper = false;
        canDie = true;
        curJump = 1;

        //canDissolve = false;
    }

    void Update()
    {
        //Debug.Log(curJump);
        if (GameManager.instance.state != GameManager.eState.PLAY)//returns nothing if not in play state
        {
            if (Input.GetKeyDown(KeyCode.P))//pauses game - on flip flop switch
            {
                GameManager.instance.PauseGame();
            }
            rb.velocity = new Vector3(0, 0, 0);
            rb.useGravity = false;
            return;
        }
        if (!isSuper)
        {
            //GameManager.instance.multiplierSpeed *= 1;
            rb.useGravity = true;
            canDie = true;
            BaseControls();
        }
        else
        {
            //GameManager.instance.multiplierSpeed *= 2;
            rb.useGravity = false;
            canDie = false;
            SuperControls();
        }        
    }

    IEnumerator superTimer()
    {
        yield return new WaitForSeconds(5);
        isSuper = false;
        GameManager.instance.scoreManager.scoreMultiplier /= 10;
    }

    public void DoSuper()
    {
        isSuper = true;
        GameManager.instance.scoreManager.scoreMultiplier *= 10;
        StartCoroutine(superTimer());
    }

    void SuperControls()
    {
        if (Input.GetKeyDown(KeyCode.P))//pauses game - on flip flop switch
        {
            GameManager.instance.PauseGame();
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -20f, 6.6f), transform.position.z);//clamps movement SAFETY NET
        rb.velocity = new Vector3(rb.velocity.x, moveDirection.y * SUPERSPEED, rb.velocity.z);
        moveDirection.y = Input.GetAxis("Vertical");
    }



    public void BaseControls()
    {
        #region player scroll with platform
        /*if (moveDirection == Vector3.zero && !isJumping)//make move with platform scroll when landed
        {
            transform.position += Vector3.left * Time.deltaTime * (PlatformMover.instance. SPEED * GameManager.instance.multiplierSpeed);
        }

        moveDirection.x = 1;
        rb.velocity = new Vector3(moveDirection.x * SPEED, rb.velocity.y, rb.velocity.z);
        Debug.Log(rb.velocity.x);
*/
        #endregion
        //Movement();

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -20f, 6.6f), transform.position.z);//clamps movement SAFETY NET

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//jump
        {
            if (!isCrouched)
            {
                if (!isGrounded)
                {
                    if (curJump > 0 && curJump < maxJumps)
                    {
                        Jump();
                    }
                }
                else
                {
                    Jump();
                }
            }
            else
            {
                UnCrouch();
                if (!isGrounded)
                {
                    if (curJump > 0 && curJump < maxJumps)
                    {
                        Jump();
                    }
                }
                else
                {
                    Jump();
                }
            }
        }

        if(isGrounded)
        {
            curJump = 1;
        }



        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//crouch
        {
            Crouch();
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            UnCrouch();
        }


        if(isJumping && isCrouched)//slam down
        {
            Slam();
        }


        if (Input.GetKeyDown(KeyCode.P))//pauses game - on flip flop switch
        {
            GameManager.instance.PauseGame();
        }
    }

    #region for platformer movement left and right
    /*void Movement()//for platformer movement left and right
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.4f, 8.4f), Mathf.Clamp(transform.position.y, -10f, 4.0f), transform.position.z);//clamps movement and handles left right input
        rb.velocity = new Vector3(moveDirection.x * SPEED, rb.velocity.y, rb.velocity.z);
        moveDirection.x = Input.GetAxis("Horizontal");
    }*/
    #endregion

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, JUMPFORCE, rb.velocity.z);
        isJumping = true;
        curJump++;
    }

    void Crouch()
    {
        transform.localScale = new Vector3(1.5f, 0.5f, transform.localScale.z);
        isCrouched = true;
    }

    void UnCrouch()
    {
        transform.localScale = new Vector3(1, 1, transform.localScale.z);
        isCrouched = false;
    }

    void Slam()
    {
        rb.velocity = new Vector3(rb.velocity.x, -PUSHDOWN, rb.velocity.z);
    }


}
