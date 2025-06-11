using UnityEngine;

[CreateAssetMenu(menuName = "Quest/SurviveQuest")]
public class QuestData : ScriptableObject
{
    public string questName;
    public float duration;
    public int rewardScore;
}
