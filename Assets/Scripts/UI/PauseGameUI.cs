using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameUI : MonoBehaviour
{
    public GameObject pauseGamePanel;

    private void Start()
    {
        SetPauseGameUIVisible(false);
    }

    public void SetPauseGameUIVisible(bool visible)
    {
        pauseGamePanel.SetActive(visible);

        if(visible == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void OnClickGoToTitle()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TitleScene");
    }

    public void OnClickRestartGame()
    {
        Time.timeScale = 1.0f;

        // 현재 활성화 된 씬을 다시 로딩.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickResume()
    {
        SetPauseGameUIVisible(false);
    }

    public void OnClickExitGame()
    {
        // 유니티 에디터일 때와 그렇지 않을 경우를 구분해서 각각 다른 코드를 실행.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 프로그램을 종료하는 함수.
        // 빌드 상태일 때만 적용되는 함수.
        Application.Quit();
#endif
    }
}
