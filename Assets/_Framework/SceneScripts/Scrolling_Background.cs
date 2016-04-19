using UnityEngine;
using System.Collections;

public class Scrolling_Background : MonoBehaviour {

    [SerializeField]
    float scrollSpeed = 5f;

    public void Scroll(Vector3 direction) 
    {
        Vector3 movement = direction * scrollSpeed ;
        Debug.Log(movement);
        transform.Translate(movement);
    }
}
