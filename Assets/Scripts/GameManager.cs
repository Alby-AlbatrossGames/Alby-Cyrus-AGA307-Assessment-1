using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public enum Difficulty { Easy, Normal, Hard }
public class GameManager : Singleton<GameManager>
{
    private int totalScore = 0;
    private float timeLeft = 30;
    public Difficulty difficulty = Difficulty.Normal;
    private TargetManager _TM;
    public TMP_Text timeUI;

    private void Start()
    {
        _TM = FindFirstObjectByType<TargetManager>();
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeUI.text = (timeLeft.ToString("- ## -"));

        if (Input.GetKeyDown(KeyCode.Alpha1))
            difficulty = Difficulty.Easy;
            _TM.ResizeAll(0.5f);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            difficulty = Difficulty.Normal;
            _TM.ResizeAll(1.0f);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            difficulty = Difficulty.Hard;
            _TM.ResizeAll(1.5f);
    }
    public void addTime(int _seconds) => timeLeft += _seconds;
    public void addScore(int _value) => totalScore += _value;
}
