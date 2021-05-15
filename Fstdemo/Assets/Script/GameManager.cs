using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject selected;
    public bool isSelected;
    public GameObject[] cells;
    public NavMeshAgent agent;
    public GameObject personui;
    public GameObject[] staffs;
    public int turn=0;
    public Text turnUI;
    public Action skill; //委托当前技能
    public Action buffSkill;//
    public Action<int,Vector3> showUnAttackRange;
    public skillku skillku;
    public GameObject staffSkill;
    public bool isMove=false;
    private List<GameObject> moveList;
    private List<GameObject> attackList;
    public GameObject selectedCell;
    public GameObject onClickStaff;
    public Text tishiText;
    // Start is called before the first frame update
    void Start()
    {
        skillku = gameObject.GetComponent<skillku>();
        cells = GameObject.FindGameObjectsWithTag("cell");
        staffs = GameObject.FindGameObjectsWithTag("staff");
        moveList = new List<GameObject>();
        attackList = new List<GameObject>();
        isSelected = false;
        turnChange();
    }

    // Update is called once per frame
    void Update()
    {
        //ShowAttackRange();
        ShowPersonUI();
        //if (selected != null)
        //{
        //    Debug.Log("gamemanageer:" + selected.GetComponent<Staff>().a);
        //}
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
     //   selectedCell.GetComponent<Cells>().moveCell.SetActive(false);
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

    //设置攻击
    public void AttackSet()
    {
        ShowAttackRange(selected.GetComponent<Staff>().attackRange);
        skill = skillku.gongji;
        skillku.skillRange = 1;
    }

    //显示攻击范围
    public void ShowAttackRange(int range)
    {
        //if (agent.remainingDistance < 0.2 && isMove)
        //{
        //    Debug.Log("到达地点");
        //    isMove = false;
        //    CloseMoveRange();
        staffSkill.SetActive(false); 
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
                //int range = selected.GetComponent<Staff>().attackRange;
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
        if (selected!=null&&agent.remainingDistance < 0.2 && isMove)
        {
            Debug.Log("到达地点");
            isMove = false;
            CloseMoveRange();
            personui.SetActive(true);
          setStaff();
        }
    }

    //玩家移动
    public void moveStaff(Vector3 movePoint)
    {
        agent.speed = 100;
        agent.angularSpeed = 120;
        agent.acceleration = 200;
        agent.SetDestination(movePoint);
        isMove = true;
    }

    //结束角色行动
    public void staffEnd()
    {
        foreach (var cell in cells)
        {
            cell.GetComponent<Cells>().attackCell.SetActive(false);
            cell.GetComponent<Cells>().skillCell.SetActive(false);
        }
        if (selected != null)
        {
            selected.GetComponent<Staff>().changeStatus(3);
        }

        isSelected = false;
        personui.SetActive(false);
        staffSkill.SetActive(false);
        closeUnAttackRange();
   
    }

    public void ShowSkillRange(int skillrange)
    {
        //if (agent.remainingDistance < 0.2 && isMove)
        //{
        //    Debug.Log("到达地点");
        //    isMove = false;
        //    CloseMoveRange();
        //CloseSkillRange();
        staffSkill.SetActive(false);
        foreach (var cell in cells)
        {
            if (Mathf.Abs(Vector3.Distance(cell.transform.position, selected.transform.position)) <= 10)
            {
                selectedCell = cell;
            }
        }

        foreach (var cell in cells)
        {

            if (Mathf.Abs(cell.transform.position.x - selectedCell.transform.position.x) +
               Mathf.Abs(cell.transform.position.z - selectedCell.transform.position.z) <= skillrange)
            {
                if (cell != selectedCell)
                {
                    cell.GetComponent<Cells>().skillCell.SetActive(true);
                    attackList.Add(cell);
                }
            }
        }
        //关闭脚下攻击范围
    }
    //切换玩家回合
    public void turnChange()
    {
        if (isMove)
        {
            return;
        }
        staffEnd();
        turn += 1;
        turnUI.text = "回合"+turn.ToString();
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
        //buff层数变化
        foreach (var staff in staffs)
        {
            staff.GetComponent<StaffBuffs>().TikBuff();
        }
        CloseMoveRange();
        CloseAttackRange();
        Debug.Log(turn);
    }

    public void skillAction()
    {
        
    }
    //文字提示
    public void tishi(string text)
    {
        if (!tishiText.enabled)
        {
            StartCoroutine("textControl");
        }
        tishiText.enabled = true;
        tishiText.text = text;

    }

    IEnumerator textControl()
    {
        Debug.Log("提示倒计时携程已开启");
        yield return new WaitForSeconds(3);
        tishiText.enabled = false;
    }

    //重新设置cell绑定的staff
    public void setStaff()
    {
        foreach (var cell in cells)
        {
            cell.GetComponent<Cells>().setStaff();
        }
    }

    //显示范围攻击技能的范围
    public void GeneralAttackRange(int range,Vector3 position)
    {
   
        foreach (var cell in cells)
        {

            if (Mathf.Abs(cell.transform.position.x - position.x) +
               Mathf.Abs(cell.transform.position.z - position.z) <= range)
            {
                    cell.GetComponent<Cells>().unattackCell.SetActive(true);
            }
        }
    }

    //关闭范围攻击技能的范围
    public void closeUnAttackRange()
    {
        foreach (var cell in cells)
        {
            cell.GetComponent<Cells>().unattackCell.SetActive(false);
        }
    }
}
