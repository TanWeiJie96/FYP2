using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class CharacterSelectMenu : MonoBehaviour {
    public List<Button> CharButList;


	// Use this for initialization
	void Start () {
        //Debug.Log(CharButList.Count + "/" + GameInfo.instance.list_VehProfile.Count);

        for (int i = 0; i < CharButList.Count; i++)
        {
            int x = i;
            CharButList[i].onClick.AddListener(delegate { GameInfo.instance._setVehicleType(x); });
        }
	}

}
