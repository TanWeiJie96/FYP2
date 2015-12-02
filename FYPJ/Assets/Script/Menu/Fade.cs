using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{

    public Texture2D fadeOutTexture; // texture for fading
    public float fadeSpeed = 0.8f;
    private int drawDepth = -1000; // texture orders in the hiearchy;

    private float alpha = 1.0f;
    private int fadeDir = -1;

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //force (clamp) the number between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    //Set FadeDir Fade in if -1 Fade out if 1
    public float _beginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded()
    {
        _beginFade(-1);
    }

}