using UnityEngine;
using System.Collections;

public class HPGauge : MonoBehaviour 
{

	private GameController controller;

    private Animator animator;


	// Use this for initialization
	void Start () 
	{

		controller = GameObject.FindWithTag( "GameController" ).GetComponent< GameController >();

        controller.AddHpGauge( gameObject.GetComponent< HPGauge >() );

        animator = gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent< Animator >();
	    
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

    public void HpGaugeUpdate( float hpScall )
    {

        gameObject.transform.localScale = new Vector3( hpScall, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

    }

    public void HitAnimation()
    {

        animator.SetTrigger("Damage");

    }

}