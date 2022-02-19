using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPopulation : MonoBehaviour
{
    public TextMeshProUGUI unitNameText;
    public TextMeshProUGUI unitLevel;
    public TextMeshProUGUI unitClass;
    public TextMeshProUGUI unitAttack;
    public TextMeshProUGUI unitDefense;
    public TextMeshProUGUI unitHealth;
    public GameObject unitInfoPanel;
    public GridMovement gridMovement;
    public UnitInfo selectedObject;

    // Start is called before the first frame update
    void Start()
    {

        gridMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<GridMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gridMovement.selected == "player")
        {
            selectedObject = gridMovement.selectedUnit.GetComponent<UnitInfo>();

            unitInfoPanel.SetActive(true);
            
            if (gridMovement.selectedUnit.transform.position.x > 0)
            {
                unitInfoPanel.GetComponent<RectTransform>().localPosition = new Vector3(gridMovement.hit.point.x + gridMovement.selectedUnit.transform.position.x * 400, gridMovement.hit.point.y, gridMovement.hit.point.z);
            }
            else if (gridMovement.selectedUnit.transform.position.x == 0)
            {
                unitInfoPanel.GetComponent<RectTransform>().localPosition = new Vector3(gridMovement.hit.point.x + 400, gridMovement.hit.point.y, gridMovement.hit.point.z);
            }
            else
            {
                unitInfoPanel.GetComponent<RectTransform>().localPosition = new Vector3(gridMovement.hit.point.x + gridMovement.selectedUnit.transform.position.x * 400, gridMovement.hit.point.y, gridMovement.hit.point.z);
            }
            //unitInfoPanel.transform.position = new Vector3(gridMovement.hit.point.x + 100, 0, gridMovement.hit.point.z);

            unitNameText.text = selectedObject.unitName;
            unitLevel.text = selectedObject.unitLevel.ToString();
            unitClass.text = selectedObject.unitClass;
            unitAttack.text = selectedObject.unitAttack.ToString();
            unitDefense.text = selectedObject.unitDefense.ToString();
            unitHealth.text = selectedObject.unitHealth.ToString();
        }
        else if (gridMovement.selected == "enemy")
        {
            selectedObject = gridMovement.selectedEnemy.GetComponent<UnitInfo>();

            unitInfoPanel.SetActive(true);
            //Debug.Log(gridMovement.hit.point);
            if (gridMovement.selectedEnemy.transform.position.x > 0)
            {
                Debug.Log(gridMovement.selectedEnemy.transform.position.x*400);
                unitInfoPanel.GetComponent<RectTransform>().transform.parent.position = new Vector3(gridMovement.hit.point.x + gridMovement.selectedEnemy.transform.position.x * 400, gridMovement.hit.point.y, gridMovement.hit.point.z);
            }
            else if (gridMovement.selectedEnemy.transform.position.x == 0)
            {
                Debug.Log(gridMovement.hit.point.x + gridMovement.selectedEnemy.transform.position.x + 400);
                unitInfoPanel.GetComponent<RectTransform>().transform.parent.position = new Vector3(gridMovement.hit.point.x + gridMovement.selectedEnemy.transform.position.x + 400, gridMovement.hit.point.y, gridMovement.hit.point.z);
            }
            else
            {
                unitInfoPanel.GetComponent<RectTransform>().transform.parent.position = new Vector3(gridMovement.hit.point.x + gridMovement.selectedEnemy.transform.position.x * 400, gridMovement.hit.point.y, gridMovement.hit.point.z);
            }
            unitInfoPanel.transform.position = new Vector3(gridMovement.hit.point.x + 100, 0, gridMovement.hit.point.z);

            unitNameText.text = selectedObject.unitName;
            unitLevel.text = selectedObject.unitLevel.ToString();
            unitClass.text = selectedObject.unitClass;
            unitAttack.text = selectedObject.unitAttack.ToString();
            unitDefense.text = selectedObject.unitDefense.ToString();
            unitHealth.text = selectedObject.unitHealth.ToString();
        }
        else
        {
            unitInfoPanel.gameObject.SetActive(false);
        }
    }
}
