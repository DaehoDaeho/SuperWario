using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject fadeOutPanel;
    public Image fadeOutImage;

    private void Start()
    {
        fadeOutPanel.SetActive(false);
    }

    public void GameStart()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        fadeOutPanel.SetActive(true);

        while(true)
        {
            // 이미지의 색상 정보를 가져온다.
            Color color = fadeOutImage.color;
            color.a += 2.0f * Time.deltaTime;
            if(color.a >= 1.0f)
            {
                color.a = 1.0f;
                fadeOutImage.color = color;
                break;
            }
            else
            {
                fadeOutImage.color = color;
            }

            // 다음 프레임까지 대기.
            yield return null;
        }

        // 페이드 아웃이 끝나면 씬 로딩.
        SceneManager.LoadScene("SampleScene");
    }
}
