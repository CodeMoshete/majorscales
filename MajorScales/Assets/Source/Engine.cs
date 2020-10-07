using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    private readonly List<string> NOTE_LABELS_SHARP = new List<string>(
        new string[] { "G#", "A", "A#", "B", "C", "C#", "D", "D#",
                        "E", "F", "F#", "G" });

    private readonly List<string> NOTE_LABELS_FLAT = new List<string>(
        new string[] { "Ab", "A", "Bb", "B", "C", "Db", "D", "Eb",
                        "E", "F", "Gb", "G" });

    private List<List<string>> noteAssociations = new List<List<string>>();

    private readonly List<int> ACTIVE_INDICES = 
        new List<int>(new int[] { 0, 2, 4, 5, 7, 9, 11 });

    private readonly List<string> NOTE_NUMBERS = new List<string>(
        new string[] { "1", "9", "3", "11", "5", "13", "7" });

    public List<WheelPart> WheelParts;
    public List<Text> NoteNumbers;
    public List<Text> NoteLabels;
    public Text KeyOfText;

    private void Start()
    {
        noteAssociations.Add(NOTE_LABELS_FLAT);   // Ab
        noteAssociations.Add(NOTE_LABELS_SHARP);  // A
        noteAssociations.Add(NOTE_LABELS_FLAT);   // Bb
        noteAssociations.Add(NOTE_LABELS_SHARP);  // B
        noteAssociations.Add(NOTE_LABELS_SHARP);  // C
        noteAssociations.Add(NOTE_LABELS_FLAT);   // Db
        noteAssociations.Add(NOTE_LABELS_SHARP);  // D
        noteAssociations.Add(NOTE_LABELS_FLAT);   // Eb
        noteAssociations.Add(NOTE_LABELS_SHARP);  // E
        noteAssociations.Add(NOTE_LABELS_FLAT);   // F
        noteAssociations.Add(NOTE_LABELS_SHARP);  // F#
        noteAssociations.Add(NOTE_LABELS_SHARP);  // G

        SetKeyIndex(9);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SetKeyIndex(WheelPart key)
    {
        SetKeyIndex(WheelParts.IndexOf(key));
    }

    private void SetKeyIndex(int index)
    {
        KeyOfText.text = WheelParts[index].Key;
        int currentIndex = index;
        int currentNoteIndex = 0;
        for (int i = 0, count = WheelParts.Count; i < count; ++i)
        {
            bool isActive = ACTIVE_INDICES.Contains(i);
            WheelPart currentWheelpart = WheelParts[currentIndex];
            currentWheelpart.SetIsKey(i == 0);
            currentWheelpart.SetActive(isActive);

            Text currentNoteLabel = NoteLabels[i];
            currentNoteLabel.text = noteAssociations[index][i];

            Text currentNoteNumber = NoteNumbers[currentIndex];
            currentNoteNumber.text = string.Empty;
            if (isActive)
            {
                if (NOTE_NUMBERS[currentNoteIndex] != null)
                {
                    currentNoteNumber.text = NOTE_NUMBERS[currentNoteIndex];
                }
                ++currentNoteIndex;
            }

            currentIndex = currentIndex + 1 >= count ? 0 : currentIndex + 1;
        }
    }
}
