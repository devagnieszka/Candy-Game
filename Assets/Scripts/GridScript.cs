using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GridScript : MonoBehaviour {

    public Sprite[] blockFace;
    public Sprite blockBack;
    private int xDimension;
    private int yDimension;
    public GameObject[] blocks;
    private int pairs;
    private int hits = 0;
    GameObject text;

    private int scale = 40;
    public GameObject backgroungPrefab;

    void Start () {


        switch (MenuScript.difficulty)
        {
            default:
            case (0):
                xDimension = 4;
                yDimension = 3;
                break;

            case (1):
                xDimension = 6;
                yDimension = 5;
                break;

            case (2):
                xDimension = 10;
                yDimension = 6;
                break;

        }


        text = GameObject.FindGameObjectWithTag("Text");
        text.SetActive(false);


        int dimension = xDimension * yDimension;
        pairs = dimension / 2;
        blocks = new GameObject[dimension];
        int number = 0;

        for (int x = 0; x < xDimension*scale; x+=scale)
        {
            for (int y = 0; y < yDimension*scale; y+=scale)
            {
                


                blocks[number] = Instantiate(backgroungPrefab, GetCenter(x,y,0), Quaternion.identity);
                blocks[number].name = "block " + number;
                blocks[number].transform.parent = transform;

                number++;

            }


        }
        InitializeBlocks();

       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    Vector3 GetCenter(int x, int y, int z)
    {
        return new Vector3(transform.position.x - (xDimension*scale) / 2.0f + x, transform.position.y + (yDimension*scale) / 2.0f - y, z);
    }

    

    void InitializeBlocks()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 0; i < blocks.Length/2; i++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = UnityEngine.Random.Range(0, blocks.Length);

                    
                    test = !blocks[choice].GetComponent<BlockScript>().initialized;
                }

                blocks[choice].GetComponent<BlockScript>().blockValue = i;
                blocks[choice].GetComponent<BlockScript>().initialized = true;


            }


        }
      

        foreach (var b in blocks)
        {
            b.GetComponent<BlockScript>().SetupGraphics();         
        }



    }





    public void CheckCards()
    {
        List<int> isTurn = new List<int>();

        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].GetComponent<BlockScript>().state == 0)
                isTurn.Add(i);
        }




        if (isTurn.Count == 2)
        {
            cardComparision(isTurn);
        }
    }

    private void cardComparision(List<int> isTurn)
    {
       
        BlockScript.DO_NOT = true;
        int x = 0;
        if (blocks[isTurn[0]].GetComponent<BlockScript>().blockValue == blocks[isTurn[1]].GetComponent<BlockScript>().blockValue)
        {
      
            x = 2;
            hits++;
        }
        else x = 3;



        for (int i = 0; i < isTurn.Count; i++)
        {
            blocks[isTurn[i]].GetComponent<BlockScript>().state = x;
        



        }

        BlockScript.DO_NOT = false;

        if (pairs==hits)
        {
           
            blocks[isTurn[0]].GetComponent<BlockScript>().GetComponent<SpriteRenderer>().enabled = false;
            blocks[isTurn[1]].GetComponent<BlockScript>().GetComponent<SpriteRenderer>().enabled = false;
            text.SetActive(true);
            
        }
    }

    public void ChangeStatus()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].GetComponent<BlockScript>().state == 3)
            {
                blocks[i].GetComponent<BlockScript>().SetupGraphics();
                blocks[i].GetComponent<BlockScript>().state = 1;
            }

            if (blocks[i].GetComponent<BlockScript>().state == 2)
            {
                blocks[i].GetComponent<BlockScript>().GetComponent<SpriteRenderer>().enabled = false;
                blocks[i].GetComponent<BlockScript>().GetComponent<SpriteRenderer>().enabled = false;
            }

        }
    }


    public void LoadScene()
    {
        SceneManager.LoadScene("start");
    }


    public Sprite getBlockBack()
    {
        return blockBack;
    }

    public Sprite getBlockFace(int i)
    {
       
     
        return blockFace[i];
       
    }








}

