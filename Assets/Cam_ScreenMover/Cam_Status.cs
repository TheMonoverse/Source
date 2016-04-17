using UnityEngine;
using System.Collections;

public enum ScreenLayout 
{
    DEFAULT,                    //Should be 2X2 split screen.
    ONE,                        //One player on screen.
    TWO_VERTICAL,               //Two players aligned vertically.
    TWO_HORIZONTAL,             //Two players aligned Horizontally.
    TWO_MORTISE,                //Two players, one full screen one on mortise.
    THREE_EMPTY_CORNER,         //Three players evenly split with an empty corner.
    THREE_ONE_FULL_HEIGHT,      //Three players, one full height and 2 half height.
    THREE_ONE_FULL_WIDTH,       //Three players, one full width and 2 half width.
    FOUR_NORMAL,                //Four players, 2X2. Same as default.
    FOUR_ONE_FULL_HEIGHT,        //Four players, one full height and 2 half height.
    FOUR_ONE_FULL_WIDTH,        //Four players, one full width and 2 half width.
    FOUR_ONE_FULLSIZE_MORTISE,  //Four players, one full size and 3 in mortise.
    COUNT
}
[System.Serializable]
public class Cam_Status_Holder
{
    public ScreenLayout layout;
    public Cam_Status space;
    public Cam_Status jungle;
    public Cam_Status japan;
    public Cam_Status viking;

    public Cam_Status_Holder(Cam_Status sp, Cam_Status jung, Cam_Status jap, Cam_Status vik, ScreenLayout lay)
    {
        space = sp;
        jungle = jung;
        japan = jap;
        viking = vik;
        layout = lay;
    }
}

[System.Serializable]
public class Cam_Status
{
    public Rect rect;

    public float renderingOrder;

    public void Set(Camera camera)
    {
        rect = camera.rect;
        renderingOrder = camera.depth;
    }

    public Cam_Status()
    {

    }

    public Cam_Status(Rect camRect, float cameraDept)
    {
        rect = camRect;
        renderingOrder = cameraDept;
    }

    public Cam_Status(Camera camera)
    {
        rect = new Rect( camera.rect.x, camera.rect.y, camera.rect.width, camera.rect.height);
        renderingOrder = camera.depth;
    }
}