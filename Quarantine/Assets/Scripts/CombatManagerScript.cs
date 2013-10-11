using UnityEngine;
using System.Collections;

public class CombatManagerScript : MonoBehaviour {

    public CombatTimer combat_timer;

    private int moves_received = 0;

    public Player player;
    public Player player2;

    private int player1_move, player2_move;

	// Use this for initialization
	void Start () {
        //combat_timer.StartTimer(10);
	}
	
	// Update is called once per frame
	void Update () {
	}

    [RPC]
    public void StartCombat()
    {
        combat_timer.StartTimer(10);
    }

    [RPC]
    public void SubmitMove(string name, int move)
    {
        if (Network.isClient)
            networkView.RPC("SubmitMove", RPCMode.OthersBuffered, "client", move);

        Debug.Log("server chose move " + move);
        /*moves_received++;

        if (moves_received == 1)
            player2_move = move;
        else
            player1_move = move;

        if (moves_received < 2)
            return;

        // make a decision about what happend (e.g. player took damage, enemy took none)

        // update the player objects
        player.setText("Move: " + player1_move);
        if (Network.isServer)
            player2.networkView.RPC("setText", RPCMode.AllBuffered, "Move: " + player2_move);
        else
            player2.networkView.RPC("setText", RPCMode.AllBuffered, "Move: " + player2_move);

        // call the start timer on both sides
        if (Network.isClient || Network.isServer) // if we are networked then call the RPC method
            combat_timer.networkView.RPC("StartTimer", RPCMode.AllBuffered, 10.0f);
        else
            combat_timer.StartTimer(10.0f); // otherwise just call the method directly*/
    }
}
