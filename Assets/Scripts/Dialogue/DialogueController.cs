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

    void Start()
    {
        ShowSentence();
    }

    void Update()
    {
        // SOLO acepta espacio cuando NO está escribiendo
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
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
            yield return new WaitForSeconds(dialogueSpeed);
        }

        isTyping = false;
    }
}

