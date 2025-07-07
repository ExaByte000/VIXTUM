using System.Collections;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int lastProcessedComboCounter = -1;
    public int ComboCounter;
    public int ComboMultiplire = 1;
    private int points; //Ё“ќ√ќ ѕќЋя «ƒ≈—№ Ѕџ“№ Ќ≈ ƒќЋ∆Ќќ.Ёто поле должно быть в другом классе, которого пока нет
    private int maxScore = 0;
    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score += value * ComboMultiplire;
            if (cooldownForScore != null) StopCoroutine(cooldownForScore);
            if(scoreDown != null) StopCoroutine(scoreDown);
            cooldownForScore = StartCoroutine(nameof(CoolDown));
        }
    }
    private Coroutine cooldownForScore;
    private Coroutine scoreDown;
    [SerializeField] private float timeCooldown;
    [SerializeField] private float scoreDownSpeed;

    private void Update()
    {
        if (ComboCounter > 0 && ComboCounter % 10 == 0 && ComboCounter != lastProcessedComboCounter)
        {
            ComboAdd();
            lastProcessedComboCounter = ComboCounter;
        }
        if(score > maxScore) maxScore = score;
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(timeCooldown);
        ComboMultiplire = 1;
        ComboCounter = 0;
        scoreDown = StartCoroutine(nameof(ScoreDown));
    }
    private IEnumerator ScoreDown() 
    {
        while (score > 0) 
        {
            score--;
            yield return new WaitForSeconds(scoreDownSpeed);
        }
    }

    private void ComboAdd()
    {
        if (ComboMultiplire < 5)
        {
            ComboMultiplire++;
        }
    }

    private void ScoreReset()
    {
        score = 0;
        points += maxScore / 4;
        Debug.Log($"¬ы получили  {maxScore / 4} опыта, теперь у вас {points} опыта");
        maxScore = 0;
        

    }

    private void OnEnable()
    {
        WaveSystem.StopWave += ScoreReset;
    }
    private void OnDisable()
    {
        WaveSystem.StopWave -= ScoreReset;
    }
}
