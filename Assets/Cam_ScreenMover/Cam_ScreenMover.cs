using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Cam_ScreenMover : MonoBehaviour {


    public List<Cam_Status_Holder> screenStatuses = new List<Cam_Status_Holder>();

    public Camera space;
    public Camera jungle;
    public Camera japan;
    public Camera viking;

    private Cam_Status_Holder currentStatus;

    delegate void mDelegate();
    mDelegate mDel;

    private float StartTime;

    private Rect spaceRect;
    private Rect jungleRect;
    private Rect japanRect;
    private Rect vikingRect;

    private int testingInt = 0;

    void Awake() 
    {
        currentStatus = GetCurrentStatus();
    }

    public void CreateNewLayout(Cam_Status_Holder cStat) 
    {
        screenStatuses.Add(cStat);
    }

    //Will also take a transition duration.
    public void TransitionTo(Cam_Status transTo)
    {
    
    }

    //Runs the delegate for camera motion here.
    void Update() 
    {
        if (mDel != null)
        {
            mDel();
        }
    }

    public void PayTest() 
    {
        StartTime = Time.time;
        spaceRect = currentStatus.space.rect;
        jungleRect = currentStatus.jungle.rect;
        japanRect = currentStatus.japan.rect;
        vikingRect = currentStatus.viking.rect;

        mDel += MoveSpace;
        mDel += MoveJungle;
        mDel += MoveJapan;
        mDel += MoveViking;

        space.depth = screenStatuses[testingInt].space.renderingOrder;
        jungle.depth = screenStatuses[testingInt].jungle.renderingOrder;
        japan.depth = screenStatuses[testingInt].japan.renderingOrder;
        viking.depth = screenStatuses[testingInt].viking.renderingOrder;

        StartCoroutine(MotionDuration());
    }

    void MoveSpace() // float fracJourney = (Time.time - stepStartTime) / stepDuration;
    {
        space.rect = new Rect((Mathf.Lerp(spaceRect.x, screenStatuses[testingInt].space.rect.x, ((Time.time - StartTime) / 2f)))
                             , (Mathf.Lerp(spaceRect.y, screenStatuses[testingInt].space.rect.y, ((Time.time - StartTime) / 2f)))
                             , (Mathf.Lerp(spaceRect.width, screenStatuses[testingInt].space.rect.width, ((Time.time - StartTime) / 2f)))
                             , (Mathf.Lerp(spaceRect.height, screenStatuses[testingInt].space.rect.height, ((Time.time - StartTime) / 2f))));
    }

    void MoveJungle() 
    {
        jungle.rect = new Rect((Mathf.Lerp(jungleRect.x, screenStatuses[testingInt].jungle.rect.x, ((Time.time - StartTime) / 2f)))
                                , (Mathf.Lerp(jungleRect.y, screenStatuses[testingInt].jungle.rect.y, ((Time.time - StartTime) / 2f)))
                                , (Mathf.Lerp(jungleRect.width, screenStatuses[testingInt].jungle.rect.width, ((Time.time - StartTime) / 2f)))
                                , (Mathf.Lerp(jungleRect.height, screenStatuses[testingInt].jungle.rect.height, ((Time.time - StartTime) / 2f))));
    }

    void MoveJapan() 
    {
        japan.rect = new Rect((Mathf.Lerp(japanRect.x, screenStatuses[testingInt].japan.rect.x, ((Time.time - StartTime) / 2f)))
                                , (Mathf.Lerp(japanRect.y, screenStatuses[testingInt].japan.rect.y, ((Time.time - StartTime) / 2f)))
                                , (Mathf.Lerp(japanRect.width, screenStatuses[testingInt].japan.rect.width, ((Time.time - StartTime) / 2f)))
                                , (Mathf.Lerp(japanRect.height, screenStatuses[testingInt].japan.rect.height, ((Time.time - StartTime) / 2f))));
    }

    void MoveViking() 
    {
        viking.rect = new Rect((Mathf.Lerp(vikingRect.x, screenStatuses[testingInt].viking.rect.x, ((Time.time - StartTime) / 2f)))
                            , (Mathf.Lerp(vikingRect.y, screenStatuses[testingInt].viking.rect.y, ((Time.time - StartTime) / 2f)))
                            , (Mathf.Lerp(vikingRect.width, screenStatuses[testingInt].viking.rect.width, ((Time.time - StartTime) / 2f)))
                            , (Mathf.Lerp(vikingRect.height, screenStatuses[testingInt].viking.rect.height, ((Time.time - StartTime) / 2f))));
    }

    IEnumerator MotionDuration() 
    {
        yield return new WaitForSeconds(2f);
        mDel -= MoveSpace;
        mDel -= MoveJungle;
        mDel -= MoveJapan;
        mDel -= MoveViking;
        currentStatus = GetCurrentStatus();
        testingInt++;
    }

    Cam_Status_Holder GetCurrentStatus() 
    {
        Cam_Status nSpace = new Cam_Status(space);
        Cam_Status nJungle = new Cam_Status(jungle);
        Cam_Status nJapan = new Cam_Status(japan);
        Cam_Status nViking = new Cam_Status(viking);
        Cam_Status_Holder nHolder = new Cam_Status_Holder(nSpace, nJungle, nJapan, nViking, ScreenLayout.DEFAULT);
        return nHolder;
    }

}
