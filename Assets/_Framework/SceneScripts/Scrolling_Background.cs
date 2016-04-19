using UnityEngine;
using System.Collections;

public class Scrolling_Background : MonoBehaviour {

    [SerializeField]
    float scrollSpeed = 5f;

    public void Scroll(Vector3 direction) 
    {
        Vector3 movement = new Vector3(direction.x * scrollSpeed, direction.y * scrollSpeed, 0f);
        


        transform.Translate(movement);
    }
}
