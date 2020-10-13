using System.Collections.Generic;
using UnityEngine.UI;

public class WheelHighlightDisplayMode : IDisplayMode
{
    public List<WheelPart> WheelParts;
    public List<Text> NoteNumbers;
    public List<Text> NoteLabels;
    public Text KeyOfText;

    public string DisplayName
    {
        get
        {
            return "Key Highlight";
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

        SetKeyIndex(9);
    }

    public void SetKeyIndex(WheelPart key)
    {
        SetKeyIndex(WheelParts.IndexOf(key));
    }

    private void SetKeyIndex(int index)
    {
        int currentIndex = index;
        int currentNoteIndex = 0;
        for (int i = 0, count = WheelParts.Count; i < count; ++i)
        {
            bool isActive = Constants.ACTIVE_INDICES.Contains(i);
            WheelPart currentWheelpart = WheelParts[currentIndex];
            currentWheelpart.SetIsKey(i == 0);
            currentWheelpart.SetActive(isActive);

            Text currentNoteLabel = NoteLabels[i];
            currentNoteLabel.text = Constants.NoteIntAssociations[index][i];

            Text currentNoteNumber = NoteNumbers[currentIndex];
            currentNoteNumber.text = string.Empty;
            if (isActive)
            {
                if (Constants.NOTE_NUMBERS[currentNoteIndex] != null)
                {
                    currentNoteNumber.text = Constants.NOTE_NUMBERS[currentNoteIndex];
                }
                ++currentNoteIndex;
            }

            currentIndex = currentIndex + 1 >= count ? 0 : currentIndex + 1;
        }
        KeyOfText.text = WheelParts[index].Key;
    }
}
