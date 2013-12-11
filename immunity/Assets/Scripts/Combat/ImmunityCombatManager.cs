using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ImmunityCombatManager : MonoBehaviour {
	
	public static ImmunityCombatManager instance;
	
	public string stage_name;
	
	private FStage stage_;
	
	private ImmunityPage gamePage;
	public ImmunityPage GamePage
	{
		get { return gamePage; }	
	}
	
	public int score;
	
	public FCamObject camera_;
	
	void Start () {
		instance = this;
		
		FutileParams fparams = new FutileParams(true, true, false, false);
		
		fparams.AddResolutionLevel(1280.0f, 1.0f, 1.0f, "");
		fparams.origin = new Vector2(0.5f, 0.5f);
		
		Futile.instance.Init(fparams);
		
		Futile.atlasManager.LoadAtlas("Atlases/HuroCombatAtlas");
		Futile.atlasManager.LoadAtlas("Atlases/EnemyCombatAtlas");
		
		if(stage_name.Equals("stomach"))
		{
			Futile.atlasManager.LoadAtlas("Atlases/StomachAtlas1");
			Futile.atlasManager.LoadAtlas("Atlases/StomachAtlas2");
		}
		else if(stage_name.Equals("lung"))
		{
			Futile.atlasManager.LoadAtlas("Atlases/LungBackground1");
			Futile.atlasManager.LoadAtlas("Atlases/LungBackground2");
			Futile.atlasManager.LoadAtlas("Atlases/LungBackground3");
			Futile.atlasManager.LoadAtlas("Atlases/LungBackground4");
			Futile.atlasManager.LoadAtlas("Atlases/LungBackground5");

			Futile.atlasManager.LoadAtlas("Atlases/lung_layers");
			Futile.atlasManager.LoadAtlas("Atlases/DustRear");
			Futile.atlasManager.LoadAtlas("Atlases/DustMid");
			Futile.atlasManager.LoadAtlas("Atlases/DustFore");

		}
		else
		{
			Futile.atlasManager.LoadAtlas("Atlases/BrainAtlas");
			Futile.atlasManager.LoadAtlas("Atlases/neuron_fast_80_animation");
			Futile.atlasManager.LoadAtlas("Atlases/neuron_fast_60_animation");
			Futile.atlasManager.LoadAtlas("Atlases/neuron_fast_40_animation");
			Futile.atlasManager.LoadAtlas("Atlases/neuron_slow_80_animation");
			Futile.atlasManager.LoadAtlas("Atlases/neuron_slow_60_animation");
			Futile.atlasManager.LoadAtlas("Atlases/neuron_slow_40_animation");
		}
		
		Futile.atlasManager.LoadAtlas("Atlases/MenuWords");
		Futile.atlasManager.LoadAtlas ("Atlases/VictoryDefeatAtlas");

		FSoundManager.PreloadSound("player_hit");
		FSoundManager.PreloadSound("bacteria_pop");
		FSoundManager.PreloadSound("enemy_hit");
		
		Futile.atlasManager.LogAllElementNames();
		
		stage_ = Futile.stage;
		
		camera_ = new FCamObject();
		stage_.AddChild(camera_);
		
		//Rect worldBounds = stage.worldBounds;
		//camera_.setWorldBounds (worldBounds);
		//camera_.setBounds(stage.cameraBounds);
		
		gamePage = new CombatPage();
		gamePage.Start();
		camera_.AddChild(gamePage);	
	}
	
	// Update is called once per frame
	void Update () {
	}
		
}
