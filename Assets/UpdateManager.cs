using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateManager : MonoBehaviour
{
    private int score;
    public Text visualScore;
    public GameObject GOScreen;
    public GameObject Menu;
    public AudioSource crash;
    private bool playing = true;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.Pause();
        }
    }
    public void addToScore(int extra)
    {
        this.score += extra;
        this.visualScore.text = this.score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (this.playing)
        {
            this.playing = false;
            crash.Play();
            this.GOScreen.SetActive(true);
        }
    }
    
    public void Pause()
    {
        this.Menu.SetActive(!this.Menu.activeSelf);
        Time.timeScale = Mathf.Pow(Time.timeScale - 1.0f, 2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
