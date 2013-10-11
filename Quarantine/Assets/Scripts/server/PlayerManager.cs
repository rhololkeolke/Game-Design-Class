using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NetworkView))]
public class PlayerManager : MonoBehaviour {
	/*
	public Gestures gestures;
	
	private int move;
	
	// Use this for initialization
	void Start () {
		if (Network.isServer) {
			gestures = (Gestures)GetComponent(typeof(Gestures));	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Network.isClient)
		{
			return; // this is the server side
		}
		
		Debug.Log ("Processing client moves");
			
	}
	
	[RPC]
	public void updateClientMoves(int recv_move)
	{
		move = recv_move;
	}*/
}