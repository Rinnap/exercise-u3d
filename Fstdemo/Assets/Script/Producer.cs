using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System;

public class Producer : Staff
{



    // Start is called before the first frame update
    //void Start()
    //{
    //    //atk = 20;
    //    //a = 20;
    //}



    //void Update()
    //{

    //    //Vector2 player2DPosition = Camera.main.WorldToScreenPoint(GameManager.selected.transform.position);
    //    //将玩家坐标转化为屏幕

    //    ////血条超出屏幕就不显示
    //    //if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
    //    //{
    //    //    attack.gameObject.SetActive(false);
    //    //}
    //    //else
    //    //{
    //    //    attack.gameObject.SetActive(true);
    //    //}
    //    //if (staffSkillshow)
    //    //{
    //    //    Vector2 player2DPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    //    //    staffSkill.rectTransform.position = player2DPosition + new Vector2(xOffset, yOffset);
    //    //}

    //}


    //public void OnMouseDown()
    //{
    //    switch (staffStatus)
    //    {
    //        //未选中状态时，当没有角色被选中时即可被选中。
    //        case 0:
    //            if (!GameManager.isSelected)
    //            {
    //                clearSkill();
    //                insistSkill();
    //                GameManager.selected = gameObject;
    //                GameManager.agent = GetComponent<NavMeshAgent>();
    //                GameManager.ShowMoveRange();
    //                Debug.Log("MouseDown");
    //                changeStatus(1);
    //                GameManager.isSelected = true;
    //            }
    //            break;
    //        //选中状态时，不可操作。
    //        case 1:
    //            GameManager.CloseMoveRange();
    //            GameManager.personui.SetActive(true);
    //            break;
    //        //被攻击状态,被攻击。
    //        case 2:
    //            underAttack();
    //            break;
    //        //结束状态时，不可操作。
    //        case 3:

    //            break;
    //        case 4:
    //            GameManager.onClickStaff = gameObject;
    //            GameManager.skill();
    //            break;    
    //    }

    //}
    //初始化角色数据
    public override void atrribteset()
    {
        atk=10;
        a = 20;
       hpmax=20;
       hp=hpmax;
       magicatk=10;
       staffName = "程序员";
    }

    //显示技能信息

    //为技能槽安装技能
    public override void skillset()
    {
        clearSkill();
        insistSkill("回复",huifu);
        insistSkill("强化", QiangHua);
        insistSkill("冲击", chongji);
        insistSkill("散射", sanshe);
    }
 

    //public void insistSkill()
    //{
    //    Button skill1 = Instantiate(prefab);
    //    skill1.transform.parent = staffSkill.transform;
    //    Text skill1Text = skill1.transform.GetComponentInChildren<Text>();
    //    skill1Text.text = "回复";
    //    skill1.onClick.AddListener(huifu);
    //}
    //技能槽安装技能的方法
    //public void insistSkill(string skillName,Action skillFf)
    //{
    //    Button skill1 = Instantiate(prefab);
    //    skill1.transform.parent = staffSkill.transform;
    //    Text skill1Text = skill1.transform.GetComponentInChildren<Text>();
    //    skill1Text.text = skillName;
    //    //skill1.onClick.AddListener(skillFf);
    //    skill1.onClick.AddListener(() => { skillFf(); });
    //}
    //技能散射
    public void sanshe()
    {
        GameManager.ShowAttackRange(117);
        GameManager.skill = skillku.sanshe;
        //mouseOver = skillku.UnAttackRange;
        skillku.skillRange = 80;
        GameManager.showUnAttackRange = GameManager.GeneralAttackRange;
    }
    //技能冲击
    public void chongji()
    {
        GameManager.ShowAttackRange(80);
        GameManager.skill = skillku.chongji;
        skillku.skillRange = 1;
        GameManager.showUnAttackRange = GameManager.GeneralAttackRange;
    }
    //技能回复
    public void huifu()
    {
        GameManager.ShowSkillRange(80);
        GameManager.skill = skillku.huifu;
        skillku.skillRange = 1;
        GameManager.showUnAttackRange = GameManager.GeneralAttackRange;
    }
    //技能重击
    public void zhongji()
    {
        GameManager.ShowAttackRange(80);
        GameManager.skill = skillku.zhongji;
        skillku.skillRange = 1;
        GameManager.showUnAttackRange = GameManager.GeneralAttackRange;
    }

    public void ChuanCi()
    {
        GameManager.ShowAttackRange(40);
        GameManager.skill = skillku.ChuanCi;
        skillku.skillRange = 80;
        GameManager.showUnAttackRange = skillku.ChuanCiRange;
    }

    public void QiangHua()
    {
        GameManager.ShowSkillRange(80);
        GameManager.skill = BuffKu.Qianghua;
        skillku.skillRange = 1;
        GameManager.showUnAttackRange = GameManager.GeneralAttackRange;

    }

}
