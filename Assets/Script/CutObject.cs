using UnityEngine;
using System.Collections;



public class CutObject : MonoBehaviour 
{

	public int hp = 0;

	public bool breakPoint = false;

	private float interval = 0.0f;

	private GameObject parent = null;



	// Use this for initialization
	void Start () 
	{

		parent = gameObject.transform.parent.gameObject;

	}


	void OnTriggerEnter( Collider col )
	{

		if( interval > Time.timeSinceLevelLoad ){

			return;

		}

		if( col.tag == "Wepon" ){

			hp -= 1;

			if( breakPoint == false ){

				parent.GetComponent< Enemy >().SendMessage( "Damage", 1 );

			}

			if( hp <= 0 && gameObject.tag != "CutObject" ){

				gameObject.tag = "CutObject";

			}

			interval = Time.timeSinceLevelLoad + 0.5f;

		}

	}

}