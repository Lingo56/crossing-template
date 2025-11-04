using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class Fishing : MonoBehaviour
{
    public GameObject fishingRod;
    public GameObject fishIcon;
    public TextMeshProUGUI scoreText;

    private bool nearWater = false;
    private bool fishingInProgress = false;
    private int score = 0;
    private AudioSource[] audioSources;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nearWater && fishingInProgress && Input.GetKeyDown(KeyCode.E))
        {
            StartFishing();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GrassEdge"))
        {
            // TODO: Handle fishing enable
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("GrassEdge"))
        {
            // TODO: Handle fishing disable
        }
    }

    void StartFishing()
    {
        Debug.Log("Fishing started!");

        fishingInProgress = true;

        // Show fishing rod and play sound
        if (fishingRod != null)
        {
            // TODO: Setup fishing start
        }

        // Stop player movement
        MoveCharacter moveChar = GetComponent<MoveCharacter>();
        // TODO: Stop the player from moving

        // Start coroutine for fishing sequence
        StartCoroutine(FishingSequence());
    }

    // Coroutine (list of actions that run in order) to make the player fish
    // Want to use this because you can wait without freezing other functionlity in your game
    private System.Collections.IEnumerator FishingSequence()
    {
        yield return new WaitForSeconds(1.5f);

        // TODO: Increase score and update text
        if (scoreText != null)
            scoreText.text = "Score Text";

        // TODO: Hide fishing rod and icon

        // TODO: Show fish icon

        // TODO: Allow player movement again
        MoveCharacter moveChar = GetComponent<MoveCharacter>();

        // TODO: Hide fish after 1 second

        fishingInProgress = false;
    }
}
