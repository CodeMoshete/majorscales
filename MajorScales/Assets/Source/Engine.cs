using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    public List<WheelPart> WheelParts;
    public List<Text> NoteNumbers;
    public List<Text> NoteLabels;
    public Text KeyOfText;
    public Button ToggleModeButton;
    public Text ModeText;
    public Text ChordsTextField;

    private int typeIndex = -1;
    private List<Type> possibleTypes = new List<Type>();
    private IDisplayMode currentDisplayMode;
    private ChordsDisplayComponent chordsDisplay;

    private void Start()
    {
        possibleTypes.Add(typeof(WheelHighlightDisplayMode));
        possibleTypes.Add(typeof(NoteRotateDisplayMode));
        ToggleDisplayMode();
        ToggleModeButton.onClick.AddListener(ToggleDisplayMode);
        chordsDisplay = new ChordsDisplayComponent(ChordsTextField, WheelParts);
    }

    public void ToggleDisplayMode()
    {
        typeIndex = typeIndex >= possibleTypes.Count - 1 ? 0 : typeIndex + 1;
        currentDisplayMode = (IDisplayMode)Activator.CreateInstance(possibleTypes[typeIndex]);
        currentDisplayMode.Initialize(WheelParts, NoteNumbers, NoteLabels, KeyOfText);
        ModeText.text = currentDisplayMode.DisplayName;
    }

    public void SetKeyIndex(WheelPart key)
    {
        currentDisplayMode.SetKeyIndex(key);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
