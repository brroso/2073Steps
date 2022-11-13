using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointCounter : MonoBehaviour
{
    private Label distanceLabel;
    private bool checkpointControl;
    
    private void OnEnable()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        rootVisualElement.Q("checkpoint").style.display = DisplayStyle.None;

        distanceLabel = rootVisualElement.Q<Label>("distance");

        InvokeRepeating("IncrementDistance", 0.5f, 1f);

    }

    private void Update()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        if (GameManager.current_character == Character.Maratonista)
        {
            rootVisualElement.Q("icon_maratonista").style.display = DisplayStyle.Flex;
            rootVisualElement.Q("icon_cientista").style.display = DisplayStyle.None;
            rootVisualElement.Q("icon_fantasma").style.display = DisplayStyle.None;
        }
        else if (GameManager.current_character == Character.Cientista)
        {
            rootVisualElement.Q("icon_maratonista").style.display = DisplayStyle.None;
            rootVisualElement.Q("icon_cientista").style.display = DisplayStyle.Flex;
            rootVisualElement.Q("icon_fantasma").style.display = DisplayStyle.None;
        }
        else if (GameManager.current_character == Character.Fantasma)
        {
            rootVisualElement.Q("icon_maratonista").style.display = DisplayStyle.None;
            rootVisualElement.Q("icon_cientista").style.display = DisplayStyle.None;
            rootVisualElement.Q("icon_fantasma").style.display = DisplayStyle.Flex;
        }

        if (GameManager.distance >= (2073 - (GameManager.gameSpeed * 10)))
        {
            checkpointDisplay();
        }
        else
        {
            checkpointHide();
        }
    }

    private void IncrementDistance()
    {
        GameManager.distance += GameManager.gameSpeed * 10;
        distanceLabel.text = $"Distance: {GameManager.distance}";
    }

    public void checkpointDisplay()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        rootVisualElement.Q("checkpoint").style.display = DisplayStyle.Flex;
    }

    public void checkpointHide()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        rootVisualElement.Q("checkpoint").style.display = DisplayStyle.None;
    }
}
