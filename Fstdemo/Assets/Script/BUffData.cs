using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class BUffData 
{
    //buffid
    public string buffName;
    public int BuffId;
    public int MaxLimit = 0;
    public float Num; //buff数值
    public int ExNum;
    public BuffType buffType;
    public BuffOverlap BuffOverlap = BuffOverlap.StackedLayer;
    public Sprite BuffIcon;
    public int BuffMaxRound;
    public int BuffCurrentRound;



    public void Creat()
    {

    }

    public void AddRound()
    {

    }
}

//buff类型
public enum  BuffType
{
    AddAtk,
    AddDef,
    AddHp,
    SubHp,
    AddVertigo,
}
//buff效果
public enum BuffOverlap
{
    StackedLayer,
    None,
}


