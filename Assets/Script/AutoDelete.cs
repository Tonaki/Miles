using UnityEngine;
using System.Collections;



public class AutoDelete : MonoBehaviour 
{

	public float deleteTime = 0;

	public bool childCount = true;

	private float TimeCnt = 0;


	
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
		
			Destroy( gameObject );
		
		}
	
	}

}
