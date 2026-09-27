using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTracker : MonoBehaviour
{
    [Header("Dynamic")]
    public int round = 1;
    private Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        uiText.text = "Round: " + round.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool UpdateRound()
    {
        if (round < 4)
        {
            ++round;
            uiText.text = "Round: " + round.ToString();
            return true;
        }
        return false;
    }
    public void GameOver()
    {
        uiText.text = "Game Over";
    }
}
