using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaffHeadUI : MonoBehaviour
{
    public Text hpUI;
    public Image hpImage;
    public Image staffHead;
    //public Material gary;
    // Start is called before the first frame update
    void Start()
    {
       // hpUI = gameObject.transform.Find("");
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
        Debug.Log("deadgray");
        staffHead.material = Resources.Load<Material>("Materials/imageGray");
        //staffHead.material = gary;
        Debug.Log("deadgrayiamga");
    }

}
