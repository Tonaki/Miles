﻿using UnityEngine;
using System.Collections;



public class GameController : SingletonMonoBehaviour< GameController >
{

    [SerializeField]
	private int maxHp = 100;

    private int hp;

    private AudioController audio;
    
    private HPGauge hpGauge;


	// Use this for initialization
	void Start () 
	{

		DontDestroyOnLoad( this.gameObject );

        HpInit();
		
	}
	
	// Update is called once per frame
    void Update () 
    {

        if ( Input.GetKeyDown( KeyCode.Escape ) ){

            Application.Quit();

        }
        
    }

    void HpInit()
    {

        hp = maxHp;

    }

    void GameOver()
    {

        gameObject.GetComponent<FCamera.Fade>().LoadLevel(0);

        HpInit();

    }

    public void AddAudio( AudioController audioController )
    {

        audio = audioController;

    }

    public void AddHpGauge( HPGauge gauge )
    {

        hpGauge = gauge;

    }

    public void Damage( int damage )
    {

        hp -= damage;

        hpGauge.HpGaugeUpdate( ( float )hp / maxHp );

        hpGauge.HitAnimation();

        if( hp <= 0 ){

            GameOver();

        }

    }

    public void PlayBGM( int num )
    {

        audio.PlayBGM( num );

    }

    public void PlayBGM( int num, ulong time )
    {

        audio.PlayBGM( num, time );

    }

}