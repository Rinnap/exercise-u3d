using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillku : MonoBehaviour
{
    public GameManager GameManager;
    public Staff onAttackstaff;
    public Staff attackstaff;

    void Start()
    {
        GameManager = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void test()
    {
        Debug.Log("技能库测试");
    }

    public void huifu()
    {
        GameManager.onClickStaff.GetComponent<Staff>().hpChange(GameManager.selected.GetComponent<Staff>().magicatk);
        Debug.Log(GameManager.onClickStaff + "收到10点治疗");
        GameManager.staffEnd();
    }

    public void zhongji()
    {
        int hpchange = -(int)(GameManager.selected.GetComponent<Staff>().atk * 1.5);
        GameManager.onClickStaff.GetComponent<Staff>().hpChange(hpchange);
        Debug.Log(GameManager.onClickStaff + "收到"+hpchange+"伤害");
        GameManager.staffEnd();
    }
}
