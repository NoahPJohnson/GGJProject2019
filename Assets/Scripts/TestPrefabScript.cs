using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrefabScript : MonoBehaviour {

    [SerializeField] GameObject testObject;
	// Use this for initialization
	void Start ()
    {
        testObject = (GameObject)Resources.Load("5x5 Prefab");
        GameObject.Instantiate(testObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
