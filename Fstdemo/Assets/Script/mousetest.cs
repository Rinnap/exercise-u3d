using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousetest : MonoBehaviour
{
    public GameObject[] cells;
    public GameObject selectedCell;

    Vector3 screenPos ;
    Vector3 mousePosOnScreen;
        Vector3 mousePosInWorld ;
    // Start is called before the first frame update
    void Start()
    {
        cells = GameObject.FindGameObjectsWithTag("cell");

    }

    // Update is called once per frame
    void Update()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePosOnScreen = Input.mousePosition;
        mousePosOnScreen.z = screenPos.z;
        mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);
        ShowMoveRange();
    }

       public void ShowMoveRange()
    {
        //遍历格子
        foreach(var cell in cells)
        {
            Debug.Log("获取中");
            if (Mathf.Abs(Vector3.Distance(cell.transform.position, mousePosInWorld)) <= 200)
            {
                Debug.Log("获取到了");
                selectedCell = cell;
                selectedCell.GetComponent<Cells>().moveCell.SetActive(true);
            }
        }
 
     //   selectedCell.GetComponent<Cells>().moveCell.SetActive(false);
    }
}
