using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillcell : MonoBehaviour
{
    private GameManager GameManager;
    private GameObject staffUnderattack;
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
        cell.GetComponent<Cells>().staffOnCell.GetComponent<Staff>().changeStatus(4);
        
    }

    private void OnDisable()
    {
       staffUnderattack.GetComponent<Staff>().changeStatus(3);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
