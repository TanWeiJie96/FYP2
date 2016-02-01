using UnityEngine;
using System.Collections;

public class CHECKINGFORMAGNETWITHINRANGE : MonoBehaviour {

    public PlayerMagnetAction PMA;

	public bool instructionBefore = false;  

    void OnTriggerStay(Collider other)
    {
     
        if (other.tag == "Magnet_S")
        {
            Debug.Log("Magnet_S Detected!");
            PMA.magnetTrans = other.transform;
            PMA.magnetInZone = true;
        }
        //Debug.Log("Enter Collider!");

        if (other.tag == "Magnet_N")
        {
            Debug.Log("Magnet_N Detected!");
            PMA.magnetTrans = other.transform;
            PMA.magnetInZone = true;
            PMA.north = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Magnet_S" || other.tag == "Magnet_N") && PMA.looseMagnet == true)
        {
            
            //Debug.Log("Magnet Exit!");
            PMA.magnetInZone = false;
            PMA.north = false;
        }
    }

	void OnTriggerEnter(Collider other)
	{
		if (!instructionBefore)
		{

		}
	}
}
