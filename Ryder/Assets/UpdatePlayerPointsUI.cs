using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatePlayerPointsUI : MonoBehaviour
{
    [SerializeField] PlayerPointsScriptableObject playerPoints;
    private TMP_Text pointsText;

    void Awake()
    {
        pointsText = GetComponent<TMP_Text>();
    }
    void OnEnable()
    {
        playerPoints.onPlayerPointsChanged.AddListener(UpdateText);
    }

    void OnDisable()
    {
        playerPoints.onPlayerPointsChanged.RemoveListener(UpdateText);
    }

    void UpdateText(string text)
    {
        pointsText.text = text;
    }
}
