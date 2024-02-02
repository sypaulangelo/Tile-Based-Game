using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] string name;
    public string Name {
        get {return name;}
    }

    [TextArea(1, 5)]
    [SerializeField] List<string> lines;

    public List<string> Lines {
        get { return lines; }
    }
}
