using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockScript : MonoBehaviour
{

    public static bool DO_NOT = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _blockValue;
    [SerializeField]
    private bool _initialized = false;
    [SerializeField]
    private Sprite _blockBack;
    [SerializeField]
    private Sprite _blockFace;
    private GameObject _grid;

    private void Start()
    {

        _state = 1;
        _grid = GameObject.FindGameObjectWithTag("Grid");

    }

    public void SetupGraphics()
    {
        _grid = GameObject.FindGameObjectWithTag("Grid");
        _blockBack = _grid.GetComponent<GridScript>().getBlockBack();
        _blockFace = _grid.GetComponent<GridScript>().getBlockFace(_blockValue);
        GetComponent<SpriteRenderer>().sprite = _blockBack;  ///!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    }

    public void flipCard()
    {
       

        _grid.GetComponent<GridScript>().ChangeStatus();

        if (_state == 0 && !DO_NOT)
        {
            GetComponent<SpriteRenderer>().sprite = _blockBack;

        }

        else if (_state == 1 && !DO_NOT)
        {
            GetComponent<SpriteRenderer>().sprite = _blockFace;

        }

        if (_state == 0) _state = 1;
        else if (_state == 1) _state = 0;
        _grid.GetComponent<GridScript>().CheckCards();

    }





    public int blockValue
    {
        get { return _blockValue; }
        set { _blockValue = value; }

    }

    public int state
    {
        get { return _state; }
        set { _state = value; }

    }

    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }

    }

}
