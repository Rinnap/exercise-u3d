using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillcell : MonoBehaviour
{
    private GameManager GameManager;
    //private GameObject staffUnderattack;
    public GameObject cell;
    private int staffstatusback;

    void Start()
    {

    }

    void OnEnable()
    {
        //遍历角色
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //staffstatusback=GameManager.
        if (cell.GetComponent<Cells>().staffOnCell != null && GameManager.turn % 2 != cell.GetComponent<Cells>().staffOnCell.GetComponent<Staff>().party)
        {
            staffstatusback = cell.GetComponent<Cells>().staffOnCell.GetComponent<Staff>().staffStatus;
            cell.GetComponent<Cells>().staffOnCell.GetComponent<Staff>().changeStatus(4);
        }
   
    }

    void OnDisable()
    {
        if (cell.GetComponent<Cells>().staffOnCell != null && GameManager.turn % 2 != cell.GetComponent<Cells>().staffOnCell.GetComponent<Staff>().party)
        {
            cell.GetComponent<Cells>().staffOnCell.GetComponent<Staff>().changeStatus(staffstatusback);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
