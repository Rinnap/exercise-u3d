using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class follow : MonoBehaviour
{
    public float xOffset;
    public float yOffset;
    public Image attack;
    public Image skill;
    public Image stay;
    public Image staffskill;
    public float xskillOffset;
    public float yskillOffset;

    private GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(GameManager.selected. transform.position);
        attack.rectTransform.position = player2DPosition + new Vector2(xOffset, yOffset);
        skill.rectTransform.position = player2DPosition + new Vector2(xOffset, yOffset-60);
        stay.rectTransform.position = player2DPosition + new Vector2(-xOffset, yOffset);
        staffskill.rectTransform.position = player2DPosition + new Vector2(xskillOffset, yskillOffset);

        ////血条超出屏幕就不显示
        //if (player2DPosition.x > Screen.width || player2DPosition.x < 0 || player2DPosition.y > Screen.height || player2DPosition.y < 0)
        //{
        //    attack.gameObject.SetActive(false);
        //}
        //else
        //{
        //    attack.gameObject.SetActive(true);
        //}
    }

    public void showSkillUI()
    {
        //gameObject.SetActive(false);
    }
}
