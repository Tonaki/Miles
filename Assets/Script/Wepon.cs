using UnityEngine;
using System.Collections;



public class Wepon : MonoBehaviour 
{

    [ SerializeField ]
    public int attack = 0;

    private AudioSource audio;


    void Start()
	{

		audio = gameObject.GetComponent< AudioSource >();

	}

    void OnTriggerExit( Collider col )
	{

        audio.PlayOneShot( audio.clip );

    }

}