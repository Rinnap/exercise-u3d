using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Producer : Staff
{

    public float xOffset;
    public float yOffset;
    public Image staffSkill;
    public Button prefab;

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    void Update()
    {
        //Vector2 player2DPosition = Camera.main.WorldToScreenPoint(GameManager.selected.transform.position);
        //将玩家坐标转化为屏幕
        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        staffSkill.rectTransform.position = player2DPosition + new Vector2(xOffset, yOffset);
        ////血条超出屏幕就不显示
        //if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
        //{
        //    attack.gameObject.SetActive(false);
        //}
        //else
        //{
        //    attack.gameObject.SetActive(true);
        //}
    }


    public void OnMouseDown()
    {
        switch (staffStatus)
        {
            //未选中状态时，当没有角色被选中时即可被选中。
            case 0:
                if (!GameManager.isSelected)
                {
                    clearSkill();
                    insistSkill();
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
                underAttack();
                break;
            //结束状态时，不可操作。
            case 3:
                
                break;
            case 4:
                GameManager.skillselected = gameObject;
                GameManager.skill();
                break;    
        }


    }
    public void showstaffSkillUI()
    {
        staffSkill.enabled=true;
    }

    public void insistSkill()
    {
        Button skill1 = Instantiate(prefab);
        skill1.transform.parent = staffSkill.transform;
        Text skill1Text = skill1.transform.GetComponentInChildren<Text>();
        skill1Text.text = "回复";
        skill1.onClick.AddListener(huifu);
    }

    public void huifu()
    {
        GameManager.ShowSkillRange(80);
        GameManager.skill = sanhua;
    }
    public void sanhua()
    {
        Debug.Log("发动技能2散花");
    }
    public void skill3()
    {
        Debug.Log("发动技能3");
    }

    private void clearSkill()
    {

        for (int i = 0; i < staffSkill.transform.childCount; i++) {  
            Destroy (staffSkill.transform.GetChild (i).gameObject);  
        }  
    }
}
