using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffBuffs : MonoBehaviour
{
    private Staff staff;
   public GameObject BuffPanle;
    private StaffHeadUI StaffUi;
    List<BUffData> buffs = new List<BUffData>();
    // Start is called before the first frame update
    void Start()
    {
       staff = gameObject.GetComponent<Staff>();
       StaffUi = staff.staffHead.GetComponent<StaffHeadUI>();
 

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void insistBuff(BUffData buff)
    {
        switch (buff.BuffOverlap)
        {
            case BuffOverlap.StackedLayer:
                {
                    foreach (var HasBuff in buffs)
                    {
                        if (HasBuff.BuffId == buff.BuffId)
                        {
                            HasBuff.BuffCurrentRound = HasBuff.BuffMaxRound;
                            break;
                        }
                    }
                    StartBuff(buff);
                    break;
                }

        }


    }
        private void StartBuff(BUffData buff)
        {
            switch (buff.buffType)
            {
                case BuffType.AddAtk:
                {
                    buff.ExNum = staff.atk;
                    buff.BuffCurrentRound = buff.BuffMaxRound;
                    staff.atk = (int)(staff.atk * buff.Num);
                    buffs.Add(buff);
                    StaffUi.AddBuff(buff);
                    break;
                }

            }
        }
        public void EndBuff(int buffId)
        {
        Debug.Log("addatk");
        foreach (var buff in buffs)
            {
            if (buff.BuffId == buffId)
            {
               
                switch (buff.buffType)
                {
                    case BuffType.AddAtk:
                        {

                            staff.atk = buff.ExNum;
                            break;
                        }

                }
                buffs.Remove(buff);//
            }
            }
        }

        public void TikBuff()
        {
   
            foreach (var buff in buffs)
            {
                buff.BuffCurrentRound -= 1;
                if (buff.BuffCurrentRound == 0)
                {
                Debug.Log("tikbuff");
                EndBuff(buff.BuffId);
                }
            }
        }
    }

