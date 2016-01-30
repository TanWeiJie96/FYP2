using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {

    public string sceneName;
    public LevelSystem levelSys;

    public void Update()
    {
        // TEMPORARY
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(sceneName);

        }
         */
    }

    // Change Scene
    public void _changeScene()
    {
        Application.LoadLevel(sceneName);
    }

    public void _changeSceneWithName(string tempSceneName)
    {
        Application.LoadLevel(tempSceneName);
    }

    public void _changeScene(string scName , int level)
    {
        Debug.Log(level);
        levelSys.curLevel = levelSys.levelList[level];

        SoundManager.instance._adjustMusicVolume(4.0f,true);
 

        Application.LoadLevel(scName);
    }

    public void _changeOption()
    {
        Application.LoadLevel(3);
    }

}
