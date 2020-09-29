using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    private readonly List<int> ACTIVE_INDICES = 
        new List<int>(new int[] { 0, 2, 4, 5, 7, 9, 11 });


    private readonly List<string> NOTE_LABELS = new List<string>(
        new string[] { "1", "9", "3", null, "5", null, "7" });

    public List<WheelPart> WheelParts;
    public List<Text> NoteLabels;
    public Text KeyOfText;

    private void Start()
    {
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

            Text currentNoteLabel = NoteLabels[currentIndex];
            currentNoteLabel.text = string.Empty;
            if (isActive)
            {
                if (NOTE_LABELS[currentNoteIndex] != null)
                {
                    currentNoteLabel.text = NOTE_LABELS[currentNoteIndex];
                }
                ++currentNoteIndex;
            }

            currentIndex = currentIndex + 1 >= count ? 0 : currentIndex + 1;
        }
    }
}
