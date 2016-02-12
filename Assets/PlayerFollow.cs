using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

    [SerializeField]
    Transform follow;
    [SerializeField]
    float followScale;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 tar = new Vector3(follow.position.x, follow.position.y, transform.position.z);
        tar = (tar-transform.position) * followScale *Time.deltaTime;
        tar.z = 0f;
       transform.Translate(tar);
	}
}
