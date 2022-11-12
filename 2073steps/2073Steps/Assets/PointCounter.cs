using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointCounter : MonoBehaviour
{
    private Label distanceLabel;

    private float distance;
    
    private void OnEnable()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        distanceLabel = rootVisualElement.Q<Label>("distance");

        InvokeRepeating("IncrementDistance", 0f, 1f);
    }

    private void IncrementDistance()
    {
        distance += GameManager.gameSpeed;
        distanceLabel.text = $"Distance: {distance}";
    }
}
