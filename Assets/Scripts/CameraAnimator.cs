using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] Level level;

    public void SetGameOverTrigger()
    {
        animator.SetTrigger("GameOver");
    }

    public void SetLevelComleteTrigger()
    {
        animator.SetTrigger("LevelComplete");
    }
    public void LoadLevelCompleteScene()
    {
        int nextSceneIndex = PlayerPrefs.GetInt(Level.NEXT_LEVEL_KEY, Level.LEVEL_TO_START);

        if (nextSceneIndex == level.GetTotalSceneNumber() + 1)
        {
            PlayerPrefs.SetInt(Level.GAME_COMPLETE_KEY, Level.GAME_COMPLETE);
            level.LaodLevelSelectorScene();
        }
        else
        {
            level.LaodLevelCompleteScene();
        }
    }

    public void LoadGameOverScene()
    {
        level.LaodLevelFailScene();
    }
} 