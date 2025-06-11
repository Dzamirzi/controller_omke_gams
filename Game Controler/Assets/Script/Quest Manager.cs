using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestData questData;
    private float questTimer = 0f;
    private bool questActive = false;
    private float timeSinceLastQuest = 0f;

    void Update()
    {
        // Wait before starting next quest
        if (!questActive)
        {
            timeSinceLastQuest += Time.deltaTime;
            if (timeSinceLastQuest >= 10f)
            {
                StartQuest();
            }
        }
        else
        {
            questTimer += Time.deltaTime;
            if (questTimer >= questData.duration)
            {
                CompleteQuest();
            }
        }
    }

    void StartQuest()
    {
        questActive = true;
        questTimer = 0f;
        Debug.Log("Quest Started: " + questData.questName);
    }

    void CompleteQuest()
    {
        questActive = false;
        timeSinceLastQuest = 0f;
        ScoreManager.Instance.AddScore(questData.rewardScore);
        Debug.Log("Quest Completed! Reward: " + questData.rewardScore + " score");
    }
}
