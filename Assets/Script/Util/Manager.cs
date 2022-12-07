using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private static Manager instance = null;

    public static bool GameisPaused;

    public static int currentScore;
    public static int currentGem;
    public static int currentStamina;

    public static float feverGauge;

    public static bool isAnyAchived = false;
    public static bool isGameOverUIPopedUp = false;

    public BestRecord _bestRecord = new BestRecord();
    public GemState _gemState = new GemState();
    public Operator _operator = new Operator();
    public PlayCount _playCount = new PlayCount();

    public AchieveItemSO[] ScoreAchieve;
    public AchieveItemSO[] GemAchieve;
    public AchieveItemSO[] PlaytimeAchieve;
    public AchieveItemSO[] plusAchieve;
    public AchieveItemSO[] minusAchieve;
    public AchieveItemSO[] multiAchieve;
    public AchieveItemSO[] divAchieve;

    public AudioClip GameOverUICl;
    public AudioClip gameOverCl;

    public int isCol1;
    public int isCol2;
    public int isCol3;
    public int ColState;
    public int MoveState;

    public void Update()
    {
        if (currentStamina <= 0 && !isGameOverUIPopedUp)
        {
            GameOver();
        }
    }

    void Awake()
    {
        if (null == instance)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        InitGame();
        
    }

    public static Manager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void InitGame()
    {
        CheckAchieve();
        Time.timeScale = 1.0f;
        GameisPaused = false;

        currentGem = 0;
        currentScore = 0;
        currentStamina = 5;
        feverGauge = 0;

        isAnyAchived = false;
        isGameOverUIPopedUp = false;

        int playTime = _playCount.LoadPlayCount();
        if(playTime == 0)
        {
            GameObject go = Resources.Load<GameObject>("Prefabs/UI/Popup/UI_Tutorial");
            Instantiate(go);
            PauseGame();
        }

}

    public void PauseGame()
    {
        if (GameisPaused)
            return;
        else
        {
            Time.timeScale = 0f;
            GameisPaused = true;
            return;
        }
    }

    public void ContinueGame()
    {
        if (!GameisPaused)
            return;
        else
        {
            Time.timeScale = 1.0f;
            GameisPaused = false;
            return;
        }
    }

    public void RestartGame()
    {
        isGameOverUIPopedUp = false;
        ContinueGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restarting the game...");
        InitGame();
    }

    public void GameOver()
    {
        GameObject.Find("@Scene").GetComponent<AudioSource>().Stop();
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(GameOverUICl);
        audio.clip = gameOverCl;
        audio.loop = true;
        audio.Play();

        _playCount.SavePlayCount();
        updateTotalGem();
        currentGem = 0;

        updateBestScore();
        CheckAchieve();
        PauseGame();

        int bs = _bestRecord.Load();
        Debug.Log($"best score is {bs}");
        int tg = _gemState.Load();
        Debug.Log($"total gem is {tg}");
        int pc = _playCount.LoadPlayCount();
        Debug.Log($"play count is {pc}");

        UI_Manager.UI_Instance.GameOverUI();
        isGameOverUIPopedUp = true;

    }

    public void updateScore(int changeValue)
    {
        if (changeValue >= 0)
        {
            currentScore = currentScore + changeValue;
            return;
        }

        if (currentScore <= (-changeValue))
            currentScore = 0;
        else
            currentScore = currentScore + changeValue;
    }

    public void updateStamina(int changeValue)
    {
        if (currentStamina <= 0 || currentStamina >= 6)
        {
            Debug.Log("Stamina value error");
            return;
        }
        if (changeValue > 0 && currentStamina == 5)
            return;

        if (currentStamina > 0 || currentStamina < 6)
            currentStamina = currentStamina + changeValue;
    }

    public void updateGem(int changeValue)
    {
        currentGem += changeValue;
        
    }

    public void PlusFeverGaugeValue()
    {
        float feverGaugeValue = feverGauge;

        if (feverGaugeValue < 0 || feverGaugeValue > 100)
        {
            Debug.Log("feverGaugeValue value error");
        }
        else if (feverGaugeValue > 70 && feverGaugeValue <= 100)
        {
            feverGaugeValue = 100;
        }
        else if (feverGaugeValue >= 0 || feverGaugeValue <= 70)
            feverGaugeValue += 30;

        feverGauge = feverGaugeValue;
    }

    public void updateBestScore()
    {
        int BestScore = _bestRecord.Load();
        if (BestScore == null)
            _bestRecord.SaveRecord(0);

        if (currentScore > BestScore)
        {
            _bestRecord.SaveRecord(currentScore);
        }
        else
            return;
    }

    public void updateTotalGem()
    {
        _gemState.SaveGem(currentGem);
    }

    public void CheckAchieve()
    {
        int totalGem = _gemState.Load();
        int playTime = _playCount.LoadPlayCount();
        OCount symbol = _operator.LoadOperatorCount();

        // 스코어 업적 달성확인
        for (int i = 0; i < ScoreAchieve.Length; i++)
        {
            if (currentScore >= ScoreAchieve[i].acheievScore)
                ScoreAchieve[i].isCompleted = true;
        }

        // 젬 업적 달성확인
        for (int i = 0; i < GemAchieve.Length; i++)
        {
            if (totalGem >= GemAchieve[i].acheievScore)
                GemAchieve[i].isCompleted = true;
        }

        // 플레이횟수 업적 달성확인
        for (int i = 0; i <PlaytimeAchieve.Length; i++)
        {
            if (playTime >= PlaytimeAchieve[i].acheievScore)
                PlaytimeAchieve[i].isCompleted = true;
        }

        // 기호 타일 업적 달성확인
        for (int i = 0; i < plusAchieve.Length; i++)
        {
            if (symbol.plus >= plusAchieve[i].acheievScore)
                plusAchieve[i].isCompleted = true;
        }

        for (int i = 0; i < minusAchieve.Length; i++)
        {
            if (symbol.minus >= minusAchieve[i].acheievScore)
                minusAchieve[i].isCompleted = true;
        }
        for (int i = 0; i < multiAchieve.Length; i++)
        {
            if (symbol.multiply >= multiAchieve[i].acheievScore)
                multiAchieve[i].isCompleted = true;
        }
        for (int i = 0; i < divAchieve.Length; i++)
        {
            if (symbol.divide >= divAchieve[i].acheievScore)
                divAchieve[i].isCompleted = true;
        }
    }
}