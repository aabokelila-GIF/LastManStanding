using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_ManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private TMP_Text Score;

    [SerializeField] private Image Lives_image;

    [SerializeField] private Sprite[] Lives_sprites;
    [SerializeField] private TMP_Text GameOverr;
    [SerializeField] private TMP_Text Restart_Text;
    private GameManager_2Dd gameManager;
    void Start()
    {
        Score.text = "Score: " +0;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager_2Dd>();
        if (gameManager == null)
        {
            {
                Debug.Log("Error");
            }
        }


    }
    private void Update()
    {
   
    }
    public void UpdateScore(int Points)
    {
        Score.text = "Score: " + Points; 
    }

    public void UpdateLives (int CurrentLives)
    {
        Lives_image.sprite = Lives_sprites[CurrentLives];
        if (CurrentLives ==0)
            {

            GameOver();
            }
    }
    IEnumerator GameOver_Flicker()
    {
        while (true)
        {
            GameOverr.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
              
            GameOverr.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void GameOver()
    {
        gameManager.isGameover();
        GameOverr.gameObject.SetActive(true);
        Restart_Text.gameObject.SetActive(true);

        StartCoroutine(GameOver_Flicker());

    }
}
