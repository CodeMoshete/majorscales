using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChordsDisplayComponent
{
    private List<WheelPart> wheelParts;
    private Text display;

    public ChordsDisplayComponent(Text displayField, List<WheelPart> wheelParts)
    {
        display = displayField;
        this.wheelParts = wheelParts;
    }

    public void SetKeyIndex(WheelPart key)
    {

    }
}
