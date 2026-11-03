using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_2Dd : MonoBehaviour
{
    [SerializeField] private bool Gameover = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Gameover == true)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void isGameover()
    {
        Gameover = true;
    }
}
