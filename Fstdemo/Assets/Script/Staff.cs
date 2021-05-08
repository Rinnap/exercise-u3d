using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Staff : MonoBehaviour
{
    public int moveRange;
    public int attackRange;
    public int staffStatus;//0是未选中，1是选中，2是即将被攻击,3是行动结束,4是回复技能释放。
    public Light statusLight;
    public int party;//0是蓝队，1是黄队。
    public GameObject staffHead;
    public float xOffset;
    public float yOffset;
    public Image staffSkill;
    public Button prefab;
    private Action skillIns;
    public Action<int> mouseOver;
    public bool staffSkillshow;

    public string staffName="史学家";
    public int atk;
    public int a;
    public int hpmax;
    public int hp;
    public int magicatk;
    public GameObject OnCell;

    // public NavMeshAgent agent;

    public skillku skillku;
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        skillku = GameObject.Find("GameManager").GetComponent<skillku>();
        atrribteset();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void OnMouseEnter()
    {
        switch (staffStatus)
        {
            //未选中状态
            case 0:
  
                break;
            //选中状态时
            case 1:
   
                break;
            //被攻击状态时，显示技能范围。
            case 2:
                GameManager.showUnAttackRange(skillku.skillRange,OnCell.transform.position);
                break;
            //结束状态时。
            case 3:
                break;
            //
            case 4:
                 GameManager.showUnAttackRange(skillku.skillRange,OnCell.transform.position);
                break;
        }
    }

    public void OnMouseExit()
    {
        switch (staffStatus)
        {
            //未选中状态
            case 0:

                break;
            //选中状态时
            case 1:

                break;
            //被攻击状态时，显示技能范围。
            case 2:
                GameManager.closeUnAttackRange();
                break;
            //结束状态时。
            case 3:
                break;
            //
            case 4:
                GameManager.closeUnAttackRange();
                break;
        }
    }



    public void OnMouseDown()
    {
        switch (staffStatus)
        {
            //未选中状态时，当没有角色被选中时即可被选中。
            case 0:
                if (!GameManager.isSelected)
                {
                    //clearSkill();
                    //insistSkill();
                    //Debug.Log("staff" + a);
                    skillset();
                    GameManager.selected = gameObject;
                    GameManager.agent = GetComponent<NavMeshAgent>();
                    GameManager.ShowMoveRange();
                    Debug.Log("MouseDown");
                    changeStatus(1);
                    GameManager.isSelected = true;
                }
                break;
            //选中状态时，不可操作。
            case 1:
                GameManager.CloseMoveRange();
                GameManager.personui.SetActive(true);
                break;
            //被攻击状态,被攻击。
            case 2:
                GameManager.onClickStaff = gameObject;
                GameManager.skill();
                break;
            //结束状态时，不可操作。
            case 3:
                break;
            case 4:
                GameManager.onClickStaff = gameObject;
                GameManager.skill();
                break;
        }
    }

        public virtual void skillset()
    {

    }
      public virtual void atrribteset()
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
        }//0是未选中，1是选中，2是即将被攻击,3是行动结束,4是回复技能释放。
    }

    //public void underAttack()
    //{
    //    //hp -= GameManager.selected.GetComponent<Staff>().atk;
    //    hpChange(-GameManager.selected.GetComponent<Staff>().atk);
    //    Debug.Log(gameObject + "收到" + GameManager.selected.GetComponent<Staff>().atk + "点伤害,还剩余" + hp + "点血量");
    //    changeStatus(3);
    //    GameManager.staffEnd();
    //}

    public void staffDeath()
    {
       staffHead.GetComponent<StaffHeadUI>().deadGray();
         OnCell.GetComponent<Cells>().staffOnCell = null;
       gameObject.SetActive(false);
        //Destroy(gameObject);
   
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
        if (numChange > 0)
        {
            GameManager.tishi(staffName+"收到"+GameManager.selected.GetComponent<Staff>().staffName+numChange+"点治疗，还剩余"+hp+"点生命值");
        }
        else if (numChange < 0)
        {
            GameManager.tishi(staffName + "收到" + GameManager.selected.GetComponent<Staff>().staffName + numChange + "点伤害，还剩余" + hp + "点生命值");

        }
        if (hp <= 0)
        {
            staffDeath();
        }
    }

    public void insistSkill(string skillName, Action skillFf)
    {
        Button skill1 = Instantiate(prefab);
        skill1.transform.parent = staffSkill.transform;
        Text skill1Text = skill1.transform.GetComponentInChildren<Text>();
        skill1Text.text = skillName;
        //skill1.onClick.AddListener(skillFf);
        skill1.onClick.AddListener(() => { skillFf(); });
    }

    public void clearSkill()
    {

        for (int i = 0; i < staffSkill.transform.childCount; i++)
        {
            Destroy(staffSkill.transform.GetChild(i).gameObject);
        }
    }

    public void showstaffSkillUI()
    {
        staffSkill.enabled = true;
        //staffSkillshow = true;

    }
}
