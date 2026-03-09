using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseGameUI : MonoBehaviour
{
    public GameObject pauseGamePanel;

    public Slider sliderBGM;
    public Slider sliderSFX;

    public TMP_Text textBGMRate;
    public TMP_Text textSFXRate;

    private void Start()
    {
        float volumeBGM = PlayerPrefs.GetFloat("VolumeBGM", 1.0f);
        float volumeSFX = PlayerPrefs.GetFloat("VolumeSFX", 1.0f);

        if (sliderBGM != null)
        {
            AudioManager.instance.SetBGMVolume(volumeBGM);
            sliderBGM.value = volumeBGM;
        }

        if (sliderSFX != null)
        {
            AudioManager.instance.SetSFXVolume(volumeSFX);
            sliderSFX.value = volumeSFX;
        }

        UpdateBGMRateText(volumeBGM);
        UpdateSFXRateText(volumeSFX);

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

    public void OnChangedBGMSlider(float value)
    {
        AudioManager.instance.SetBGMVolume(value);

        UpdateBGMRateText(value);

        PlayerPrefs.SetFloat("VolumeBGM", value);
        PlayerPrefs.Save();
    }

    public void OnChangedSFXSlider(float value)
    {
        AudioManager.instance.SetSFXVolume(value);

        UpdateSFXRateText(value);

        PlayerPrefs.SetFloat("VolumeSFX", value);
        PlayerPrefs.Save();
    }

    void UpdateBGMRateText(float value)
    {
        if(textBGMRate != null)
        {
            int result = (int)(value * 100);
            textBGMRate.text = result.ToString() + "%";
        }
    }

    void UpdateSFXRateText(float value)
    {
        if (textSFXRate != null)
        {
            int result = (int)(value * 100);
            textSFXRate.text = result.ToString() + "%";
        }
    }
}
