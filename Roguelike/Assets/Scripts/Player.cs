using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject {

	public int wallDamage = 1;
	public int pointsPerFood = 10;
	public int pointsPerSoda = 20;
	public float restarLevelDelay = 1f;

	private Animator animator;
	private int food;

	// Use this for initialization
	protected override void Start () {
		animator = GetComponent<Animator> ();

		food = GameManager.instance.playerFoodPoints;
		base.Start ();
	}

	private void OnDisable() {
		GameManager.instance.playerFoodPoints = food;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.playersTurn) return;
	}

	protected override void AttemptMove <T> (int xDir, int yDir) {
		food--;

		base.AttemptMove <T> (xDir, yDir);

		RaycastHit2D hit;

		CheckIfGameOver ();

		GameManager.instance.playersTurn = false;
	}

	private void CheckIfGameOver() {
		if (food <= 0) {
			GameManager.instance.GameOver ();
		}
	}
}
