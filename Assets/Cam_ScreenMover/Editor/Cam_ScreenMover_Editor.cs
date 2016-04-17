using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


[CustomEditor(typeof(Cam_ScreenMover))]
public class Cam_ScreenMover_Editor : Editor {


    private List<Cam_Status> cStatList = new List<Cam_Status>();

    private int newCam_Layout = 0;

    private string[] optionsLayout = new string[]
    {
            ScreenLayout.DEFAULT.ToString(), 
            ScreenLayout.ONE.ToString(),
            ScreenLayout.TWO_VERTICAL.ToString(), 
            ScreenLayout.TWO_HORIZONTAL.ToString(),
            ScreenLayout.TWO_MORTISE.ToString(),
            ScreenLayout.THREE_EMPTY_CORNER.ToString(),
            ScreenLayout.THREE_ONE_FULL_HEIGHT.ToString(),
            ScreenLayout.THREE_ONE_FULL_WIDTH.ToString(),
            ScreenLayout.FOUR_NORMAL.ToString(),
            ScreenLayout.FOUR_ONE_FULL_HEIGHT.ToString(),
            ScreenLayout.FOUR_ONE_FULL_WIDTH.ToString(),
            ScreenLayout.FOUR_ONE_FULLSIZE_MORTISE.ToString(),
    };

    
    private int selectedLayout = 0;
    //foldout variables
    private bool newLayoutMenu = true;
    private string newLayoutMenuString = "Hide Layout creation Menu.";
    private bool cameraAttachMenu = true;
    private string cameraAttachMenuString = "Hide Cameras";
    private bool layoutSelectorMenu = true;
    private string layoutSelectorString = "Hide Layouts.";


    private int layoutNumber = 0;

    public override void OnInspectorGUI()
    {
        Cam_ScreenMover cScreenM = (Cam_ScreenMover)target;

        if (!stylesInit)
        {
            InitStyles();
            stylesInit = true;
        }

        cameraAttachMenu = EditorGUILayout.Foldout(cameraAttachMenu, cameraAttachMenuString);
        if (cameraAttachMenu)
        {
            cameraAttachMenuString = "Hide Cameras";
            EditorGUILayout.BeginVertical(palletLightBox);
            EditorGUILayout.LabelField("Space Camera", EditorStyles.boldLabel);
            cScreenM.space = EditorGUILayout.ObjectField(cScreenM.space, typeof(Camera), true) as Camera;
            EditorGUILayout.LabelField("Jungle Camera", EditorStyles.boldLabel);
            cScreenM.jungle = EditorGUILayout.ObjectField(cScreenM.jungle, typeof(Camera), true) as Camera;
            EditorGUILayout.LabelField("Japan Camera", EditorStyles.boldLabel);
            cScreenM.japan = EditorGUILayout.ObjectField(cScreenM.japan, typeof(Camera), true) as Camera;
            EditorGUILayout.LabelField("Viking Camera", EditorStyles.boldLabel);
            cScreenM.viking = EditorGUILayout.ObjectField(cScreenM.viking, typeof(Camera), true) as Camera;
            GUILayout.Space(10);
            EditorGUILayout.EndVertical();
        }
        else 
        {
            cameraAttachMenuString = "Show Cameras";
        }
        

        if (cScreenM.space == null || cScreenM.jungle == null || cScreenM.japan == null || cScreenM.viking == null)
        {
            return;//Can only edit with all camera assigned.
        }
        //--
       
        //Section to edit current selected.

        newLayoutMenu = EditorGUILayout.Foldout(newLayoutMenu, newLayoutMenuString);
        if (newLayoutMenu)
        {
            newLayoutMenuString = "Hide Layout creation Menu.";
            EditorGUILayout.BeginVertical(palletDarkBox);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Select Type of Layout: ", EditorStyles.boldLabel, GUILayout.Width(300f));
            newCam_Layout = EditorGUILayout.Popup("", newCam_Layout, optionsLayout, GUILayout.Width(200f));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox("Based on cameras rect and dept.", MessageType.Info);
            if (GUILayout.Button("Create Layout", GUILayout.Width(200f), GUILayout.MaxHeight(40f)))
            {
                Cam_Status nSpace = new Cam_Status(cScreenM.space);
                Cam_Status nJungle = new Cam_Status(cScreenM.jungle);
                Cam_Status nJapan = new Cam_Status(cScreenM.japan);
                Cam_Status nViking = new Cam_Status(cScreenM.viking);
                Cam_Status_Holder nHolder = new Cam_Status_Holder(nSpace, nJungle, nJapan, nViking, (ScreenLayout)newCam_Layout);
                cScreenM.CreateNewLayout(nHolder);

                selectedLayout = cScreenM.screenStatuses.Count - 1;

            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            ///Current Layout
            EditorGUILayout.BeginVertical(palletLightestBox);
            cScreenM.space.rect = EditorGUILayout.RectField(cScreenM.space.name, cScreenM.space.rect);
            cScreenM.space.depth = EditorGUILayout.FloatField("Camera Dept: ", cScreenM.space.depth, GUILayout.MaxWidth(250f));
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(palletLightestBox);
            cScreenM.jungle.rect = EditorGUILayout.RectField(cScreenM.jungle.name, cScreenM.jungle.rect);
            cScreenM.jungle.depth = EditorGUILayout.FloatField("Camera Dept: ", cScreenM.jungle.depth, GUILayout.MaxWidth(250f));
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(palletLightestBox);
            cScreenM.japan.rect = EditorGUILayout.RectField(cScreenM.japan.name, cScreenM.japan.rect);
            cScreenM.japan.depth = EditorGUILayout.FloatField("Camera Dept: ", cScreenM.japan.depth, GUILayout.MaxWidth(250f));
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(palletLightestBox);
            cScreenM.viking.rect = EditorGUILayout.RectField(cScreenM.viking.name, cScreenM.viking.rect);
            cScreenM.viking.depth = EditorGUILayout.FloatField("Camera Dept: ", cScreenM.viking.depth, GUILayout.MinWidth(30f));
            EditorGUILayout.EndVertical();
            ///Current Layout
            ///

        }
        else 
        {
            newLayoutMenuString = "Show Layout creation Menu.";
        }


        layoutSelectorMenu = EditorGUILayout.Foldout(layoutSelectorMenu, layoutSelectorString);
        if (cScreenM.screenStatuses.Count == 0)
        {
            EditorGUILayout.LabelField("No layout defined. Click <Create Layout> button to start.", EditorStyles.boldLabel);
            return;
        }
        else if(layoutSelectorMenu)
        {
            layoutSelectorString = "Hide Layouts.";
            int[] layoutTypeCount = new int[(int)ScreenLayout.COUNT];
            string[] selectionGridStatuses = new string[cScreenM.screenStatuses.Count];

            for (int i = 0; i < cScreenM.screenStatuses.Count; i++)
            {
                layoutTypeCount[(int)cScreenM.screenStatuses[i].layout]++;
                selectionGridStatuses[i] = cScreenM.screenStatuses[i].layout.ToString() + "  # " + layoutTypeCount[(int)cScreenM.screenStatuses[i].layout];
            }

            selectedLayout = GUILayout.SelectionGrid(selectedLayout, selectionGridStatuses, 3);
            
            layoutNumber = 0;
            for (int j = 0; j <= selectedLayout; j++)
            {
                if (cScreenM.screenStatuses[selectedLayout].layout == cScreenM.screenStatuses[j].layout)
                {
                    layoutNumber++;
                }
            }
        }
        else if (!layoutSelectorMenu)
        {
            layoutSelectorString = "Show Layouts.";
        }
        //Displays the selected layout.
        EditorGUILayout.LabelField("Total Layouts: " + cScreenM.screenStatuses.Count, EditorStyles.boldLabel);
        GUILayout.Space(20);



        EditorGUILayout.BeginVertical(palletLightBox);
        EditorGUILayout.RectField(cScreenM.space.name, cScreenM.screenStatuses[selectedLayout].space.rect);
        EditorGUILayout.FloatField("Camera Dept: ", cScreenM.space.depth, GUILayout.MaxWidth(250f));
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical(palletLightBox);
        EditorGUILayout.RectField(cScreenM.jungle.name, cScreenM.screenStatuses[selectedLayout].jungle.rect);
        EditorGUILayout.FloatField("Camera Dept: ", cScreenM.jungle.depth, GUILayout.MaxWidth(250f));
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical(palletLightBox);
        EditorGUILayout.RectField(cScreenM.japan.name, cScreenM.screenStatuses[selectedLayout].japan.rect);
        EditorGUILayout.FloatField("Camera Dept: ", cScreenM.japan.depth, GUILayout.MaxWidth(250f));
        EditorGUILayout.EndVertical();



        EditorGUILayout.BeginVertical(palletLightBox);
        EditorGUILayout.RectField(cScreenM.viking.name, cScreenM.screenStatuses[selectedLayout].viking.rect);
        EditorGUILayout.FloatField("Camera Dept: ", cScreenM.viking.depth, GUILayout.MaxWidth(250f));
        EditorGUILayout.EndVertical();
        //---------------------------

    }



    private GUIStyle palletDarkestBox = null;
    private GUIStyle palletDarkBox = null;
    private GUIStyle palletMidBox = null;
    private GUIStyle palletLightBox = null;
    private GUIStyle palletLightestBox = null;
    private bool stylesInit = false;

    private void InitStyles()
    {

        palletDarkestBox = new GUIStyle(GUI.skin.box);
        palletDarkestBox.normal.background = MakeTex(2, 2, new Color(0.024f, 0.082f, 0.224f, 1f));
        
        palletDarkBox = new GUIStyle(GUI.skin.box);
        palletDarkBox.normal.background = MakeTex(2, 2, new Color(0.086f, 0.161f, 0.333f, 1f));

        palletMidBox = new GUIStyle(GUI.skin.box);
        palletMidBox.normal.background = MakeTex(2, 2, new Color(0.18f, 0.255f, 0.447f, 1f));

        palletLightBox = new GUIStyle(GUI.skin.box);
        palletLightBox.normal.background = MakeTex(2, 2, new Color(0.31f, 0.384f, 0.557f, 1f));

        palletLightestBox = new GUIStyle(GUI.skin.box);
        palletLightestBox.normal.background = MakeTex(2, 2, new Color(0.471f, 0.529f, 0.671f, 1f));

    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

}
