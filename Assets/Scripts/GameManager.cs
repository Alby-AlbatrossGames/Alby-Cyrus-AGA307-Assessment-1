using TMPro;
using UnityEngine;

public enum Difficulty { Easy, Normal, Hard }
public class GameManager : Singleton<GameManager>
{
    public int totalScore = 0;
    private float timeLeft = 30;
    public Difficulty difficulty = Difficulty.Normal;
    private TargetManager _TM;
    private ScoreManager _SM;
    public TMP_Text timeUI;

    private void Start()
    {
        _TM = FindFirstObjectByType<TargetManager>();
        _SM = FindFirstObjectByType<ScoreManager>();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeUI.text = (timeLeft.ToString("- ## -"));

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            difficulty = Difficulty.Easy;
            _TM.ResizeAll(0.5f);
            _SM.updateDifficultyUI(difficulty);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            difficulty = Difficulty.Normal;
            _TM.ResizeAll(1.0f);
            _SM.updateDifficultyUI(difficulty);
        }
            
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            difficulty = Difficulty.Hard;
            _TM.ResizeAll(1.5f);
            _SM.updateDifficultyUI(difficulty);
        }
    }
    public void addTime(int _seconds) => timeLeft += _seconds;
    public void addScore(int _value)
    {
        totalScore += _value;
        _SM.updateScoreUI(totalScore);
    }
}
