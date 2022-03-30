using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject textPanel;
    public TextMeshProUGUI tutorialText;
    int progress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextSwitch()
    {
        if(progress < 2)
        {
            progress++;
            switch (progress)
            {
                case 1:
                    tutorialText.text = "Nice! Now to attack. To attack simply click an enemy unit.";
                    break;
                default:
                    tutorialText.text = "Now you're ready to finish the battle on your own.";
                    break;
            }
        }
        else
        {
            textPanel.SetActive(false);
        }
        
    }
}
