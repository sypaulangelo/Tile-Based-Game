using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILayout : MonoBehaviour
{
    [SerializeField] GameObject folderInterface;
    [SerializeField] GameObject closeButton;
    [SerializeField] GameObject jerryNPC;
    [SerializeField] GameObject joyNPC;
    [SerializeField] GameObject kylaNPC;
    [SerializeField] GameObject janeNPC;
    [SerializeField] GameObject markNPC;
    public Text GP1Text;
    public Text GP1Activity;
    public Text GP1Output;

    [SerializeField] GameObject trash1;
    [SerializeField] GameObject trash2;
    [SerializeField] GameObject trash3;
    [SerializeField] GameObject trash4;
    [SerializeField] GameObject trash5;
    [SerializeField] GameObject trash6;
    [SerializeField] GameObject trash7;
    [SerializeField] GameObject trash8;
    [SerializeField] GameObject trash9;
    [SerializeField] GameObject trash10;
    public Text GP2Text;
    public Text GP2Activity;
    public Text GP2Output;
    public Text GP3Text;
    public Text GP3Activity;
    public Text GP3Output;
    public Text GP4Text;
    public Text GP4Activity;
    public Text GP4Output;
    bool isQ1Done = false;
    bool isQ2Done = false;
    bool isQ3Done = false;

    void Update () {
        if (!jerryNPC.activeInHierarchy && !joyNPC.activeInHierarchy)
        {
            GP1Text.color = Color.green;
            GP1Activity.color = Color.green;
            GP1Output.color = Color.green;
            isQ1Done = true;
        }

        if (!trash1.activeInHierarchy && !trash2.activeInHierarchy && !trash3.activeInHierarchy && !trash4.activeInHierarchy
            && !trash5.activeInHierarchy && !trash6.activeInHierarchy && !trash7.activeInHierarchy && !trash8.activeInHierarchy
            && !trash9.activeInHierarchy && !trash10.activeInHierarchy) {
            GP2Text.color = Color.green;
            GP2Activity.color = Color.green;
            GP2Output.color = Color.green;
            isQ2Done = true;
        }

        if (isQ1Done && isQ2Done) {
            GP3Text.text = "Greener Pastures II";
            GP3Activity.text = "Look for Kyla and Jane and talk to them";
            GP3Output.text = "Converse with the community to come up with feasible solutions";
        }

        if (!kylaNPC.activeInHierarchy && !janeNPC.activeInHierarchy)
        {
            GP3Text.color = Color.green;
            GP3Activity.color = Color.green;
            GP3Output.color = Color.green;
            markNPC.SetActive(true);
            isQ3Done = true;
        }

        if(isQ3Done) {
            GP4Text.text = "Greener Pastures III";
            GP4Activity.text = "Look for Mark and talk to him";
            GP4Output.text = "Collaborate with fellow SK/KK members and decide on a solution";
        }
        
    }
    public void OpenFolder () {
        folderInterface.SetActive(true);
    }

    public void CloseFolder () {
        folderInterface.SetActive(false);
    }

    public void Test() {
        return;
    }
}
