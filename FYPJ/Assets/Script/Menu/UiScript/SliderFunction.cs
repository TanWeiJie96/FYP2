using UnityEngine;
using System.Collections;

public class SliderFunction : MonoBehaviour {

	public RectTransform rectTransform;
	protected Vector3 visibleTransform;
	protected Vector3 hiddenTransform;
	
	public Vector3 distanceOut;
    public float speed = 6;

	bool shouldBeVisible = false;
	public bool shouldBeMoving = true; 
	public bool moving;

	public SliderFunction nextToSlide;

	// Use this for initialization
	void Start () {
		visibleTransform = rectTransform.anchoredPosition3D + distanceOut;//= new Vector3(-966, 0, 0);
		hiddenTransform = rectTransform.anchoredPosition3D;//new Vector3(-616, 0, 0);
	}

	public bool _checkSlider(bool axis)
	{
        if (!shouldBeVisible  /*&& moving == false*/ )
			return true;
		else
			return false;
	}


	private WaitForEndOfFrame waitUpdate = new WaitForEndOfFrame();
	IEnumerator _Slide(bool axis)
	{
		//yield if(moving == false);
		//;
		//GlobalVar.INTA.inputAllowed = false;
		if (shouldBeVisible) {
			if (nextToSlide != null) {
				nextToSlide.SlideUI (true, axis);
			}
		} else {
			if(nextToSlide != null)
			{
				nextToSlide.SlideUI(false, axis);
			}
		}

		while (moving == true) {
			if (shouldBeVisible) {
		
				rectTransform.anchoredPosition3D = Vector3.Lerp (rectTransform.anchoredPosition, visibleTransform , speed * Time.deltaTime);
				yield return waitUpdate;

				if(nextToSlide != null)
				{
					nextToSlide.SlideUI(true,axis);
				}


				if (_IsTotallyVisible (axis)) {
					moving = false;		
				}
			} else {
				//when moving in
				rectTransform.anchoredPosition3D = Vector3.Lerp (rectTransform.anchoredPosition, hiddenTransform , speed * Time.deltaTime);

				yield return waitUpdate;//moving == false
				if (_IsTotallyHidden (axis)) {
					moving = false;
				}

			}
			
		}
		//GlobalVar.INTA.inputAllowed = true;
		yield return null;//moving == false
	}

	public void SlideUI(bool inwards , bool axis)
	{
		if (inwards) 
			shouldBeVisible = true;
		else
			shouldBeVisible = false;

		moving = true;
		StartCoroutine (_Slide(axis));
		//_Slide ();
		
	}
	
	public bool _IsTotallyVisible(bool axis)
	{
		if (axis) {
			return (rectTransform.anchoredPosition3D.x <= visibleTransform.x + 10);
			//Debug.Log (rectTransform.anchoredPosition3D.x + " , " + visibleTransform.x );
		} else {
			return (rectTransform.anchoredPosition3D.x >= visibleTransform.x - 10);
			//Debug.Log (rectTransform.anchoredPosition3D.y + " , " + visibleTransform.y );
		}
	}
	
	public bool _IsTotallyHidden(bool axis)
	{
		if (axis) {
			return (rectTransform.anchoredPosition3D.x >= hiddenTransform.x - 10);
			//Debug.Log (rectTransform.anchoredPosition3D.x + " , " + visibleTransform.x);
		}
		else
		{
			return (rectTransform.anchoredPosition3D.x <= hiddenTransform.x + 10);
			//Debug.Log (rectTransform.anchoredPosition3D.x + " , " + visibleTransform.x );
		}
	}
}
