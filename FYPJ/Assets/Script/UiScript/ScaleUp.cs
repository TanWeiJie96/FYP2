using UnityEngine;
using System.Collections;

public class ScaleUp : MonoBehaviour {
    Vector3 initialScale = new Vector3(1.0f,1.0f,1.0f) ;
    public Vector3 scaleUpTo = new Vector3(1.3f,1.3f,1.3f);

    public float speed = 1.0F;
    
    float startTime;
    float journeyLength;

    void Start()
    {
        initialScale = gameObject.transform.localScale;
        journeyLength = Vector3.Distance(initialScale, scaleUpTo);
    }

    public void _scale(bool Up)
    {
       
        startTime = Time.time;
        if (Up)
        {
            StartCoroutine(_scalingUp());
            Debug.Log("up");
        }
        else
        {
            StartCoroutine(_scalingDown());
            Debug.Log("down");
        }
    }

    IEnumerator _scalingUp()
    {
        while (Vector3.Distance(gameObject.transform.localScale,scaleUpTo) > 0.01)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            gameObject.transform.localScale = Vector3.Lerp(initialScale, scaleUpTo, fracJourney);
           // yield return null;
            yield return null;
        }
        yield return null;
    }

    IEnumerator _scalingDown()
    {
        while (Vector3.Distance(gameObject.transform.localScale, initialScale) > 0.01)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            gameObject.transform.localScale = Vector3.Lerp(scaleUpTo, initialScale, fracJourney);
            // yield return null;
            yield return null;
        }
        yield return null;
    }

}
