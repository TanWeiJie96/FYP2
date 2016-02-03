using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class InGameInstruction : MonoBehaviour {
	
	public List <Text> listOfInstruction;

	void Start()
	{	
		foreach (Text tempText in listOfInstruction)
		{
			tempText.enabled = false;
		}
	}
}
