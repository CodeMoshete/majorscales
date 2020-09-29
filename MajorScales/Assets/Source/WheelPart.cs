using UnityEngine;
using UnityEngine.UI;
using Utils;

public class WheelPart : MonoBehaviour
{
    public string Key;
    private GameObject onImage;
    private GameObject offImage;
    private GameObject keyIndicator;
    private Button selectButton;
    private Engine engine;

    public void Awake()
    {
        onImage = UnityUtils.FindGameObject(gameObject, "On");
        offImage = UnityUtils.FindGameObject(gameObject, "Off");
        keyIndicator = UnityUtils.FindGameObject(gameObject, "KeyIndicator");
        selectButton = GetComponentInChildren<Button>();
        selectButton.onClick.AddListener(OnKeyButtonPressed);
        engine = GameObject.Find("Engine").GetComponent<Engine>();
    }

    private void OnKeyButtonPressed()
    {
        engine.SetKeyIndex(this);
    }

    public void SetActive(bool isActive)
    {
        onImage.SetActive(isActive);
        offImage.SetActive(!isActive);
    }

    public void SetIsKey(bool isKey)
    {
        keyIndicator.SetActive(isKey);
    }
}
