using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GameManager : MonoBehaviour
{
    public GameObject selected;
    public GameObject[] cells;
    public NavMeshAgent agent;
    public GameObject personui;

    private bool isMove = false;
    private List<GameObject> moveList;
    private GameObject selectedCell;
    // Start is called before the first frame update
    void Start()
    {
        cells = GameObject.FindGameObjectsWithTag("cell");
        moveList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //ShowAttackRange();
        ShowpersonUI();
    }
    //显示攻击范围
    public void ShowMoveRange()
    {
        CloseMoveRange();
        //遍历格子
        foreach(var cell in cells)
        {
            if (Mathf.Abs(Vector3.Distance(cell.transform.position, selected.transform.position)) <= 10)
            {
                selectedCell = cell;
            }
        }
        foreach (var cell in cells)
        {
            int range = selected.GetComponent<Staff>().moveRange;
            if (Mathf.Abs(cell.transform.position.x - selectedCell.transform.position.x) +
               Mathf.Abs(cell.transform.position.z - selectedCell.transform.position.z)<=range)
            {
                cell.GetComponent<Cells>().moveable = true;
                cell.GetComponent<Cells>().moveCell.SetActive(true);  
                moveList.Add(cell);
            }
        }

    }

    //关闭攻击范围
    public void CloseMoveRange()
    {
        foreach(var cell in moveList)
        {
            cell.GetComponent<Cells>().moveable = false;
            cell.GetComponent<Cells>().moveCell.SetActive(false);
        }
        moveList.Clear();
    }
    //显示攻击范围
    public void ShowAttackRange()
    {
        //if (agent.remainingDistance < 0.2 && isMove)
        //{
        //    Debug.Log("到达地点");
        //    isMove = false;
        //    CloseMoveRange();
        //    foreach (var cell in cells)
        //    {
        //        if (Mathf.Abs(Vector3.Distance(cell.transform.position, selected.transform.position)) <= 10)
        //        {
        //            selectedCell = cell;
        //        }
        //    }
        //    foreach (var cell in cells)
        //    {
        //        int range = selected.GetComponent<Staff>().attackRange;

        //        if (Mathf.Abs(cell.transform.position.x - selectedCell.transform.position.x) +
        //           Mathf.Abs(cell.transform.position.z - selectedCell.transform.position.z) <= range)
        //        {
        //            cell.GetComponent<Cells>().moveable = true;
        //            cell.GetComponent<Cells>().attackCell.SetActive(true);
        //            moveList.Add(cell);
        //        }
        //    }
        //}  
    }

    public void ShowpersonUI()
    {
        if (agent.remainingDistance < 0.2 && isMove)
        {
            Debug.Log("到达地点");
            isMove = false;
            CloseMoveRange();
            personui.SetActive(true);
        }
    }

    //玩家移动
    public void moveStaff(Vector3 movePoint)
    {
        agent.SetDestination(movePoint);
        isMove = true;

    }
}
