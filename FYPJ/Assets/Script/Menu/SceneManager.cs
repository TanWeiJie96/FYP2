using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public string sceneName;

    public void Update()
    {
        // TEMPORARY
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(sceneName);

        }
    }

    // Change Scene
    public void _changeScene()
    {
        Application.LoadLevel(sceneName);
    }

    public void _changeOption()
    {
        Application.LoadLevel(3);
    }

}
