using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMasterPersistant : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Object.DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
