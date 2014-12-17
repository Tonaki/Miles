using UnityEngine;
using System.Collections;



public class Start : MonoBehaviour 
{

    void OnDestroy()
    {

        Application.LoadLevel( 1 );

    }

}