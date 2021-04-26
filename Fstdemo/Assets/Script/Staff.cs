using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Staff : MonoBehaviour
{
    public int moveRange;
    public int attackRange;
    public int staffStatus;
    public Light statusLight;
    public int party;//0是蓝队，1是黄队。
    public GameObject staffHead;

    public int atk = 10;
    public int hpmax;
    public int hp;
    public int magicatk = 10;
    public GameObject OnCell;

    // public NavMeshAgent agent;

    public skillku skillku;
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        skillku = GameObject.Find("GameManager").GetComponent<skillku>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void OnMouseDown()
    //{
    //    switch (staffStatus)
    //    {
    //        //未选中状态时，当没有角色被选中时即可被选中。
    //        case 0:
    //            if (!GameManager.isSelected)
    //            {
    //                GameManager.selected = gameObject;
    //                GameManager.agent = GetComponent<NavMeshAgent>();
    //                GameManager.ShowMoveRange();
    //                Debug.Log("MouseDown");
    //                changeStatus(1);
    //                GameManager.isSelected = true;
    //            }
    //         break;
    //            //选中状态时，不可操作。
    //        case 1:
    //            GameManager.CloseMoveRange();
    //            GameManager.personui.SetActive(true);
    //            break;
    //            //被攻击状态,被攻击。
    //        case 2:
    //            underAttack();
    //            break;
    //            //结束状态时，不可操作。
    //        case 3:
    //            break;
    //    }
       
        
    //}

    public void ShowAttackRange()
    {

    }

    //public void SetStaffOutline(string linemode)
    //{
    //    switch (linemode)
    //    {
    //        case "xuanzhong":
    //            outline.OutlineColor = Color.green;
    //            break;
    //        case "beigongji":
    //            outline.OutlineColor = Color.red;
    //            break;
    //        case "guanbi":
    //            outline.OutlineColor = new Color(0, 0, 0, 0);
    //            break;
    //        default:
    //            break;
    //    }
    //}

    public void changeStatus(int status)
    {
        staffStatus = status;
        switch(status)
        {
            case 1:
                statusLight.enabled = true;
                statusLight.color = new Color32(0, 75, 150, 255);
                break;
            case 2:
                statusLight.enabled = true;
                statusLight.color = Color.red;
                break;
            case 0:
                statusLight.enabled = true;
                statusLight.color = new Color32(128, 128, 128, 255); 
                break;
            case 3:
                statusLight.enabled = false;
                break;
            case 4:
                statusLight.enabled = true;
                statusLight.color = Color.green;
                break;
            default:
                break;
        }//0是未选中，1是选中，2是即将被攻击,3是行动结束。
    }

    public void underAttack()
    {
        //hp -= GameManager.selected.GetComponent<Staff>().atk;
        hpChange(-GameManager.selected.GetComponent<Staff>().atk);
        Debug.Log(gameObject + "收到" + GameManager.selected.GetComponent<Staff>().atk + "点伤害,还剩余" + hp + "点血量");
        changeStatus(3);
        GameManager.staffEnd();

       
       
    }

    public void staffDeath()
    {
       staffHead.GetComponent<StaffHeadUI>().deadGray();
       gameObject.SetActive(false);
    }

    public void underHeal(int healNum)
    {
        hp = Mathf.Clamp(hp + healNum, 0, hpmax);
        Debug.Log(gameObject + "收到" + healNum+ "点治疗,还剩余" + hp + "点血量");
        changeStatus(3);
        GameManager.staffEnd();
        staffHead.GetComponent<StaffHeadUI>().hpchange(hp, hpmax);
    }

    public void hpChange(int numChange)
    {
        hp = Mathf.Clamp(hp + numChange , 0, hpmax);
        staffHead.GetComponent<StaffHeadUI>().hpchange(hp, hpmax);
        if (hp <= 0)
        {
            staffDeath();
        }
    }
}
