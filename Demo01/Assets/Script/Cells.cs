using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells : MonoBehaviour
{
    public bool moveable;
    public GameObject moveCell;
    public GameObject attackCell;

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
       
        Debug.Log("MouseDown");
        Debug.Log(gameObject.name+gameObject.transform.position);
    }
}
