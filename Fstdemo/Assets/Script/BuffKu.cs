using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffKu : MonoBehaviour
{

    //private static BuffKu _instance;
    //public static BuffKu Instance
    //{
    //  get { return _instance; }
    //}
    public GameManager GameManager;
    public List<BUffData> buffBase = new List<BUffData>();

    void Start()
    {
        GameManager = gameObject.GetComponent<GameManager>();
    }
    public void Qianghua()
    {
        //BUffData qianghua = new BUffData();
        //qianghua.BuffId = 1;
        //qianghua.BuffMaxRound = 5;
        //qianghua.Num = 1.5f;
        //qianghua.buffType = BuffType.AddAtk;
        foreach (var buff in buffBase)
        {
            if (buff.BuffId == 1)
            {
                GameManager.onClickStaff.GetComponent<StaffBuffs>().insistBuff(buff);
                GameManager.tishi(GameManager.onClickStaff + "攻击力收到强化，持续5回合");
                GameManager.staffEnd();
            }
        }

    }
    //public BUffData GetBUff(int buffid)
    //{
    //    foreach (var buff in buffBase)
    //    {
    //        if (buff.BuffId == buffid)
    //        {
    //            return buff;
    //        }
         
    //    }
    //        return null;
    //}
}
