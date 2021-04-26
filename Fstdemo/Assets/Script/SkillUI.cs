using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillUI : MonoBehaviour
{
    public Button prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void insistSkill()
    {
        Button skill1 = Instantiate(prefab);
        skill1.transform.parent = gameObject.transform;
        Text skill1Text = skill1.transform.GetComponentInChildren<Text>();
        skill1Text.text = "冲锋";
        skill1.onClick.AddListener(skill111);
    }

    public void skill111()
    {
        Debug.Log("skill111");
    }
}
