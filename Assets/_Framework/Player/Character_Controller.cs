using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {
	
    //Character's name
    public string mName;

    

    ///Physics Variables
    Rigidbody2D rb;
    private float move;

    /// Ground Check Variables
    public LayerMask groundLayer;//layer the player needs to touch in order to jump.
    private bool grounded = false;
    private float groundRadius = 0.1f;
    [SerializeField]
    Transform groundCheck;

    ///Script references
    GameController gc; //

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        //gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        StatusCheck();
        PlayerInput();
	}

    void StatusCheck() 
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    void PlayerInput() 
    {
        move = Input.GetAxis("Horizontal");
        
        if (move > 0.1f || move < -0.1f)
        {
            rb.AddForce( new Vector2( move * 20f , 0f) );
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -5f, 5f), Mathf.Clamp(rb.velocity.y, -15f, 5f), 0f);
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(0f, 500f));
            
        }
      

    }
}
