using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> aliveUnits;
    public List <GameObject> aliveEnemyUnits;
    GridMovement gridMovement;
    GameObject attackingUnit;
    GameObject attackingEnemyUnit;
    public Button attackButton;
    public Button startButton;
    UnitInfo attackingUnitInfo;
    UnitInfo attackingEnemyInfo;
    InfoPopulation infoPopulation;
    public string whoseTurn = "none";

    //have units deselect at the end of turn
    //control health gain/loss
    //control win/loss condition
    //control death
    // Start is called before the first frame update
    void Start()
    {
        gridMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<GridMovement>();
        infoPopulation = GameObject.Find("god").GetComponent<InfoPopulation>();

        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Player"))
        {
            aliveUnits.Add(unit);
        }
        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            
            aliveEnemyUnits.Add(unit);

        }

        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gridMovement.attackPossible == true)
        {
            attackButton.gameObject.SetActive(true);
            //Attack Calculation
           if (attackingUnit != null)
            {
                attackButton.gameObject.SetActive(false);
            } 
        }
        if (aliveUnits.Count <= 0)
        {
            Debug.Log("You Lose");
        }
        if(aliveEnemyUnits.Count <= 0)
        {
            Debug.Log("You Win!");
        }
        
    }
    public void Attack()
    {
        attackingUnit = gridMovement.selectedUnit;
        attackingEnemyUnit = gridMovement.selectedEnemy;
        attackingEnemyInfo = attackingEnemyUnit.GetComponent<UnitInfo>();
        attackingUnitInfo = attackingUnit.GetComponent<UnitInfo>();

        Debug.Log("Attacking " + attackingEnemyUnit.name);

        attackingEnemyInfo.unitHealth -= attackingUnitInfo.unitAttack;

        Debug.Log(attackingEnemyInfo.unitHealth);

        if (attackingEnemyInfo.unitHealth <= 0)
        {
            gridMovement.selected = "none";
            aliveEnemyUnits.Remove(attackingEnemyUnit);
            Destroy(attackingEnemyUnit);
        }
        else
        {
            //Counterattack
            attackingUnitInfo.unitHealth -= attackingEnemyInfo.unitAttack;
            Debug.Log(attackingUnitInfo.unitHealth);
            if (attackingUnitInfo.unitHealth <= 0)
            {
                aliveUnits.Remove(attackingUnit);
                Destroy(attackingUnit);
            }
        }
        gridMovement.selectedUnit.transform.GetChild(0).gameObject.SetActive(false);
        //gridMovement.selectedUnit.GetComponent<GridMovement>().moved = true;
        gridMovement.selectedUnit = null;
        gridMovement.selectedEnemy = null;
        
    }
}
