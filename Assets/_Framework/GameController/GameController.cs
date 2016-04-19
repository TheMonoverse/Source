using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    Scrolling_Background[] backgrounds;

    void Start() 
    {
       backgrounds = FindObjectsOfType<Scrolling_Background>();
       
    }

    public void ScrollBackgrounds(Vector3 direction) 
    {
        for (int backgroundIndex = 0; backgroundIndex < backgrounds.Length; backgroundIndex++)
        {
            backgrounds[backgroundIndex].Scroll(direction);
        }
    }


}
