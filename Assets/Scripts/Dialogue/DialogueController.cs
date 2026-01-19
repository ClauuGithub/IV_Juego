using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    public float dialogueSpeed = 0.05f;

    private int index = 0;
    private bool isTyping = false;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        // SOLO acepta espacio/ratón cuando NO está escribiendo
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isTyping)
        {
            index++;

            if (index < sentences.Length)
            {
                ShowSentence();
            }
            else
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    void ShowSentence()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        StartCoroutine(TypeSentence(sentences[index]));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;

        foreach (char c in sentence)
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(dialogueSpeed);
        }

        isTyping = false;
    }

    void ResetDialogue()
    {
        StopAllCoroutines();
        Time.timeScale = 1f;

        index = 0;
        isTyping = false;
        dialogueText.text = "";

        if (sentences != null && sentences.Length > 0)
            ShowSentence();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ResetDialogue();
    }
}

