using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public string[] normalDialogue;
    public string[] questDialogue;
    public GameObject rewardObject;

    private bool isPlayerNearby = false;
    private bool isQuestDone = false;

    // Update is called once per frame
    void Update()
    {
        if(isPlayerNearby == true && Input.GetKeyDown(KeyCode.E) == true)
        {
            int coins = GameManager.instance.GetCurrentCoin();

            if(coins >= 3 && isQuestDone == false)
            {
                GameManager.instance.dialogueManager.StartDialogue(questDialogue);
            }
            else
            {
                GameManager.instance.dialogueManager.StartDialogue(normalDialogue);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            isPlayerNearby = false;
        }
    }
}
