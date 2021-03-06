using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GameManager : MonoBehaviour
{
    public GameObject selected;
    public bool isSelected;
    public GameObject[] cells;
    public NavMeshAgent agent;
    public GameObject personui;
    public GameObject[] staffs;
    public int turn=0;

    private bool isMove;
    private List<GameObject> moveList;
    private List<GameObject> attackList;
    public GameObject selectedCell;
    // Start is called before the first frame update
    void Start()
    {
        cells = GameObject.FindGameObjectsWithTag("cell");
        staffs = GameObject.FindGameObjectsWithTag("staff");
        moveList = new List<GameObject>();
        attackList = new List<GameObject>();
        isSelected = false;
        isMove = false;
        turnChange();
    }

    // Update is called once per frame
    void Update()
    {
        //ShowAttackRange();
        ShowPersonUI();
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
        selectedCell.GetComponent<Cells>().moveCell.SetActive(false);
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
        CloseAttackRange();
            foreach (var cell in cells)
            {
                if (Mathf.Abs(Vector3.Distance(cell.transform.position, selected.transform.position)) <= 10)
                {
                    selectedCell = cell;
                }
            }
            foreach (var cell in cells)
            {
                int range = selected.GetComponent<Staff>().attackRange;
                if (Mathf.Abs(cell.transform.position.x - selectedCell.transform.position.x) +
                   Mathf.Abs(cell.transform.position.z - selectedCell.transform.position.z) <= range)
                {
                    cell.GetComponent<Cells>().attackCell.SetActive(true);
                    attackList.Add(cell);
                }
            }
            //关闭脚下攻击范围
       selectedCell.GetComponent<Cells>().attackCell.SetActive(false);
    }

    //关闭攻击范围
    public void CloseAttackRange()
    {
        foreach (var cell in attackList)
        {
            cell.GetComponent<Cells>().attackCell.SetActive(false);
        }
        attackList.Clear();
    }

    // 显示ui
    public void ShowPersonUI()
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

    //结束角色行动
    public void staffEnd()
    {
        foreach (var cell in cells)
        {
            cell.GetComponent<Cells>().attackCell.SetActive(false);
        }
        selected.GetComponent<Staff>().changeStatus(3);
        isSelected = false;
        personui.SetActive(false);
    }

    //切换玩家回合
    public void turnChange()
    {
        staffEnd();
        turn += 1;
        if (turn%2==1)//奇数回合蓝队，偶数回合黄队
        {
            foreach (var staff in staffs)
            {
                if(staff.GetComponent<Staff>().party==0)
                {
                    staff.GetComponent<Staff>().changeStatus(0);
                }
                else if (staff.GetComponent<Staff>().party == 1)
                {
                    staff.GetComponent<Staff>().changeStatus(3);
                }
            }
        }
        else if(turn % 2 == 0)
        {
            foreach (var staff in staffs)
            {
                if (staff.GetComponent<Staff>().party == 1)
                {
                    staff.GetComponent<Staff>().changeStatus(0);
                }
                else if (staff.GetComponent<Staff>().party == 0)
                {
                    staff.GetComponent<Staff>().changeStatus(3);
                }
            }
        }
       
        Debug.Log(turn);
;    }
}
