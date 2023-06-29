using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int totalScore;

    public void UpdateScore()
    {
        totalScore += 100;
    }
}