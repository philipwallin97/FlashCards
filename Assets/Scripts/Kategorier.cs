using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kategorier : MonoBehaviour {
    bool[] kats = { false, false, false, false, false };
    public Animation anim ;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addKat()
    {
        Debug.Log(kats.Length);
        for (int i=0; i<kats.Length; i++)
        {
            if(kats[i] == false)
            {
                kats[i] = true;
                anim.Play("AddKat");
                Debug.Log("Added kategori to slot : " + i);
                i = 10;
            }
            else
            {
                Debug.Log("No more space for categories!");
            }
        }

    }
}
