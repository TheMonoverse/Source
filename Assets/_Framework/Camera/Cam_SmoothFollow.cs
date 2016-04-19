using UnityEngine;
using System.Collections;

public class Cam_SmoothFollow : MonoBehaviour {

    public GameObject targetPlayer;


    public float smoothing = 5f;

    void FixedUpdate()
    {
        if (targetPlayer != null)
        {
            transform.position = Vector3.Lerp(transform.position, targetPlayer.transform.position, smoothing * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }

    }

}
