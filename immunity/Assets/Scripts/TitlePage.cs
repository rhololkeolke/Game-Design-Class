using UnityEngine;
using System.Collections;
using System;

public class TitlePage : ImmunityPage, FMultiTouchableInterface
{
	private ImmunityMenu immunityMenu;

	private FSprite background_;
	private FButton play_button;
	private FButton how_to_play_button;
	private FButton credits_button;

	public TitlePage()
	{
		EnableMultiTouch();
		ListenForUpdate(HandleUpdate);
	}
	
	override public void Start()
	{
		// Access immunity menu
		immunityMenu = GameObject.Find ("Futile").GetComponent<ImmunityMenu>();

		// Sound
		FSoundManager.StopMusic();
		FSoundManager.UnloadAllSoundsAndMusic();
		FSoundManager.PlayMusic("background_music");
		FSoundManager.PreloadSound("button_click");
	
		// GUI objects
		background_ = new FSprite("start screen final");
		play_button = new FButton("Play","PlayPressed");
		how_to_play_button = new FButton("how_to_play", "how_to_play_pressed");
		credits_button = new FButton("Credits", "CreditsPressed");

		// Add objects to stage
		AddChild(background_);
		AddChild(play_button);
		AddChild(how_to_play_button);
		AddChild(credits_button);

		// Scale and set position
		background_.scale = 0.0f;

		play_button.scale = .6f;
		play_button.x = Futile.screen.halfWidth*.3f;
		play_button.y = Futile.screen.halfHeight*.1f;
		
		how_to_play_button.x = Futile.screen.halfWidth*.45f;
		how_to_play_button.y = Futile.screen.halfHeight*-.3f;
		
		credits_button.scale = .6f;
		credits_button.x = Futile.screen.halfWidth*.35f;
		credits_button.y = Futile.screen.halfHeight*-.7f;

		// Set button delegates
		play_button.SignalRelease += HandlePlayButton;
		how_to_play_button.SignalRelease += HandleHowToPlayButton;
		credits_button.SignalRelease += HandleCreditsButton;

		Go.to(background_, 0.5f, new TweenConfig().setDelay(0.1f).floatProp("scale", 1.0f).setEaseType(EaseType.BackOut));
	}
	
	private void HandlePlayButton(FButton button){
		Debug.Log("Play Button Clicked");
		immunityMenu.GoToMenu(PageType.LevelSelectPage);
	}
	
	private void HandleHowToPlayButton(FButton button){
		immunityMenu.GoToMenu(PageType.HowToPlayPage);	
	}
	
	private void HandleCreditsButton(FButton button)
	{
		Debug.Log("Credits Button Clicked");
		immunityMenu.GoToMenu(PageType.CreditsPage);
	}

	public void HandleMultiTouch(FTouch[] touches){
		foreach(FTouch touch in touches){	
			if(touch.phase == TouchPhase.Ended){
			}			
		}
	}

	protected void HandleUpdate(){
	}
}