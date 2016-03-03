using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int tankCount;
	public GameObject tank;
    public Text Lives;
    public Text Points;
    public Text GameOverLabel;
    public Text HighScoreLabel;
    public PlayerController ship;
   // public EnemyController enemy;
    public Button ResetButton;


    [SerializeField]
    private AudioSource _gameOver;
    private int _scoreValue;
    private int _livesValue;


    // PUBLIC ACCESS METHODS
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;

            this.Points.text = "Score: " + this._scoreValue;

        }
    }


    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            this.Lives.text = "Lives: " + this._livesValue;


        }
    }


    // Use this for initialization
    void Start () {
        this.ScoreValue = 0;
        this.LivesValue = 5;
        this.GameOverLabel.enabled = false;
        this.HighScoreLabel.enabled = false;
        this.ResetButton.gameObject.SetActive(false);
        this._GenerateTanks ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Clouds
	private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}

    private void _endGame()
    {
        this.GameOverLabel.text = "Game Over";
        if (this._livesValue < 1)
        {
            this.GameOverLabel.text = "Game Over";
        }
        else
        {
            this.GameOverLabel.text = "You Won";
        }
        this.HighScoreLabel.text = "High Scrore: " + this._scoreValue;
        this.GameOverLabel.enabled = true;
        this.HighScoreLabel.enabled = true;
        this._gameOver.Play();
        this.ship.gameObject.SetActive(false);
        this.Points.enabled = false;
        this.Lives.enabled = false;
        this.ResetButton.gameObject.SetActive(true);

    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
