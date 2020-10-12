using System.Collections.Generic;
using UnityEngine.UI;

public class NoteRotateDisplayMode : IDisplayMode
{
    private readonly List<string> NOTE_LABELS_SHARP = new List<string>(
        new string[] { "G#", "A", "A#", "B", "C", "C#", "D", "D#",
                        "E", "F", "F#", "G" });

    private readonly List<string> NOTE_LABELS_FLAT = new List<string>(
        new string[] { "Ab", "A", "Bb", "B", "C", "Db", "D", "Eb",
                        "E", "F", "Gb", "G" });

    private Dictionary<string, List<string>> noteAssociations = 
        new Dictionary<string, List<string>>();

    private List<string> previousNoteAssociations;

    private readonly List<int> ACTIVE_INDICES =
        new List<int>(new int[] { 0, 2, 4, 5, 7, 9, 11 });

    private readonly List<string> NOTE_NUMBERS = new List<string>(
        new string[] { "1", "9", "3", "11", "5", "13", "7" });

    public List<WheelPart> WheelParts;
    public List<Text> NoteNumbers;
    public List<Text> NoteLabels;
    public Text KeyOfText;

    public string DisplayName
    {
        get
        {
            return "Note Rotation";
        }
    }

    public void Initialize(
        List<WheelPart> wheelParts,
        List<Text> noteNumbers,
        List<Text> noteLabels,
        Text keyOfText)
    {
        WheelParts = wheelParts;
        NoteNumbers = noteNumbers;
        NoteLabels = noteLabels;
        KeyOfText = keyOfText;

        noteAssociations.Add("Ab", NOTE_LABELS_FLAT);   // Ab
        noteAssociations.Add("G#", NOTE_LABELS_FLAT);
        noteAssociations.Add("A", NOTE_LABELS_SHARP);  // A
        noteAssociations.Add("Bb", NOTE_LABELS_FLAT);   // Bb
        noteAssociations.Add("A#", NOTE_LABELS_FLAT);
        noteAssociations.Add("B", NOTE_LABELS_SHARP);  // B
        noteAssociations.Add("C", NOTE_LABELS_SHARP);  // C
        noteAssociations.Add("Db", NOTE_LABELS_FLAT);   // Db
        noteAssociations.Add("C#", NOTE_LABELS_FLAT);
        noteAssociations.Add("D", NOTE_LABELS_SHARP);  // D
        noteAssociations.Add("Eb", NOTE_LABELS_FLAT);   // Eb
        noteAssociations.Add("D#", NOTE_LABELS_FLAT);
        noteAssociations.Add("E", NOTE_LABELS_SHARP);  // E
        noteAssociations.Add("F", NOTE_LABELS_FLAT);   // F
        noteAssociations.Add("F#", NOTE_LABELS_SHARP);  // F#
        noteAssociations.Add("Gb", NOTE_LABELS_SHARP);
        noteAssociations.Add("G", NOTE_LABELS_SHARP);  // G

        SetInitialState();
    }

    private void SetInitialState()
    {
        int index = 0;
        int currentIndex = index;
        int currentNoteIndex = 0;
        for (int i = 0, count = WheelParts.Count; i < count; ++i)
        {
            bool isActive = ACTIVE_INDICES.Contains(i);
            WheelPart currentWheelpart = WheelParts[i];
            currentWheelpart.SetIsKey(i == 0);
            currentWheelpart.SetActive(isActive);

            Text currentNoteLabel = NoteLabels[i];
            previousNoteAssociations = noteAssociations["Ab"];
            currentNoteLabel.text = noteAssociations["Ab"][i];

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
        KeyOfText.text = WheelParts[0].Key;
    }

    public void SetKeyIndex(WheelPart key)
    {
        List<string> noteNames = noteAssociations[key.Key];
        int startIndex = previousNoteAssociations.IndexOf(key.Key);
        int currentIndex = startIndex;
        for (int i = 0, count = WheelParts.Count; i < count; ++i)
        {
            WheelPart part = WheelParts[i];
            part.SetNoteLabel(noteNames[currentIndex]);
            currentIndex = currentIndex >= noteNames.Count - 1 ? 0 : currentIndex + 1;
        }
        previousNoteAssociations = noteNames;
        KeyOfText.text = WheelParts[0].Key;
    }
}
