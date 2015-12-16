using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class LevelUI : MonoBehaviour {
    public MenuManager menuManager;
    public SceneManager sceneManager;
    
    public GameObject levelIcon;
    public int numberOfLevel;
    
    public int onLevel = 1;
    public float spacing = 100;

    public bool semiLevel = true;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < numberOfLevel; ++i)
        {
            //set object to position
            GameObject newIcon = GameObject.Instantiate(levelIcon) as GameObject;

            newIcon.transform.position = new Vector3(gameObject.transform.position.x - 100 + (i * spacing), gameObject.transform.position.y, gameObject.transform.position.z);
            newIcon.transform.SetParent(gameObject.transform);
            

            //input string into button
            string newstr;
            if(semiLevel)
                newstr = onLevel + "-" + (i + 1);
            else
                newstr = (i + 1).ToString();

            newIcon.GetComponentInChildren<Text>().text = newstr;

            //input instruction for on click
            Button newButton = newIcon.GetComponent<Button>();

            if (!semiLevel)
            {
                newButton.onClick.AddListener(menuManager._tranverseMenu);
            }
            else
            {
                //sceneManager.sceneName = "Level" + onLevel;

                newButton.onClick.AddListener(delegate { sceneManager._changeScene("Level" + onLevel); });
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
