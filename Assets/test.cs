using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
    Vector2 offset;
    // Use this for initialization
    void Start () {
        offset = new Vector2(0f,1f);
    }
	
	// Update is called once per frame
	void Update () {
       offset.y = Mathf.Max(0.5f,offset.y-(0.1f * Time.deltaTime));

       // GetComponent<Camera>().rect = new Rect(new Vector2(0, 0), new Vector2(1,0.25f));

        
        // setup the rectangle
        GetComponent<Camera>().rect = new Rect(offset.x, offset.y, 1 , 0.5f);
    }
}
