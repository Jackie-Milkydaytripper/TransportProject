using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SummonCubes : MonoBehaviour {

	public GameObject CubeSummon;
	public GameObject currentCube;
	Vector3 cubePosition;
	int y;
	int x;
	static int airplaneX, startX;
	static int airplaneY, startY;
	static int DepotX, DepotY;
	static int TargetX, TargetY;
	static bool airplaneCurrent;
	int airplaneCap, airplaneCapMax;
	int cargoAdd;
	int moveY, moveX;
	public static GameObject selectedCube;
	static GameObject[,] CubeGroup;
	static int GroupX,GroupY;
	float turnTime, TurnDuration;
	int Score;

	// Use this for initialization

	void Start () {

		//How many game objects to hold
		turnTime = 1.5f;
		TurnDuration = turnTime;

		airplaneCap = 0;
		airplaneCapMax = 90;
		cargoAdd = 10;

		Score = 0;

		GroupX = 16;
		GroupY = 9;
		CubeGroup = new GameObject[GroupX, GroupY];

		cubePosition = new Vector3 (14, 8, 0);

		for (int x = 0; x < GroupX; x++) {
			for (int y = 0; y < GroupY; y++) { //storing what is happening in each part of the grid
				cubePosition = new Vector3 (x * 3 - 16, y * 3 - 8, 0);
				// Create the created object, and store it
				CubeGroup [x, y] = Instantiate (CubeSummon, cubePosition, Quaternion.identity);
				//Set the value of a cube to where x is
				CubeGroup [x, y].GetComponent<ProcessClick> ().MyX = x;
				CubeGroup [x, y].GetComponent<ProcessClick> ().MyY = y;


			}

			//Airplane upper left -- Depot bottom right

			startX = 0;
			startY = GroupY - 1;
			airplaneX = startX;
			airplaneY = startY;
			TargetX = airplaneX;
			TargetY = airplaneY;
			CubeGroup[airplaneX, airplaneY].GetComponent<Renderer> ().material.color = Color.red;
			airplaneCurrent = false;
			DepotY = 0;
			//For some reason, each time I tinker with this, the depot will always be on the left
			//or will make the grid into a single column
			DepotX =  GroupX - 16;
			CubeGroup[DepotY, DepotX].GetComponent<Renderer> ().material.color = Color.black;

			moveX = 0;
			moveY = 0;
		}			
}

	public static void ProcessClick (GameObject selectedCube, int x, int y){
		//(static means that there is only one version of it
		if (x == airplaneX && y == airplaneY) {
		
			if (airplaneCurrent) {
				// deactivate airplane
				airplaneCurrent = false;
				selectedCube.transform.localScale /= 1.5f;
				TargetX = airplaneX;
				TargetY = airplaneY;

			} else {
				airplaneCurrent = true;
				selectedCube.transform.localScale *= 1.5f;

			}
		}
		else if (airplaneCurrent) {
			TargetX = x;
			TargetY = y;
		}
	}

	void GiveCargo () {
		if (airplaneX == startX && airplaneY == startY) {
			//Give Cargo to airplane
			airplaneCap += cargoAdd;

			if (airplaneCap > airplaneCapMax) {
				airplaneCap = airplaneCapMax;
				//Add the cargo, if the maximum capacity is reached, stop!

			}

			//^ returns the value of cargoAdd
		}
	}
	void DeliverCargo () {
		if (airplaneX == DepotX && airplaneY == DepotY) {
			Score += airplaneCap;
			airplaneCap = 0;
		}
	}
	void determineDirection (){

		if (airplaneY > TargetY) {
			moveY = -1;

		} else if (airplaneY < TargetY) {
			moveY = 1;
		} 


		if (airplaneX < TargetX) {
			moveX = 1;	

		}
		else if (airplaneX > TargetX) {
			moveX = -1;	
		}

	}

	void MoveAirplane (){

		if (airplaneCurrent) {
			determineDirection ();

			if (airplaneCurrent) {
				//Reset scale and color
				if (airplaneX == DepotX && airplaneY == DepotY) {
					CubeGroup [DepotX, DepotY].GetComponent<Renderer> ().material.color = Color.black;

				} else {
					CubeGroup [airplaneX, airplaneY].GetComponent<Renderer> ().material.color = Color.white;
					CubeGroup [airplaneX, airplaneY].transform.localScale /= 1.5f;

					//Give airplane new home and color, and make sure it doesn't go out of bounds
					airplaneX += moveX;
					airplaneY += moveY;


					if (airplaneX > GroupX) {
						airplaneX = GroupX - 1;
					} 
					else if (airplaneX < 0) {
						airplaneX = 0;
					}

					if (airplaneY > GroupY) {
						airplaneY = GroupY - 1;
					} 
					else if (airplaneX < 0) {
						airplaneY = 0;
					}
					
					CubeGroup [airplaneX, airplaneY].GetComponent<Renderer> ().material.color = Color.red;
					CubeGroup [airplaneX, airplaneY].transform.localScale *= 1.5f;

				}
							
			}
			
		}
	}


	// Update is called once per frame
	void Update () {



		if (Time.time > turnTime) {
			MoveAirplane ();
			GiveCargo ();
			DeliverCargo ();
			print ("Cargo: " + airplaneCap + "...score:" + Score);

			turnTime += TurnDuration;
		}
	}
			
}