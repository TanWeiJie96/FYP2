using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;


public class UIHandler : MonoBehaviour {
    public Text mainText;
    public Color initColor;

    public List<GameObject> ToControlList; 

	// Use this for initialization
	void Start () {
       initColor = mainText.color;
        
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void _changeText(string tempText)
    {
        mainText.text = tempText;
    }

    public void _changeText(string tempText, Color colorchange)
    {
        mainText.color = colorchange;
        _changeText(tempText);
    }

	
}
