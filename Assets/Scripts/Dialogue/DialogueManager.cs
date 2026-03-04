using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialoguePanel;

    private string[] sentences;
    private int index;
    public float typingSpeed = 0.05f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    IEnumerator TypeSentence()
    {
        dialogueText.text = string.Empty;   // 빈 문자열로 초기화.

        // string : 여러 개의 문자로 구성된 문자열.
        // char : 하나의 문자를 담을 수 있는 자료형
        // ToCharArray : 문자열을 문자 배열로 변환해주는 함수.
        foreach(char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void StartDialogue(string[] lines)
    {
        sentences = lines;
        index = 0;
        dialoguePanel.SetActive(true);
        StartCoroutine(TypeSentence());
    }

    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            StopAllCoroutines();
            StartCoroutine(TypeSentence());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
