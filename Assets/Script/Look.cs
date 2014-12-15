using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour 
{

	public GameObject target = null;

	private float time = 0;

	// Use this for initialization
	void Start () 
	{


	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if( time >= 2 ){

			if( target != null ){

				iTween.LookTo( gameObject, target.transform.position, 1 );

			}

			time = 0;

		}

		time += Time.deltaTime;
	
	}

}