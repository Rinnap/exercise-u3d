using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    public bool moveable;
    public GameObject moveCell;
    public GameObject attackCell;
    public GameObject skillCell;
    public GameObject staffOnCell;
    private GameObject[] staffs;
    private GameManager GameManager;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        staffs = GameObject.FindGameObjectsWithTag("staff");
    
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var staff in staffs)
        {
            //遍历出正上方的队伍不同的角色
            if (Mathf.Abs(Vector3.Distance(staff.transform.position, gameObject.transform.position)) <= 10)
            {
                staffOnCell = staff;
                staff.GetComponent<Staff>().OnCell = gameObject;
            }
        }
    }
    //private void OnMouseDown()
    //{
       
    //    Debug.Log("MouseDown");
    //    Debug.Log(gameObject.name+gameObject.transform.position);
    //}
}
