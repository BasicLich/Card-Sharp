using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private bool dialogueGone = false;
    public Animator animator;
    public string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneChange());
    }
    void Update()
    {
        if (DialogueManager.dialogueIsActive)
        {
            dialogueGone = true;
        }
    }
    IEnumerator SceneChange()
    {
        yield return null;
        while (DialogueManager.dialogueIsActive || !dialogueGone)
        {
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
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
