﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour {
	
	public Texture health_bar_image;

	private ScreenRatio screen_ratio;
	
	public float left = 120;
	public float top = 470;
	public float width = 400;
	public float height = 400;
	
	public float frequency = 1; // times per second
	
	public List<Vector2> waypoints;
		
	public Light health_light;
	
	private float x_velocity;
	private int segment = 0;
	private float seg_slope = 0;
	
	bool paused = false;
		
	void Start () {
		screen_ratio = (ScreenRatio)GameObject.Find ("Main Camera").GetComponent("ScreenRatio");
		
		// don't bother doing anything if there aren't at least 2 waypoints
		if(waypoints.Count < 2)
			return;
		
		// find the overall change in x that will take place
		float x_length = 0;
		for(int i=1; i<waypoints.Count; i++) // this is assuming that the absolute values of the points have monotonically increasing values
		{
			x_length += Mathf.Abs(waypoints[i].x - waypoints[i-1].x);	
		}
		
		x_velocity = frequency*-x_length; // this is how much to move by each delta Time
	}
	
	void TimerPaused()
	{
		paused = true;	
	}
	
	void TimerUnpaused()
	{
		paused = false;	
	}
	
	void Update() {
		if(paused)
			return;
		
		if(waypoints.Count < 2)
			return; // if no waypoints then nothing to do
		
		// move by Vx in x-direction
		health_light.transform.Translate(new Vector3(x_velocity*Time.deltaTime, 0, 0));
		
		if(Mathf.Abs(health_light.transform.localPosition.x) > Mathf.Abs (waypoints[segment+1].x))
		{
			segment++;
			
			// if we've gone past the last waypoint
			// reset to the first waypoint
			if(segment >= waypoints.Count-1)
			{
				segment = 0;
				health_light.transform.localPosition = new Vector3(waypoints[segment].x, waypoints[segment].y, health_light.transform.position.z);
			}
			
			// incase we've moved so fast we've skipped waypoints
			while(Mathf.Abs (health_light.transform.localPosition.x) > Mathf.Abs(waypoints[segment+1].x))
			{
				segment++; // increment the segment counter
				if(segment >= waypoints.Count-1)
				{
					segment = 0;
					break;
				}
			}
			
			//Debug.Log ("segment " + segment);
			
			health_light.transform.localPosition = new Vector3(waypoints[segment].x, waypoints[segment].y, health_light.transform.position.z);
			
			// recompute slope
			seg_slope = (waypoints[segment+1].y - waypoints[segment].y)/(waypoints[segment+1].x - waypoints[segment].x);
			
			return; // this means there will be extra time spent at each waypoint, but I'm hoping it will be small enough not to notice
		}
		
		// move by the appropriate y
		health_light.transform.Translate(new Vector3(0, seg_slope*-x_velocity*Time.deltaTime, 0));
	}
	
	void OnGUI() {
		GUI.DrawTexture(new Rect(left*screen_ratio.horiz, top*screen_ratio.vert, width*screen_ratio.horiz, height*screen_ratio.vert), health_bar_image);
	}
}