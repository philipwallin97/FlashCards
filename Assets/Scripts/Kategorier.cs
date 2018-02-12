using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Kategorier : MonoBehaviour {
    bool[] kats = { false, false, false, false, false };
    public Animation anim ;
    public InputField categoryName;
    public InputField cardFront;
    public InputField cardBack;
    public InputField input;
    public Text text;
    int currentScene;
    public  Text[] katTitle = new Text[5];
    public GameObject[] katObject = new GameObject[5];
    private bool settingsOnOff = false;
    public Button[] deleteButtons = new Button[1];
    public Data data;

	// Use this for initialization
	void Start () {
        LoadData();
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

        // Declare new folder and adding it to data
        //if (string.IsNullOrEmpty(categoryName.text))
        //{
        //    Folder folder = new Folder(categoryName.text);
        //    data.Folders.Add(folder);
        //}

        //if (string.IsNullOrEmpty(cardFront.text) && string.IsNullOrEmpty(cardBack.text))
        //{
            
        //}
        //Card card = new Card(cardFront.text, cardBack.text);
        //AddCardToFolder(categoryName.text, card);
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
                // Declare new folder and adding it to data
                if (!string.IsNullOrEmpty(categoryName.text))
                {
                    Folder folder = new Folder(categoryName.text);
                    data.Folders.Add(folder);
                    SaveData();
                }

                Card card = new Card("asdasd", "asdasd");
                AddCardToFolder(categoryName.text, card);
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
       Debug.Log( Array.IndexOf(kats, this));
    }

    [Serializable]
	public class Card
    {
		public string Front;
		public string Back;

		public Card(string f, string b)
		{
			Front = f;
			Back = b;
		}
	}

    [Serializable]
	public class Folder
    {
		public string Name;
		public List<Card> Cards = new List<Card>();

        public Folder(string name)
        {
            Name = name;
        }
	}

    [Serializable]
	public class Result
    {
		public string Name;
		public int Total;
		public int Right;
		public int Wrong;
	}

    [Serializable]
	public class Data
	{
        public List<Folder> Folders;
        public List<Result> Results;
	}

    public void SaveData()
    {
        File.WriteAllText(Application.dataPath + @"\Scripts\jsontest.json", JsonUtility.ToJson(data).ToString());
    }

    public void LoadData()
    {
        data = new Data
        {
            Folders = new List<Folder>(),
            Results = new List<Result>()
        };


        // Variables for reading json file
        string line;
        string input = "";

        // Declaring file
        StreamReader file;
        try
        {
            file = new StreamReader(Application.dataPath + @"\Scripts\jsontest.json");
        }
        catch (Exception)
        {
            // If file doesn't exist, create it
            File.WriteAllText(Application.dataPath + @"\Scripts\jsontest.json", "");
            file = new StreamReader(Application.dataPath + @"\Scripts\jsontest.json");
        }
        // Read all lines
        while ((line = file.ReadLine()) != null)
        {
            input += line;
        }
        file.Close();

        if (input != "")
        {
            data = JsonUtility.FromJson<Data>(input);
        }
    }

    public Folder FindFolderWithName(string folderName)
    {
        for (int i = 0; i < data.Folders.Count; i++)
        {
            if (data.Folders[i].Name == folderName)
            {
                return data.Folders[i];
            }
        }
        return null;
    }

    public void AddCardToFolder(string folderName, Card card)
    {
        if (FindFolderWithName(folderName) != null)
        {
            FindFolderWithName(folderName).Cards.Add(card);
            SaveData();
        }
        else
        {
            Debug.Log("Couln't save card to folder");
        }
    }
}