using UnityEngine;
using System.Collections;



public class AudioController : SingletonMonoBehaviour< AudioController > 
{

    private GameController controller;

    private AudioSource audio;

    [SerializeField]
    private AudioClip[] clip;

	// Use this for initialization
	void Start () 
    {

        DontDestroyOnLoad( this.gameObject );

        controller = GameObject.FindWithTag( "GameController" ).GetComponent< GameController >();

        controller.AddAudio( gameObject.GetComponent< AudioController >() );

        audio = gameObject.GetComponent< AudioSource >();

        PlayBGM( 0 );

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void PlayBGM( int num )
    {

        audio.clip = clip[ num ];

        audio.Play();

    }

    public void PlayBGM( int num, ulong time )
    {

        audio.clip = clip[ num ];

        audio.Play( time );

    }

}