using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {
	//hello
    public string mName;

    Rigidbody2D rb;

    GameController gc;

    private float move;


    /// <summary>
    /// Ground Check Variables
    /// </summary>
    public LayerMask groundLayer;//layer that is considered grounded. 
    private bool grounded = false;
    private float groundRadius = 0.1f;
    [SerializeField]
    Transform groundCheck;
    //----//

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
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
        float jump = 0f;
        if (move > 0.1f || move < -0.1f)
        {
            rb.AddForce( new Vector2( move * 20f , 0f) );
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -5f, 5f), Mathf.Clamp(rb.velocity.y, -15f, 5f), 0f);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, 500f));
            jump = 1f;
        }
      

    }
}
