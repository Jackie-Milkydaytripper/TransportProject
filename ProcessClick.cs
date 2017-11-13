using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessClick : MonoBehaviour {
	public int MyX, MyY;
	//SummonCubes mySummonCubes;
	// Use this for initialization
	void Start () {
		//mySummonCubes = GameObject.Find ("CubeSummon").GetComponent<SummonCubes> ();
		}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		SummonCubes.ProcessClick (gameObject, MyX, MyY);
		//print ("x" + x + "...y: " + y); 
		}
		
}