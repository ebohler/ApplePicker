using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public int round = 1;
    public Text roundCounterText;

    void Start()
    {
        roundCounterText = GetComponent<Text>();
    }

    public void IncreaseRound()
    {
        round++;
    }

    void Update()
    {
        roundCounterText.text = round.ToString("Round #");
    }
}
