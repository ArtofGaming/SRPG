using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMovement : MonoBehaviour
{
    public RaycastHit hit;
    public string selected = "";
    Collider myCollider;
    private float movementReach = 0;
    public bool moved = false;
    public Material movementMaterial;
    public GameObject selectedUnit;
    public GameObject selectedEnemy;
    public bool attackPossible;
    public string unitClass;
    

    //show movement and other actions possible

    // Start is called before the first frame update
    void Start()
    {
        attackPossible = false;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
            if (Physics.Raycast(ray, out hit, 100))
            {
                
                if (hit.collider.gameObject.tag == "Player" && selectedUnit == null)
                {
                    if(selected != "player")
                    {
                        selectedUnit = hit.collider.gameObject;
                        Debug.Log(hit.collider.gameObject);
                        // Calculate the squares that unit can move to
                        movementReach = .15f;
                        // Show area that is movable
                        selectedUnit.transform.GetChild(0).localScale = new Vector3((float)movementReach, (float).002, (float)movementReach);
                        myCollider = hit.collider.gameObject.GetComponentInChildren<MeshCollider>();
                        myCollider.gameObject.GetComponentInChildren<Renderer>().material = movementMaterial;
                        selectedUnit = hit.collider.gameObject;
                        selected = "player";
                    }

                }
                else
                {
                    Debug.Log("Yes");
                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        Debug.Log("Clicked");
                        Debug.Log(hit.point);
                        // if point selected is in allowed range and unit has not moved yet
                        if (hit.collider.GetComponent<MeshCollider>() != null && !moved )
                        {
                            //me.transform.position = lastPosition;

                            //.1 is to maintain the unit's height value
                            selectedUnit.transform.position = new Vector3(hit.point.x, (float).1, hit.point.z);
                            selectedUnit.GetComponentInChildren<MeshCollider>().material = null;
                            selectedUnit.GetComponent<GridMovement>().moved = true;
                            
                            

                        }

                    }
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        selected = "enemy";
                        //OnTriggerEnter(hit.collider);
                        selectedEnemy = hit.collider.gameObject;
                        attackPossible = true;

                    }

                }
                
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERED");
        Debug.Log(other);
        
        
    }

}
