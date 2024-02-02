using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] Text dialogueText;
    [SerializeField] GameObject nameBox;
    [SerializeField] Text nameText;
    [SerializeField] GameObject folderButton;
    [SerializeField] GameObject mariaNPC;
    [SerializeField] GameObject joeyNPC;
    [SerializeField] GameObject jerryNPC;
    [SerializeField] GameObject joyNPC;
    [SerializeField] GameObject janeNPC;
    [SerializeField] GameObject kylaNPC;
    [SerializeField] GameObject markNPC;

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
    [SerializeField] GameObject choiceA;
    public TMP_Text choiceAText;
    [SerializeField] GameObject choiceB;
    public TMP_Text choiceBText;
    [SerializeField] GameObject choiceC;
    public TMP_Text choiceCText;
    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialogue;
    public event Action OnHideDialogue;
    public static DialogueManager Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    Dialogue dialogue;
    int currentLine = 0;
    bool isTyping;

    public IEnumerator ShowDialogue(Dialogue dialogue) { // display dialogue UI
        yield return new WaitForEndOfFrame();
        OnShowDialogue?.Invoke();
        this.dialogue = dialogue;
        nameBox.SetActive(true);
        nameText.text = dialogue.Name;
        dialogueBox.SetActive(true);
        StartCoroutine(TypeDialogue(dialogue.Lines[0]));
    }

    public void HandleUpdate() {    // cycle through each line 
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping) {
            ++currentLine;
            if (currentLine < dialogue.Lines.Count) {
                StartCoroutine(TypeDialogue(dialogue.Lines[currentLine]));
                if (dialogue.Name == "Mark" && currentLine == 1) {
                    choiceA.SetActive(true);
                    choiceB.SetActive(true);
                    choiceC.SetActive(true);
                } else if (dialogue.Name == "Mark" && currentLine == 3) {
                    choiceA.SetActive(true);
                    choiceB.SetActive(true);
                    choiceC.SetActive(true);
                } else if (dialogue.Name == "Mark" && currentLine == 4) {
                    choiceA.SetActive(true);
                    choiceB.SetActive(true);
                    choiceC.SetActive(true);
                }
            } else {
                dialogueBox.SetActive(false);
                nameBox.SetActive(false);
                currentLine = 0;
                OnHideDialogue?.Invoke();

                // check if first dialogue iteration with Joey is done and unlock UI items
                // turn this into a switch case in the future
                if (dialogue.Name == "Joey") {
                    folderButton.SetActive(true);
                    jerryNPC.SetActive(true);
                    joeyNPC.SetActive(false);
                } else if (dialogue.Name == "Maria") {
                    mariaNPC.SetActive(false);
                    joeyNPC.SetActive(true);
                } else if (dialogue.Name == "Jerry") {
                    jerryNPC.SetActive(false);
                } else if (dialogue.Name == "Joy") {
                    joyNPC.SetActive(false);
                } else if (dialogue.Name == "Jane") {
                    janeNPC.SetActive(false);
                } else if (dialogue.Name == "Kyla") {
                    kylaNPC.SetActive(false);
                } else if (dialogue.Name == "Mark") {
                    markNPC.SetActive(false);
                }

                if (!kylaNPC.activeInHierarchy && !janeNPC.activeInHierarchy) {
                    markNPC.SetActive(true);
                }

                if(dialogue.Name == "Trash1") {
                    trash1.SetActive(false);
                } else if (dialogue.Name == "Trash2") {
                    trash2.SetActive(false);
                } else if (dialogue.Name == "Trash3") {
                    trash3.SetActive(false);
                } else if (dialogue.Name == "Trash4") {
                    trash4.SetActive(false);
                } else if (dialogue.Name == "Trash5") {
                    trash5.SetActive(false);
                } else if (dialogue.Name == "Trash6") {
                    trash6.SetActive(false);
                } else if (dialogue.Name == "Trash7") {
                    trash7.SetActive(false);
                } else if (dialogue.Name == "Trash8") {
                    trash8.SetActive(false);
                } else if (dialogue.Name == "Trash9") {
                    trash9.SetActive(false);
                } else if (dialogue.Name == "Trash10") {
                    trash10.SetActive(false);
                }
            }
        }
    }

    public IEnumerator TypeDialogue(string line) { // cycle through each letter in the line
        isTyping = true;
        dialogueText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }

    public void userPickA () {
        if (dialogue.Name == "Mark" && currentLine == 1) {
            dialogueText.text = "That might require more resources than we are currently working with. Lets try looking into other solutions for now.";
        } else if (dialogue.Name == "Mark" && currentLine == 3) {
            dialogueText.text = "That’s great and all, but maybe there’s an easier way we can provide this information to all the residents and not just students.";
        } else if (dialogue.Name == "Mark" && currentLine == 4) {
            dialogueText.text = "Maybe this isn’t the best use of our resources and manpower. Let’s try looking into other solutions";
        }
    }
    public void userPickB () {
        if (dialogue.Name == "Mark" && currentLine == 1) {
            dialogueText.text = "That might help for now, but in the long-run the trashmight still end up piling up again. Lets try looking into other solutions that can be more long-term";
        } else if (dialogue.Name == "Mark" && currentLine == 3) {
            choiceA.SetActive(false);
            choiceB.SetActive(false);
            choiceC.SetActive(false);
            dialogueText.text = "That sounds like a great idea! It won’t require too much time and resources, plus it’ll help everyone understand why proper waste management is important";
            choiceAText.text = "Have different residents handle transporting them to different scrap yards in the city";
            choiceBText.text = "Coordinate with different junk shops in the area, the city might not have a dedicated recycling plant, but some junk shops are able to get them to the proper people and places";
            choiceCText.text = "The garbage collectors can just take all of the collected waste and bring it to the dump sites";
        } else if (dialogue.Name == "Mark" && currentLine == 4) {
            choiceA.SetActive(false);
            choiceB.SetActive(false);
            choiceC.SetActive(false);
            dialogueText.text = "That sounds like a good idea! I heard that different organizations that upcycle plastics often work with junk shops in collecting upcycle-grade plastics.";
        }
    }
    public void userPickC () {
        if (dialogue.Name == "Mark" && currentLine == 1) {
            choiceA.SetActive(false);
            choiceB.SetActive(false);
            choiceC.SetActive(false);
            dialogueText.text = "That sounds like a great idea! It’s something everyone can do, and maybe we could even set-up a community compost-pit in the process.";
            choiceAText.text = "Ask the schools in the barangay to add these lessons to their classes";
            choiceBText.text = "Create pamphlets and posters that we can hand out detailing why waste management and recycling is important";
            choiceCText.text = "Go house-to-house to explain to the residents in person how to do proper waste management";
        } else if (dialogue.Name == "Mark" && currentLine == 3) {
            dialogueText.text = "It would be nice to be able to really get into the details of it with every household, but that would take us months to do. Maybe there’s a more efficient way we could do this";
        } else if (dialogue.Name == "Mark" && currentLine == 4) {
            dialogueText.text = "There’s that, but then it would waste the effort of segregating the waste. The city dump doesn’t have the facilities to properly sort out recyclables, so it would be a waste. Let’s see if there are other ways we can address this.";
        }
    }
}
