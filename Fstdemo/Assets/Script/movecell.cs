using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecell : MonoBehaviour
{
    private GameManager GameManager;
    public GameObject cell;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //玩家移动
    private void OnMouseDown()
    {
        Vector3 movepoint = gameObject.transform.position;
        GameManager.moveStaff(movepoint);
        Debug.Log("cellshere:" + gameObject.transform.position);
        Debug.Log("movehere:" + movepoint);
        GameManager.CloseMoveRange();
    }


}
