using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointCounter : MonoBehaviour
{
    private Label distanceLabel;
    
    private void OnEnable()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        distanceLabel = rootVisualElement.Q<Label>("distance");

        InvokeRepeating("IncrementDistance", 0.5f, 1f);
    }

    private void IncrementDistance()
    {
        GameManager.distance += GameManager.gameSpeed * 10;
        distanceLabel.text = $"Distance: {GameManager.distance}";
    }
}
