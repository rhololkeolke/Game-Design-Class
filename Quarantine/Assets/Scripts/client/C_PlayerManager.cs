using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NetworkView))]
public class C_PlayerManager : MonoBehaviour {
/*	
	private NetworkPlayer owner;
	
	private int lastMove;
	
	[RPC]
	public void setOwner(NetworkPlayer player)
	{
		Debug.Log ("Setting the owner");
		owner = Player;
		if(Player == Network.player)
		{
			enabled = true;	
		}
		else
		{
			// disable everything here	
		}
	}
	
	[RPC]
	public Network getOwner()
	{
		return owner;	
	}
	
	public void Awake()
	{
		if(Network.isClient)
			enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(Network.isServer) {
			return; // this is the client side	
		}
		
		if ((owner != null) && (Network.player == owner))
		{
			move = 10;
			if(move != lastMove)
			{
				networkView.RPC("updateClientMoves",
					RPCMode.Server,
					move);
				
				lastMove = move;
				
			}
		}
	}*/
}