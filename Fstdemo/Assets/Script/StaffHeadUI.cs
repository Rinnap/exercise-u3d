using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaffHeadUI : MonoBehaviour
{
    public Text hpUI;
    public Image hpImage;
    public Image staffHead;
    public Image buffIconPrefab;
    public GameObject BuffPanle;
    private List<Image> bufficons = new List<Image>();
    //public Material gary;
    // Start is called before the first frame update
    void Start()
    {
        // hpUI = gameObject.transform.Find("");
        hpUI = gameObject.transform.Find("hptext").GetComponent<Text>();
        hpImage = gameObject.transform.Find("hpbg").GetComponent<Image>();
        staffHead = gameObject.transform.Find("StaffHead/touxiang").GetComponent<Image>();
        BuffPanle = gameObject.transform.Find("BuffPanel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void hpchange(int hp,int hpmax)
    {
        hpImage.fillAmount = (float)hp / (float)hpmax;
        hpUI.text = hp.ToString();
    }

    public void deadGray()
    {
        //Debug.Log("deadgray");
        staffHead.material = Resources.Load<Material>("Materials/imageGray");
        //staffHead.material = gary;
        //Debug.Log("deadgrayiamga");
    }
    public void AddBuff(BUffData buff )
    {
        Image bufficon = Instantiate(buffIconPrefab);
        bufficon.sprite = buff.BuffIcon;
        Text huiheNum = bufficon.GetComponentInChildren<Text>();
        huiheNum.text = buff.BuffMaxRound.ToString();
        bufficon.transform.SetParent(BuffPanle.transform);
        bufficons.Add(bufficon);
    }
    public void RemoveBuff()
    {

    }
}
