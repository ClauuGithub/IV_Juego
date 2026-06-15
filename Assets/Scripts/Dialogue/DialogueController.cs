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

    //Cambio de scenes
    [SerializeField] private string nextScene = "GameScene";

    //Cinemática2
    [SerializeField] private GameObject puertaAbierta;
    [SerializeField] private GameObject puertaCerrada;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip puertaCerrandoseSound;

    //Cinemática final
    [SerializeField] private AudioClip ringSound;
    [SerializeField] private AudioClip boomSound;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isTyping)
        {
            index++;

            switch (index)
            {
                // Cinemática puerta
                case 4:
                    if (puertaAbierta != null)
                        puertaAbierta.SetActive(false);

                    if (puertaCerrada != null)
                        puertaCerrada.SetActive(true);

                    if (audioSource != null && puertaCerrandoseSound != null)
                        audioSource.PlayOneShot(puertaCerrandoseSound);
                    break;

                // Sonido del télefono
                case 9:
                    if (audioSource != null && ringSound != null)
                        audioSource.PlayOneShot(ringSound);
                    break;

                // Explosión
                case 19:
                    if (audioSource != null && boomSound != null)
                        audioSource.PlayOneShot(boomSound);
                    break;
            }

            if (index < sentences.Length)
            {
                ShowSentence();
            }
            else
            {
                SceneLoader loader = Object.FindFirstObjectByType<SceneLoader>();

                if (loader != null)
                {
                    // 2. ¡Ejecutamos TU método ya programado!
                    loader.StartNewGame();
                }

                GameStateSingleton.Instance.SetState(new PlayingState(GameStateSingleton.Instance));
                SceneManager.LoadScene(nextScene);
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

