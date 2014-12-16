using UnityEngine;
using System.Collections;



public class Goblin : MonoBehaviour 
{

    private Animation animation = null;

    private bool attackMode = false;

    private const float delay = 60.0f;

    private float attackDelay = delay;



	// Use this for initialization
	void Start() 
    {

        animation = gameObject.GetComponent< Animation >();

        animation.Play( "idle" );

        animation[ "attack1" ].wrapMode = WrapMode.Once;

	}


    void Update()
    {

        if( attackMode == true ){

            if( animation.IsPlaying( "idle" ) ){

                animation.CrossFade( "combat_idle" );

            }

            if( attackDelay <= Random.Range( 0, delay - 2.0f ) ){

                animation.CrossFade( "attack1" );

                animation.CrossFadeQueued( "combat_idle" );

                attackDelay = delay;

            }

            attackDelay -= Time.deltaTime;

        }else{

            if( animation.IsPlaying( "combat_idle" ) ){
            
                animation.CrossFade( "idle" );
            
            }

        }

    }


    void OnTriggerEnter( Collider col )
    {

        if( col.tag == "Player" ){

            attackMode = true;

        }

    }
	

    void OnTriggerExit( Collider col )
    {

        if( col.tag == "Player" ){

            attackMode = false;

            attackDelay = delay;

        }

    }

}