using UnityEngine;
using System.Collections;

public class BattleEnd : MonoBehaviour 
{

    private GameController controller;

    public float deleteTime = 0;

	public bool childCount = true;

	private float TimeCnt = 0;


	// Use this for initialization
	void Start () 
    {

        controller = GameObject.FindWithTag( "GameController" ).GetComponent< GameController >();
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if( childCount == true ){

			if( gameObject.transform.childCount != 0 ){

				return;

			}

		}

		TimeCnt += Time.deltaTime;
		
		if( TimeCnt >= deleteTime ){

            controller.PlayBGM( 1 );
		
			Destroy( gameObject );
		
		}
	
	}

}
