using UnityEngine;

public class PlayerFear : MonoBehaviour
{
    public int maxFear = 100;
    public int minFear = 0;
    public int currentFear;

    public Fear_gauge fearBar;
    public GameObject textDisplayLose;
    public GameObject deathbButton;

    void Start()
    {
        currentFear = minFear;
        fearBar.SetMinFear(minFear);
        textDisplayLose.SetActive(false);
        deathbButton.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }
    public void TakeFear(int damage)
    {
        currentFear += damage;
        fearBar.SetFear(currentFear);
        VerifyFear();
    }
    public void VerifyFear()
    {
        if (currentFear < 0)
        {
            currentFear = 0;
        }
        if (currentFear >= 100)
        {
            currentFear = 100;
            textDisplayLose.SetActive(true);
            deathbButton.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
