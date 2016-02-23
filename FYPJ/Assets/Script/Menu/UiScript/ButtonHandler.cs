using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class ButtonHandler : MonoBehaviour {
    public Button ownButton;
    //public ScaleUp scaleUp;
    public bool selected;

    public void _buttonScale(bool Up)
    {
       // Debug.Log(gameObject.name);
        ScaleUp.instance._scale(Up,gameObject);
    }

}
