using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {

    Rigidbody2D rb;

    private float move;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayerInput();
	}

    void PlayerInput() 
    {
        move = Input.GetAxis("Horizontal");
        if (move > 0.1f || move < -0.1f)
        {
            rb.AddForce( new Vector2( move * 20f , 0f) );
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, 500f));
        }
    }
}
