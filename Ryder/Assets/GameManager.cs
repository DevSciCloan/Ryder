using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    [SerializeField] PlayerPointsScriptableObject playerPoints;
    public UnityEvent onWinConditionTrue;
    void Awake()
    {
        // Reset point counter
        playerPoints.PlayerPoints = 0;
    }

    void OnEnable()
    {
        playerPoints.onPlayerPointsChanged.AddListener(CheckWin);
    }

    void OnDisable()
    {
        playerPoints.onPlayerPointsChanged.RemoveListener(CheckWin);
    }

    void CheckWin(string points)
    {
        if (playerPoints.PlayerPoints == playerPoints.PointsToWin)
        {
            // Display win screen
            onWinConditionTrue?.Invoke();
        }
    }
}
