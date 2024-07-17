using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private TargetManager _TM;
    [Header("UIComponents")]
    public TMP_Text scoreText;
    public TMP_Text targetCountText;
    public TMP_Text difficultyText;

    private void Start()
    {
        _TM = GetComponent<TargetManager>();
        updateDifficultyUI(Difficulty.Normal);
        updateScoreUI(0);
        updateTargetUI();
    }
    public void updateScoreUI(int _value)
    {
        scoreText.text = "Score: " + _value;
    }
    public void updateTargetUI()
    {
        targetCountText.text = "Targets Left: " + _TM.GetTargetCount();
    }
    public void updateDifficultyUI(Difficulty _difficulty)
    {
        difficultyText.text = "Difficulty: " + _difficulty.ToString();
    }
}
