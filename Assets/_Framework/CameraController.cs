using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CameraController : MonoBehaviour {

    public static CameraController Instance;



    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;


        DontDestroyOnLoad(gameObject);     
    }

	// Update is called once per frame
	void Update () {
	
	}

    void SetCameraPositions() 
    {
        
    }


}

