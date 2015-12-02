//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;

//public class Fading : MonoBehaviour {

//    // Singleton Structure
//    protected static Fading mInstance;
//    public static Fading Instance
//    {
//        get
//        {
//            if (mInstance == null)
//            {
//                GameObject tempObj = new GameObject();
//                mInstance = tempObj.AddComponent<Fading>();
//                Destroy(tempObj);
//            }
//            return mInstance;
//        }        
//    }

//    // Scene to be loaded
//    string SceneName = null;

//    // Whether to do Fade or not
//    bool b_DoFade = false;

//    // Fade Canvas
//    public Canvas FadePrefab;
//    Canvas FadeSprite;

//    // Fade Variables
//    float f_Alpha = 1.0f;
//    float f_Speed = 1.0f;

//    // Fade Type
//    public enum E_FadeType
//    {
//        FADE_IN,
//        FADE_OUT
//    } E_FadeType Type;

//    // Instantiate
//    void InstantiateFade()
//    {
//        if (FadePrefab != null)
//        {
//            FadeSprite = Instantiate(FadePrefab, FadePrefab.transform.position, Quaternion.identity) as Canvas;
//        }
//    }

//    // Initialisation 
//    void Start()
//    {
//        // Set Instance
//        mInstance = this;

//        // Starting to Fade 
//        StartFade(null, true);
//    }

//    // Fading Process
//    void DoFade(bool mode)
//    {
//        // Fade In
//        if (mode)
//        {
//            if (FadeSprite.GetComponent<Image>().color.a > 0.0f)
//            {
//                f_Alpha -= Time.deltaTime * f_Speed;
//            }
//            else
//            {
//                b_DoFade = false;
//            }
//        }
//        else
//        {
//            if (FadeSprite.GetComponent<Image>().color.a < 1.0f)
//            {
//                f_Alpha += Time.deltaTime * f_Speed;
//            }
//            else
//            {
//                b_DoFade = false;
//                Application.LoadLevel(SceneName);
//            }
//        }
//    }

//    // Start Fading[call this func if you want to do fading]
//    public void StartFade(string SceneName, bool mode = false)
//    {
//        // Do not constantly need to reset
//        if (b_DoFade)
//            return;

//        // Set Scene to be loaded 
//        this.SceneName = SceneName;

//        // Trigger Fading 
//        b_DoFade = true;

//        // Instantiate Canvas if not there
//        if (FadeSprite == null)
//        {
//            InstantiateFade();
//        }

//        // Set Default Color
//        Color DefaultColor = FadeSprite.GetComponentInChildren<Image>().color;

//        // Fade IN
//        if (mode)
//        {
//            this.Type = E_FadeType.FADE_IN;
//            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, 1.0f);
//        }
//        else
//        // Fade Out
//        {
//            this.Type = E_FadeType.FADE_OUT;
//            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, 0.0f);
//        }
//    }

//    // Update
//    void Update()
//    {
//        // Do Fading Now
//        if (b_DoFade)
//        {
//            // Fade Type
//            switch (Type)
//            {
//                case E_FadeType.FADE_IN:
//                    DoFade(true);
//                    break;
//                case E_FadeType.FADE_OUT:
//                    DoFade(false);
//                    break;
//            }

//            // Set Default Color
//            Color DefaultColor = FadeSprite.GetComponentInChildren<Image>().color;

//            // Toggle Alpha
//            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, f_Alpha);
//        }
//    }
//}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    // -- Singleton Structure
    protected static Fading mInstance;
    public static Fading Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject tempObj = new GameObject();
                mInstance = tempObj.AddComponent<Fading>();
                Destroy(tempObj);
            }
            return mInstance;
        }
    }

    // -- Scene to be loaded
    string SceneName = null;

    // -- Whether to do Fade
    bool b_DoFade = false;

    // -- Fade Canvas
    public Canvas FadePrefab;
    Canvas FadeSprite;

    // -- Variables
    float f_Alpha = 1.0f, f_Speed = 1.0f;

    // -- Fade's Type
    public enum E_FadeType
    {
        FADE_IN,
        FADE_OUT
    }
    E_FadeType Type;

    // -- Instantiate
    void InstantiateFade()
    {
        if (FadePrefab != null)
            FadeSprite = Instantiate(FadePrefab, FadePrefab.transform.position, Quaternion.identity) as Canvas;
    }

    // -- Initialisation
    void Start()
    {
        // -- Set Instance
        mInstance = this;

        // -- Start Fading In
        StartFade(null, true);
    }

    // -- Fading Process
    void DoFade(bool Mode)
    {
        // -- Fade-In
        if (Mode)
        {
            if (FadeSprite.GetComponentInChildren<Image>().color.a > 0.0f)
                f_Alpha -= Time.deltaTime * f_Speed;
            else
                b_DoFade = false;
        }

        // -- Fade-Out
        else
        {
            if (FadeSprite.GetComponentInChildren<Image>().color.a < 1.0f)
                f_Alpha += Time.deltaTime * f_Speed;
            else
            {
                b_DoFade = false;
                Application.LoadLevel(SceneName);
            }
        }
    }

    // -- Start Fading [THIS IS THE FUNCTION U CALL TO TOGGLE FADING]
    public void StartFade(string SceneName, bool Mode = false)
    {
        // -- Do not constantly reset fade
        if (b_DoFade) return;

        // -- Set Scene to be loaded
        this.SceneName = SceneName;

        // -- Tells Program to do fading
        b_DoFade = true;

        // -- Instantiate if Canvas doesn't exist
        if (FadeSprite == null)
            InstantiateFade();

        // -- Set Default Color
        Color DefaultColor = FadeSprite.GetComponentInChildren<Image>().color;

        // -- Fade-In
        if (Mode)
        {
            this.Type = E_FadeType.FADE_IN;
            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, 1.0f);
        }

        // -- Fade Out
        else
        {
            this.Type = E_FadeType.FADE_OUT;
            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, 0.0f);
        }
    }

    // -- Update Func
    void Update()
    {
        // -- Do Fading Now
        if (b_DoFade)
        {
            // -- Fade's Type
            switch (Type)
            {
                case E_FadeType.FADE_IN:
                    DoFade(true);
                    break;
                case E_FadeType.FADE_OUT:
                    DoFade(false);
                    break;
            }

            // -- Set Default Color
            Color DefaultColor = FadeSprite.GetComponentInChildren<Image>().color;

            // -- Toggle Alpha
            FadeSprite.GetComponentInChildren<Image>().color = new Color(DefaultColor.r, DefaultColor.g, DefaultColor.b, f_Alpha);
        }
    }
}
