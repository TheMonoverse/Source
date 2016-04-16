using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Cam_ScreenMover : MonoBehaviour {


    public List<Cam_Status_Holder> screenStatuses = new List<Cam_Status_Holder>();

    public Camera space;
    public Camera jungle;
    public Camera japan;
    public Camera viking;

    public void CreateNewLayout(Cam_Status_Holder cStat) 
    {
        screenStatuses.Add(cStat);
    }

    public void TransitionTo(Cam_Status transTo)//Will also take a transition duration and type.
    {
    
    }




}
