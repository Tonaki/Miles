using UnityEngine;
using System.Collections;



public class Start : MonoBehaviour 
{

    void OnDestroy()
    {

		gameObject.GetComponent< FCamera.Fade >().LoadLevel( 1 );

    }

}