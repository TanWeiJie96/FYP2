using UnityEngine;
using System.Collections;

public class ScaleUp : MonoBehaviour {
    Vector3 initialScale = new Vector3(1.0f,1.0f,1.0f) ;
    public Vector3 scaleUpTo = new Vector3(1.3f,1.3f,1.3f);

    public float speed = 1.0F;
    
    float startTime;
    float journeyLength;

    public GameObject curGO;

    public static ScaleUp instance;

    void Awake()
    {
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        journeyLength = Vector3.Distance(initialScale, scaleUpTo);
    }

    public void _scale(bool Up , GameObject tempGO)
    {
        //Debug.Log("wtf");
        curGO = tempGO;
        startTime = Time.time;
        if (Up)
        {
            StartCoroutine(_scalingUp());
          // Debug.Log("up");
        }
        else
        {
            StartCoroutine(_scalingDown());
            //Debug.Log("down");
        }
    }

    IEnumerator _scalingUp()
    {
        GameObject curGOToScale = curGO;
        while (Vector3.Distance(curGOToScale.transform.localScale, scaleUpTo) > 0.01)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            curGOToScale.transform.localScale = Vector3.Lerp(initialScale, scaleUpTo, fracJourney);
           // yield return null;
            yield return null;
        }
        yield return null;
    }

    IEnumerator _scalingDown()
    {
        GameObject curGOToScale = curGO;
        while (Vector3.Distance(curGOToScale.transform.localScale, initialScale) > 0.01)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            curGOToScale.transform.localScale = Vector3.Lerp(scaleUpTo, initialScale, fracJourney);
            // yield return null;
            yield return null;
        }
        yield return null;
    }

}
