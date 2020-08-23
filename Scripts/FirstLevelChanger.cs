using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevelChanger : MonoBehaviour
{
    public Animator animator;
    public string levelToLoad;
    void Start()
    {
        StartCoroutine(TriggerDialogue());
    }
    IEnumerator TriggerDialogue()
    {
        yield return new WaitForSeconds(1f);
        while (DialogueManager.dialogueIsActive) {
            yield return null;
        }
        FadeToLevel(levelToLoad);
    }
    public void FadeToLevel(string levelName)
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
