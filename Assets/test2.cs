using UnityEngine;
using System.Collections;

public class test2 : MonoBehaviour
{
    Vector2 offset;
    Vector2 size;
    // Use this for initialization
    void Start()
    {
        offset = new Vector2(0f, 0f);
        size = new Vector2(1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        size.y = Mathf.Max(0.5f, size.y - (0.1f * Time.deltaTime));

        // GetComponent<Camera>().rect = new Rect(new Vector2(0, 0), new Vector2(1,0.25f));


        // setup the rectangle
        GetComponent<Camera>().rect = new Rect(offset.x, offset.y, size.x, size.y);
    }
}
