using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class LevelUI : MonoBehaviour {
    public MenuManager menuManager;
    public SceneManager sceneManager;
    public LevelSystem levelSystem;

    public GameObject levelIcon;
 
    //public int numberOfLevel;
    
    public int onLevel = 1;
    public float spacing = 100;

    public bool semiLevel = true;

    void Awake()
    {
        if (sceneManager == null)
        {
            sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        }
        if (levelSystem == null)
        {
            levelSystem = GameObject.Find("LevelInit").GetComponent<LevelSystem>();
        }

    }

	// Use this for initialization
	void Start () {
        int k = 0;
        for (int i = 0; i < levelSystem.levelList.Count; ++i)
        {
            //set object to position
            GameObject newIcon = GameObject.Instantiate(levelIcon) as GameObject;
           
            if (i % 3 == 0 && i !=0)
            {
                ++k;
            }

            newIcon.transform.position = new Vector3(gameObject.transform.position.x - spacing + ((i - (k * 3)) * spacing), gameObject.transform.position.y + 50 - (k * spacing * 0.5f), gameObject.transform.position.z);
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
                int newint = i;
                Debug.Log(newint);
                newButton.onClick.AddListener(delegate { sceneManager._changeScene("Level" + onLevel, newint); });
                foreach (Transform child in newIcon.transform)
                {
                    if(child.gameObject.name == "Rating")
                    {
                        child.GetComponent<Text>().text = levelSystem.levelList[i].levelHighRating.ToString() + "/10";
                    }
                }
            }

        }
	}
	
}
