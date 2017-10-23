using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonCubes : MonoBehaviour {

	public GameObject CubeSummon;
	public GameObject currentCube;
	Vector3 cubePosition;
	int xPosition;

	// Use this for initialization

	void Start () {

		cubePosition = new Vector3 (-15, 0, 0);
		xPosition += 2;
		for (int i = 0; i < 16; i++){

		currentCube = Instantiate (CubeSummon, cubePosition, Quaternion.identity);
		currentCube.GetComponent<Renderer> ().material.color = Color.white;
		cubePosition += new Vector3 (xPosition, 0, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {


			
		}



		
	}
