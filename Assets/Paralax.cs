using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour {
    
    Vector2 orPos;
    Vector2 orCamPos;
    [SerializeField]
    Transform myCamera;
    [SerializeField]
    Vector2 scale;

	// Use this for initialization
	void Start () {
        orPos = transform.position;
        orCamPos = myCamera.position;
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 offset = Vector2.Scale((Vector2)myCamera.position - orCamPos, scale);
        transform.position = new Vector3(offset.x,offset.y,transform.position.z);
	}
}
