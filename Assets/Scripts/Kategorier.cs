using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kategorier : MonoBehaviour {
    bool[] kats = { false, false, false, false, false };
    public Animation anim ;
    public InputField input;
    int currentScene;
    public  Text[] katTitle = new Text[5];
    public GameObject[] katObject = new GameObject[5];
    private bool settingsOnOff = false;
    public Button[] deleteButtons = new Button[1];
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        if (settingsOnOff)
        {
            for(int i=0; i< deleteButtons.Length; i++)
            {
              //  deleteButtons[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < deleteButtons.Length; i++)
            {
               // deleteButtons[i].gameObject.SetActive(false);
            }
        }
	}

    public void addKat()
    {
        Debug.Log(kats.Length);
        for (int i=0; i<kats.Length; i++)
        {
            if(kats[i] == false)
            {
                kats[i] = true;
                anim.Play("PutSide");
                Debug.Log("Added kategori to slot : " + i);
                i = 10;
            }
            else
            {
                Debug.Log("No more space for categories!");
            }

        }


    }

    public void mainMenu()
    {
        for (int i = 0; i < katTitle.Length; i++)
        {

            if (katTitle[i].text == "")
            {
                katObject[i].SetActive(true);
                katTitle[i].text = input.text;
                i = 10;
            }
        }
        anim.Play("InvertSide");
        Debug.Log("Going to mainmenu");
    }

    public void startGame()
    {
        anim.Play("GameView");
    }

    public void revertGame()
    {
        anim.Play("RevertGame");
    }

    public void showSettings()
    {
        if (!settingsOnOff)
        {
            settingsOnOff = true;

        }
        else
        {
            settingsOnOff = false;
        }     
    }
    public void removeKat()
    {
       Debug.Log( System.Array.IndexOf(kats, this));
    }
}


