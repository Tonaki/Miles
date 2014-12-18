using UnityEngine;
using System.Collections;



public class Clear : MonoBehaviour 
{

	void OnDestroy()
    {

		gameObject.GetComponent< FCamera.Fade >().LoadLevel( 0 );

    }

}