using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class skillku : MonoBehaviour
{
    public GameManager GameManager;
    public Staff onAttackstaff;
    public Staff attackstaff;

    private Action move;
    private GameObject[] cells;
    void Start()
    {
        GameManager = gameObject.GetComponent<GameManager>();
        cells = GameObject.FindGameObjectsWithTag("cell");
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    public void test()
    {
        Debug.Log("技能库测试");
    }

    //技能回复
    public void huifu()
    {
        GameManager.onClickStaff.GetComponent<Staff>().hpChange(GameManager.selected.GetComponent<Staff>().magicatk);
        Debug.Log(GameManager.onClickStaff + "收到10点治疗");
        GameManager.staffEnd();
    }

    //技能重击
    public void zhongji()
    {
        int hpchange = -(int)(GameManager.selected.GetComponent<Staff>().atk * 1.5);
        GameManager.onClickStaff.GetComponent<Staff>().hpChange(hpchange);
        Debug.Log(GameManager.onClickStaff + "收到"+hpchange+"伤害");
        GameManager.staffEnd();
    }

    //技能冲击
    public void chongji()
    {
        GameObject unSkillCell = null;
        List<GameObject> unSkillsCells=new List<GameObject>();
        float distance=Mathf.Infinity;

        //找出目标附近的格子
        foreach (var cell in cells)
        {
            if (Mathf.Abs(cell.transform.position.x - GameManager.onClickStaff.GetComponent<Staff>().OnCell.transform.position.x) +
               Mathf.Abs(cell.transform.position.z - GameManager.onClickStaff.GetComponent<Staff>().OnCell.transform.position.z) <= 50)
            {
                //Debug.Log("测试节点0" + cell);
                unSkillsCells.Add(cell);
            }
        }
        foreach (var cell in unSkillsCells)
        {
            if(cell.GetComponent<Cells>().staffOnCell!=null)
            {
                //Debug.Log("测试节点1" + unSkillCell);
                continue;
            }
            if (Mathf.Abs(Vector3.Distance(cell.transform.position, GameManager.selected.transform.position)) < distance)
            {
                distance = Mathf.Abs(Vector3.Distance(cell.transform.position, GameManager.selected.transform.position));
                unSkillCell = cell;
                //Debug.Log("选中格子"+unSkillCell);
            }
        }
        if(unSkillCell==null)
        {
            Debug.Log("目标周围无从落脚");
            GameManager.tishi("目标周围无从落脚");
            return;
        }
        GameManager.agent.speed = 200;
        GameManager.agent.angularSpeed = 300;
        GameManager.agent.acceleration = 500;
        GameManager.agent.SetDestination(unSkillCell.gameObject.transform.position);
        move = cj;
        //GameManager.isMove= false;
    }

    //普通攻击
    public void gongji()
    {
        int hpchange = -(int)(GameManager.selected.GetComponent<Staff>().atk);
        GameManager.onClickStaff.GetComponent<Staff>().hpChange(hpchange);
        Debug.Log(GameManager.onClickStaff + "收到" + hpchange + "伤害");
        GameManager.staffEnd();
    }

    private void cj()
    {
        if (GameManager.agent.remainingDistance < 0.2)
        {
            //伤害计算

            int hpchange = -(int)(GameManager.selected.GetComponent<Staff>().atk);
            GameManager.onClickStaff.GetComponent<Staff>().hpChange(hpchange);
            Debug.Log(GameManager.selected + "使用技能冲击" + GameManager.onClickStaff + "收到" + hpchange + "伤害");
            GameManager.staffEnd();
            move = null;
            GameManager.setStaff();
        }

    }
}
