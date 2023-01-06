using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Crocodile[] crocodiles;
    public Duck duck;
    public Transform pellets;

    public Text gameOverText;
    public Text scoreText;
    public Text livesText;

    public Text roundText;

    public int crocodileMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    public int round { get; private set; }

    private void Start()
    {
        if (SceneManager.GetSceneByName("StartScreen").IsValid())
        {
            SceneManager.UnloadSceneAsync("StartScreen");
        }

        NewGame();
    }

    private void Update()
    {
        if (!PauseMenuScript.isPaused)
        {
            if (this.lives <= 0 && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
            {
                NewGame();
            }
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        SetRound(0);
        NewRound();
    }

    private void NewRound()
    {
        SetRound(round + 1);
        this.gameOverText.enabled = false;

        foreach (Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        ResetCrocodileMultiplier();

        for (int i = 0; i < this.crocodiles.Length; i++)
        {
            this.crocodiles[i].ResetState();
        }

        this.duck.ResetState();
    }

    private void GameOver()
    {
        this.gameOverText.enabled = true;

        for (int i = 0; i < this.crocodiles.Length; i++)
        {
            this.crocodiles[i].gameObject.SetActive(false);
        }

        this.duck.gameObject.SetActive(false);
    }

    private void SetScore(int score)
    {
        this.score = score;
        this.scoreText.text = score.ToString().PadLeft(2, '0');
    }

    private void SetRound(int round)
    {
        this.round = round;
        this.roundText.text = round.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        this.livesText.text = "x" + lives.ToString();
    }

    public void CrocodileEaten(Crocodile crocodile)
    {
        int points = crocodile.points * this.crocodileMultiplier;
        SetScore(this.score + points);
        this.crocodileMultiplier++;
    }

    public void DuckEaten()
    {
        this.duck.gameObject.SetActive(false);

        SetLives(this.lives - 1);

        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        }
        else
        {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);

        SetScore(this.score + pellet.points);

        if (!HasRemainingPellets())
        {
            this.duck.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        for (int i = 0; i < this.crocodiles.Length; i++)
        {
            this.crocodiles[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);

        CancelInvoke(nameof(ResetCrocodileMultiplier));
        Invoke(nameof(ResetCrocodileMultiplier), pellet.duration);
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in this.pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }

        }
        return false;
    }

    private void ResetCrocodileMultiplier()
    {
        this.crocodileMultiplier = 1;
    }

}
