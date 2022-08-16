using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _bestScoreText;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private GameObject _gameOverScreen;
    private GameManager _gameManager;
    private PlayerController _player;
     
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _scoreText.text = "Score: " + 0;
        _bestScoreText.text = "Best: " + MainManager.Instance._bestScore;
       
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

   
    
    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _livesSprites[currentLives];
        if(currentLives==0)
        {
            _player.CheckForBestScore();
            _gameOverScreen.SetActive(true);
            MainManager.Instance._bestScore = _player._bestScore;
            _gameManager.GameOver();
        }
    }


   
}
