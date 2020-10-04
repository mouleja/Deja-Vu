using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;
using UnityEngine.Events;

public class GameCode : MonoBehaviour
{
    // Object references
    [SerializeField] SpriteRenderer[] doors;
    [SerializeField] SpriteRenderer[] items;
    [SerializeField] TextMeshProUGUI[] textLines;
    [SerializeField] TMP_InputField inputLine;

    List<List<int>> levels = new List<List<int>>();
    List<List<int>> levelItems = new List<List<int>>();
    string[] newRoomStrings = {"This room doesn't look familiar.", "I don't think I've been here before.", 
            "Is this new?", "I think I'm making progress!"};
    string[] pastRoomStings = {"This room deifnitely seems familiar.", "Uh oh.  I've been here before.",
            "This has all happened before.", "Here we go again!"};

    // Original HIRES colors for Apple IIc
    Color green = new Color32(32, 192, 0, 255);
    Color purple = new Color32(160, 0, 255, 255);
    Color orange = new Color32(240, 80, 0, 255);
    Color blue = new Color32(0, 128, 255, 255);
    Color[] colors;

    int highestLevel = 0;
    int currentLevel = 0;

    private void Awake() {
        inputLine.onSubmit.AddListener(HandleInput);
    }

    // Start is called before the first frame update
    void Start()
    {
        colors = new Color[] { green, purple, orange, blue };
        MakeNewLevel();
        reColorRoom(0);
        textLines[1].text = "Nothing to do but try one of the doors.";
        inputLine.ActivateInputField();
        //inputLine.Select();
    }

    private void reColorRoom(int level)
    {
        for (int i = 0; i < levels[level].Count; i++)
        {
            doors[i].color = colors[levels[level][i]];
            items[i].color = colors[levelItems[level][i]];
        }
    }

    private void MakeNewLevel()
    {
        List<int> newLevel = new List<int>();

        bool unique = false;
        while (!unique)
        {
            newLevel.Add(Random.Range(0, 4));
            while (newLevel.Count < 4)
            {
                int nextInt = Random.Range(0, 4);
                if (!newLevel.Contains(nextInt))
                {
                    newLevel.Add(nextInt);
                }
            }
            unique = !levels.Contains(newLevel);
        }
        levels.Add(newLevel);

        var itemColors = new List<int>() { Random.Range(0, 4) };
        while (itemColors.Count < 4)
        {
            int nextInt = Random.Range(0, 4);
            if (!itemColors.Contains(nextInt))
            {
                itemColors.Add(nextInt);
            }
        }
        levelItems.Add(itemColors);
    }

    void HandleInput(string input)
    {

    }


}
