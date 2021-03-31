using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Staff : MonoBehaviour
{
    public int moveRange=10;
    public int attackRange;
   // public NavMeshAgent agent;
   

    private GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        GameManager.selected = gameObject;
        GameManager.agent = GetComponent<NavMeshAgent>();
        GameManager.ShowMoveRange();
        Debug.Log("MouseDown");
    }

    public void ShowAttackRange()
    {
       
    }


    //移动测试代码
    //public void move()
    //{   //if(Input.GetMouseButtonDown(0)){
  
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if(Physics.Raycast(ray,out hit))
    //    {
    //        agent.SetDestination(hit.point);
    //    }}
    //}

}
