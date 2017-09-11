using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rbody;
    private Animator animator;
    [SerializeField] private Transform jumpPointA;
    [SerializeField] private Transform jumpPointB;
    [SerializeField] private LayerMask worldCollisionMask;

    [SerializeField] private Vector2 velocity;
    [SerializeField] private Vector2 input;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private bool canJump;
    [SerializeField] private bool canAttack;
    [SerializeField] private bool canReadInput = true;
    [SerializeField] private bool canGetHit;

    public bool CanJump
    {
        get { return canJump; }
        set { canJump = value; }
    }

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start()
    {
        
	}
	
	// Update is called once per frame
	void Update()
    {
        if (canReadInput)
        {
            canJump = Physics2D.OverlapArea(jumpPointA.position, jumpPointB.position, worldCollisionMask);
            ReadPlayerAction();
        }

        TickTimers();
    }

    void ReadPlayerAction()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            rbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            print("Jumped");
        }

        if (Input.GetAxisRaw("Horizontal") > 0f) //Walk Right
        {
            input = new Vector2(1, 0);
            velocity = new Vector2(input.x * speed, rbody.velocity.y);
            //return new Vector2(1 * speed, rbody.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f) //Walk Left
        {
            input = new Vector2(-1, 0);
            velocity = new Vector2(input.x * speed, rbody.velocity.y);
            //return new Vector2(-1 * speed, rbody.velocity.y);
        }
        else
        {
            velocity = new Vector2(0, rbody.velocity.y);
        }

        rbody.velocity = velocity;
    }

    void TickTimers()
    {

    }
}
