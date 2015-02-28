using UnityEngine;
using System.Collections;



public class GameStart : MonoBehaviour 
{

    private GameController controller;


    void Start () 
    {

        controller = GameObject.FindWithTag( "GameController" ).GetComponent< GameController >();

    }
    
    void OnDestroy()
    {

        controller.PlayBGM( 1, 1 );

		gameObject.GetComponent< FCamera.Fade >().LoadLevel( 1 );

    }

}