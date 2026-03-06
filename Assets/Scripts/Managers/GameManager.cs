using UnityEngine;
using TMPro;    // TextMeshPro를 제어하기 위해 추가해야 하는 네임스페이스.
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // static 변수로 자기 자신의 타입을 담을 공간을 만든다.
    // 이 변수는 메모리에 딱 1개만 존재하게 된다.
    public static GameManager instance;

    // 게임 데이터를 관리할 변수들.
    public int totalScore = 0;
    private bool isGameOver = false;

    public float limitTime = 30.0f;
    private float limitTimer = 0.0f;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text totalCoinText;

    public GameObject gameOver;

    public AudioClip audioRestart;
    public AudioClip audioGameOver;

    public int highScore = 0;
    public int totalCoin = 0;
    public int currentCoin = 0;

    public GameObject gainCoinParticlePrefab;
    public DialogueManager dialogueManager;

    public PauseGameUI pauseGame;

    private void Awake()
    {
        // 나 자신(GameManager)을 집어넣어서 초기화 한다.
        instance = this;

        limitTimer = 0.0f;

        // HighScore 키로 저장한 데이터를 불러오는 코드.
        // 만약 저장한 데이터가 없으면 0을 대입.
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log("highScore = " + highScore);

        highScoreText.text = "Best : " + highScore.ToString();

        totalCoin = PlayerPrefs.GetInt("TotalCoin", 0);
        totalCoinText.text = "Coin : " + totalCoin.ToString();

        UpdateUI();

        // 게임 오버 UI 비활성화.
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F11) == true)
        {
            PlayerPrefs.DeleteKey("HighScore");

            highScore = PlayerPrefs.GetInt("HighScore", 0);
            Debug.Log("highScore = " + highScore);
        }

        if(Input.GetKeyDown(KeyCode.F12) == true)
        {
            PlayerPrefs.DeleteAll();

            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = "Best : " + highScore.ToString();

            totalCoin = PlayerPrefs.GetInt("TotalCoin", 0);
            totalCoinText.text = "Coin : " + totalCoin.ToString();
        }

        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            SetPauseGameUIVisible(true);
        }
    }

    public void SetPauseGameUIVisible(bool visible)
    {
        if(pauseGame != null)
        {
            pauseGame.SetPauseGameUIVisible(visible);
        }
    }

    /// <summary>
    /// 점수 추가.
    /// </summary>
    /// <param name="amount">추가할 점수</param>
    public void AddScore(int amount)
    {
        if(isGameOver == true)
        {
            return;
        }

        //totalScore = totalScore + amount;
        totalScore += amount;
        Debug.Log("현재 점수 : " + totalScore);

        UpdateUI();
    }

    public int GetCurrentCoin()
    {
        return currentCoin;
    }

    public void AddCoinCount(int count)
    {
        currentCoin += count;
        totalCoin += count;
        PlayerPrefs.SetInt("TotalCoin", totalCoin);
        PlayerPrefs.Save();

        totalCoinText.text = "Coin : " + totalCoin.ToString();
    }

    public void SetGameOver(bool gameOver)
    {
        isGameOver = gameOver;

        this.gameOver.SetActive(true);
        AudioManager.instance.PlaySFX(audioGameOver);

        // 유니티의 시간을 멈추게 한다.
        Time.timeScale = 0.0f;

        if(totalScore > highScore)
        {
            highScore = totalScore;

            PlayerPrefs.SetInt("HighScore", highScore);

            // 안전을 위해 확실한 저장 함수를 추가로 호출.
            PlayerPrefs.Save();
        }

        Debug.Log("isGameOver = " + isGameOver);
    }

    void UpdateUI()
    {
        scoreText.text = "Score : " + totalScore.ToString();    // 정수를 문자열로 변환.
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;

        AudioManager.instance.PlaySFX(audioRestart);

        //SceneManager.LoadScene("SampleScene");

        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1.0f);

        // 현재 열려 있는 씬의 이름을 가져와서 다시 로딩.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowGainCoinParticle(Vector3 position)
    {
        if(gainCoinParticlePrefab != null)
        {
            GameObject go = Instantiate(gainCoinParticlePrefab, position, Quaternion.identity);
            if(go != null)
            {
                Destroy(go, 1.0f);
            }
        }
    }
}
