using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_ManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private TMP_Text Score;
    void Start()
    {
        Score.text = "Score: " +100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
