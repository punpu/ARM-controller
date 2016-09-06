using UnityEngine;
using System.Collections;

public class TargetPoseScript : MonoBehaviour {
    public Texture2D[] poseTextureArray;
    private Texture2D poseTexture;

    void OnGUI()
    {
        if(poseTextureArray.Length == 0)
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }

        GUI.DrawTexture(new Rect(Screen.width - 200, 0, 200, 200), poseTexture);
    }

    void DisplayPose(int poseNumber)
    {

        poseTexture = poseTextureArray[poseNumber];
    }
}
