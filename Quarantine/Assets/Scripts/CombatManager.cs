using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour {
	public string game_name = "Immunity Game 390";
	
	enum CombatState { CONNECTING, SLEEPING, WAITING_FOR_MOVES, DECIDING };
	
	// Combat Server starts in connecting mode
	CombatState combat_state = CombatState.CONNECTING;
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch(combat_state)
		{
		case CombatState.CONNECTING:
			break;
		case CombatState.SLEEPING:
			break;
		case CombatState.WAITING_FOR_MOVES:
			break;
		case CombatState.DECIDING:
			break;
		}
	}
}
