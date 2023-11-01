using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerPointsScriptableObject", menuName = "Ryder/PlayerPointsScriptableObject", order = 0)]
public class PlayerPointsScriptableObject : ScriptableObject 
{
    [SerializeField] int playerPoints;
    [SerializeField] int pointsToWin;
    public int PointsToWin { get { return pointsToWin; } }
    public UnityEvent<string> onPlayerPointsChanged;
    public int PlayerPoints {get { return playerPoints;} set { playerPoints = value; onPlayerPointsChanged.Invoke(playerPoints.ToString() + "/" + pointsToWin.ToString()); } }

}
