using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int moveRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //获取移动路径
    public void GetMovePath(System.Action<Path>OnPathSerchOkCallBack)
        {
        var moveGScore = this.moveRange * 1000 * 3;

        var SerchPath = MoveRangConStantPath.Construct(this.transform.position, moveGScore, false,
            (Path path =>
            {
                path.path = (path as MoveRangConstantPath).allNodes;
                OnPathSerch0kCallBack.Invoke(path);
            }
        );
        AstarPath.StartPath(SerchPath, true);
    }

}
