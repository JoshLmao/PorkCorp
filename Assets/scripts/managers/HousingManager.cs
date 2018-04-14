using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousingManager : MonoBehaviour {

    public List<IHouse> Houses { get; set; }

    public HousingManager()
    {
        Houses = new List<IHouse>();    
    }

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
