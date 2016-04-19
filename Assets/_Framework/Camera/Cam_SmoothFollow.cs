using UnityEngine;
using System.Collections;

public class Cam_SmoothFollow : MonoBehaviour {

    public GameObject targetPlayer;

    [SerializeField]
    float yOffset = 3f;
    public float smoothing = 5f;

    void FixedUpdate()
    {
        if (targetPlayer != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetPlayer.transform.position.x, targetPlayer.transform.position.y + yOffset, targetPlayer.transform.position.z), smoothing * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }

    }

}
