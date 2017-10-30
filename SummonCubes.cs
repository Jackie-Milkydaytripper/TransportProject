using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonCubes : MonoBehaviour {

	public GameObject CubeSummon;
	public GameObject currentCube;
	Vector3 cubePosition;
	int airplaneX;
	int airplaineY;
	GameObject airplaneCurrent;
	public static GameObject selectedCube;
	// Use this for initialization

	void Start () {


		airplaneX = 0;
		airplaineY = 8;

		cubePosition = new Vector3 (14, 8, 0);
		for (int x = 0; x < 16; x++) {
			for (int y = 0; y < 9; y++){
				currentCube = Instantiate (CubeSummon, cubePosition, Quaternion.identity);
				cubePosition = new Vector3 (x * 2 - 16, y*2 - 8, 0);
				currentCube.GetComponent<Renderer> ().material.color = Color.white;


			if (x == airplaneX && y == airplaineY);
				airplaneCurrent = currentCube;
				currentCube.GetComponent<Renderer> ().material.color = Color.yellow;
				//using yellow to determine that I've already clicked on the cube
				//Would make for nice code to say "you have already viwed this in your inventory" or something like that



		}
	}
}

	public static void ProcessClick (GameObject clickedCube){
		if (selectedCube != null) {
			selectedCube.GetComponent <Renderer> ().material.color = Color.white;
		}

		clickedCube.GetComponent<Renderer> ().material.color = Color.red;
		selectedCube = clickedCube;
		 
	}
		
	// Update is called once per frame
	void Update () {
       }
		
	}
