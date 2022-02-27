using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Customization : MonoBehaviour
{
    GameObject currentUnit;
    GameObject lastUnit;
    public List<GameObject> units;
    public List<string> colorOptions;
    public TMP_Dropdown materialDropdown;
    public TMP_Dropdown colorDropdown;
    public Material selectedMaterial;
    public string currentUnitClass;
    UnitInfo currentUnitInfo;


    public TextMeshProUGUI unitNameText;
    public TextMeshProUGUI unitLevel;
    public TextMeshProUGUI unitClass;
    public TextMeshProUGUI unitAttack;
    public TextMeshProUGUI unitDefense;
    //public TextMeshProUGUI unitHealth;
    public TextMeshProUGUI unitSpeed;
    public TextMeshProUGUI unitCrit;
    public TextMeshProUGUI unitDebuffResist;
    public TextMeshProUGUI unitEvasion;
    //public TextMeshProUGUI unitHealthResist;

    TMP_Dropdown.OptionData bodyOption1, bodyOption2;
    TMP_Dropdown.OptionData colorOption1, colorOption2, colorOption3, colorOption4, colorOption5, colorOption6;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            DontDestroyOnLoad(GameObject.FindGameObjectsWithTag("Player")[i]);
            units.Add(GameObject.FindGameObjectsWithTag("Player")[i]);
            
        }

    }
    void Start()
    {
        materialDropdown.ClearOptions();
        colorDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> bodyOptions = new List<TMP_Dropdown.OptionData>();
        bodyOption1 = new TMP_Dropdown.OptionData();
        bodyOption1.text = "Head";
        bodyOptions.Add(bodyOption1);

        bodyOption2 = new TMP_Dropdown.OptionData();
        bodyOption2.text = "Body";
        bodyOptions.Add(bodyOption2);

        foreach (TMP_Dropdown.OptionData option in bodyOptions)
        {
            materialDropdown.options.Add(option);
        }

        List<TMP_Dropdown.OptionData> colorOptions = new List<TMP_Dropdown.OptionData>();
        colorOption1 = new TMP_Dropdown.OptionData();
        colorOption1.text = "Red";
        colorOptions.Add(colorOption1);

        colorOption2 = new TMP_Dropdown.OptionData();
        colorOption2.text = "Purple";
        colorOptions.Add(colorOption2);

        colorOption3 = new TMP_Dropdown.OptionData();
        colorOption3.text = "Blue";
        colorOptions.Add(colorOption3);

        colorOption4 = new TMP_Dropdown.OptionData();
        colorOption4.text = "Cyan";
        colorOptions.Add(colorOption4);

        colorOption5 = new TMP_Dropdown.OptionData();
        colorOption5.text = "Green";
        colorOptions.Add(colorOption5);

        colorOption6 = new TMP_Dropdown.OptionData();
        colorOption6.text = "Yellow";
        colorOptions.Add(colorOption6);

        foreach (TMP_Dropdown.OptionData option in colorOptions)
        {
            colorDropdown.options.Add(option);
        }

        units[0].transform.localPosition = new Vector3((float)0, (float)1, (float).72);
        currentUnit = units[0];
        currentUnitInfo = currentUnit.GetComponent<UnitInfo>();
        selectedMaterial = currentUnit.GetComponent<Renderer>().materials[materialDropdown.value];
        ShowInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextClick()
    {
        lastUnit = currentUnit;
        if (units.Count <= units.IndexOf(lastUnit) + 1)
        {
            currentUnit = units[0];
        }
        else
        {
            currentUnit = units[units.IndexOf(lastUnit) + 1];
        }
        lastUnit.SetActive(false);
        currentUnit.transform.localPosition = new Vector3((float)0, (float)1, (float).72);
        selectedMaterial = currentUnit.GetComponent<Renderer>().materials[0];
        currentUnit.SetActive(true);
        currentUnitInfo = currentUnit.GetComponent<UnitInfo>();
        ShowInfo();
        Debug.Log(currentUnitInfo.unitClass);
    }
    public void PrevClick()
    {
        lastUnit = currentUnit;
        if (units.IndexOf(lastUnit) == 0)
        {
            currentUnit = units[units.Count -1];
        }
        else
        {
            currentUnit = units[units.IndexOf(lastUnit) - 1];
        }
        lastUnit.SetActive(false);
        currentUnit.transform.localPosition = new Vector3((float)0, (float)1, (float).72);
        selectedMaterial = currentUnit.GetComponent<Renderer>().materials[0];
        currentUnitInfo = currentUnit.GetComponent<UnitInfo>();
        ShowInfo();
        currentUnit.SetActive(true);
    }

    public void ChangeMaterial()
    {
        if(materialDropdown.value == 0)
        {
            selectedMaterial = currentUnit.GetComponent<Renderer>().materials[0];
        }
        else
        {
            selectedMaterial = currentUnit.GetComponent<Renderer>().materials[1];
        }
    }
    public void ChangeColor()
    {
        if (colorDropdown.value == 0)
        {
            selectedMaterial.color = new Color(1,0,0,1);
        }
        else if (colorDropdown.value == 1)
        {
            selectedMaterial.color = new Color(.5f,0.5f,1);
        }
        else if (colorDropdown.value == 2)
        {
            selectedMaterial.color = new Color(0,1,0,1);
        }
        else if (colorDropdown.value == 3)
        {
            selectedMaterial.color = new Color(0,.5f,.5f,1);
        }
        else if (colorDropdown.value == 4)
        {
            selectedMaterial.color = new Color(0,0,1,1);
        }
        else
        {
            selectedMaterial.color = new Color(.5f,.5f,0,1);
        }
        
    }

    public void SceneSwitch()
    {
        SceneManager.LoadScene("SampleScene");
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            DontDestroyOnLoad(GameObject.FindGameObjectsWithTag("Player")[i]);
            GameObject.FindGameObjectsWithTag("Player")[i].gameObject.transform.localScale = new Vector3(25,25,25);

        }
        
    }

    public void ShowInfo()
    {
        unitNameText.text = "Name: " + currentUnitInfo.unitName;
        unitLevel.text = "Level: " + currentUnitInfo.unitLevel.ToString();
        unitClass.text = "Class: " + currentUnitInfo.unitClass;
        unitAttack.text = "Attack: " + currentUnitInfo.unitAttack.ToString();
        unitDefense.text = "Defense: " + currentUnitInfo.unitDefense.ToString();
        //unitHealth.text = currentUnitInfo.unitHealth.ToString();
        unitSpeed.text = "Speed: " + currentUnitInfo.unitMovementSpeed.ToString();
        unitCrit.text = "Crit Chance: " + currentUnitInfo.unitCritChance.ToString();
        unitDebuffResist.text = "Debuff Resist.: " + currentUnitInfo.unitDebuffResist.ToString();
        unitEvasion.text = "Evasion: " + currentUnitInfo.unitEvasion.ToString();
    }

    public void ChangingStats()
    {
        if (selectedMaterial.color.r > 0)
        {

        }
    }

}
