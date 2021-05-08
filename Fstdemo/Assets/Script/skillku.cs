using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class skillku : MonoBehaviour
{
    public GameManager GameManager;
    public Staff onAttackstaff;
    public Staff attackstaff;
    public int skillRange;

    private Action move;//移动函数
    private GameObject[] cells;//所有格子
    void Start()
    {
        GameManager = gameObject.GetComponent<GameManager>();
        cells = GameObject.FindGameObjectsWithTag("cell");
    }

    // Update is called once per frame
    void Update()
    {
        if (move != null)
        { move(); }
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
     
        GameObject unSkillCell=null;//落脚点
        List<GameObject> unSkillsCells = new List<GameObject>();//技能影响的格子

        float distance = Mathf.Infinity;

        //找出目标附近的格子
        foreach (var cell in cells)
        {
            if (Mathf.Abs(cell.transform.position.x - GameManager.onClickStaff.GetComponent<Staff>().OnCell.transform.position.x) +
               Mathf.Abs(cell.transform.position.z - GameManager.onClickStaff.GetComponent<Staff>().OnCell.transform.position.z) <= 40)
            {
                //Debug.Log("测试节点0" + cell);
                unSkillsCells.Add(cell);
            }
        }
        foreach (var cell in unSkillsCells)
        {
            if (cell.GetComponent<Cells>().staffOnCell != null)
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

        if (unSkillCell==null)
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
    //技能冲击的移动和伤害计算
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
    //技能散射
    public void sanshe()
    {
    
       List<GameObject> unSkillsCells = new List<GameObject>();//技能影响的格子
                                                                    //找出目标附近的格子
        foreach (var cell in cells)
        {
            if (Mathf.Abs(cell.transform.position.x - GameManager.onClickStaff.GetComponent<Staff>().OnCell.transform.position.x) +
               Mathf.Abs(cell.transform.position.z - GameManager.onClickStaff.GetComponent<Staff>().OnCell.transform.position.z) <= skillRange)
            {
               // Debug.Log("测试节点0" + cell);
                unSkillsCells.Add(cell);

            }
        }
        StartCoroutine("sanshezhixing",unSkillsCells);
        //StartCoroutine("sansheztest" );

    }

    IEnumerator sanshezhixing(List<GameObject> unSkillsCells)
    {
        //关闭所有攻击点
        foreach (var cell in cells)
        {
            cell.GetComponent<Cells>().attackCell.SetActive(false);
        }
        //随机点亮攻击点
        for (int i = 0; i < 7; i++)
        {
            int hpchange = -(int)(GameManager.selected.GetComponent<Staff>().atk / 2);
            int u = Random.Range(0, 12);
            Debug.Log(unSkillsCells[u]);

            unSkillsCells[u].GetComponent<Cells>().attackCell.SetActive(true);
            if (unSkillsCells[u].GetComponent<Cells>().staffOnCell != null && GameManager.turn % 2 == unSkillsCells[u].GetComponent<Cells>().staffOnCell.GetComponent<Staff>().party)
            {
                GameObject staff = unSkillsCells[u].GetComponent<Cells>().staffOnCell;
                staff.GetComponent<Staff>().hpChange(hpchange);
                Debug.Log(GameManager.onClickStaff + "收到" + hpchange + "伤害");
            }
            yield return new WaitForSeconds(0.3f);
            unSkillsCells[u].GetComponent<Cells>().attackCell.SetActive(false);

            //  unSkillsCells[u].GetComponent<Cells>().attackCell.SetActive(false);
        }
        GameManager.staffEnd();
        Debug.Log("sanshezhixing");
    }

    //IEnumerator sansheztest()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    Debug.Log("sanshezhixing");
       
    //}
    public void unAttackRange(int range)
    {
        GameObject selectedCell=null;
        List<GameObject> unattackList=new List<GameObject>();
        foreach (var cell in cells)
        {
            if (Mathf.Abs(Vector3.Distance(cell.transform.position, gameObject.transform.position)) <= 10)
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
                cell.GetComponent<Cells>().unattackCell.SetActive(true);
                unattackList.Add(cell);
            }
        }
    }
    private void cellSearch(int range)
    {
  
    }

}
