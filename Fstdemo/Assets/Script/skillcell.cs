using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillcell : MonoBehaviour
{
    private GameObject[] staffs;
    private GameManager GameManager;
    private GameObject staffUnderattack;
    void Start()
    {

    }

    void OnEnable()
    {
        //遍历角色
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        staffs = GameObject.FindGameObjectsWithTag("staff");
        foreach (var staff in staffs)
        {
            //遍历出正上方的队伍不同的角色
            if (Mathf.Abs(Vector3.Distance(staff.transform.position, gameObject.transform.position)) <= 10 && GameManager.GetComponent<GameManager>().turn % 2 != staff.GetComponent<Staff>().party)
            {
                staff.GetComponent<Staff>().changeStatus(4);
                staffUnderattack = staff;
            }
        }
    }

    private void OnDisable()
    {
        staffUnderattack.GetComponent<Staff>().changeStatus(3);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
