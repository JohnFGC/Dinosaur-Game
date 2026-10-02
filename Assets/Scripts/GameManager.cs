using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //Singleton Pattern
    public static GameManager instance {get; private set;}
    public float initialGameSpeed = 6f;
    public float gameSpeedIncrease = 0.15f;
    public float gameSpeed {get; private set;}

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;

    public Button retryButton;

    private Player player;
    private Spawner enemySpawner;
    private DecorationSpawner decorationSpawner;

    private float score;

    private void Awake(){
        //Initialize
        if (instance == null){
            instance = this;
        }
        else {
            //Ensures only one exists
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy(){
        //Destroys after game ends
        if (instance == this){
            instance = null;
        }
    }

    private void Start(){
        //Start is called once before the first execution of Update after the MonoBehaviour is created

        //Initialize Player and Spawners
        player = FindObjectOfType<Player>();
        enemySpawner = FindObjectOfType<Spawner>();
        decorationSpawner = FindObjectOfType<DecorationSpawner>();
        NewGame();
    }

    public void NewGame(){
        
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (var enemy in enemies){
            Destroy(enemy.gameObject);
        }

        //Initialize Game Speed and Score
        gameSpeed = initialGameSpeed;
        score = 0f;
        enabled = true;

        //Activates Player, Enemy and Decoration Movement on Game Start
        player.gameObject.SetActive(true);
        enemySpawner.gameObject.SetActive(true);
        decorationSpawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        UpdateHiScore();
    }

    public void GameOver(){
        //Sets Game Speed to 0
        gameSpeed = 0f;
        enabled = false;

        //Activates Player, Enemy and Decoration Movement on Game Start
        player.gameObject.SetActive(false);
        enemySpawner.gameObject.SetActive(false);
        decorationSpawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        UpdateHiScore();
    }

    private void Update(){
        //Update is called once per frame
        
        //Update Game Speed and Score
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    private void UpdateHiScore(){
        //Keeps Track of Hi Score
        float hiScore = PlayerPrefs.GetFloat("hiScore", 0);

        if (score > hiScore){
            hiScore = score;
            PlayerPrefs.SetFloat("hiScore", hiScore);
        }

        hiScoreText.text = Mathf.FloorToInt(hiScore).ToString("D5");
    }
}
