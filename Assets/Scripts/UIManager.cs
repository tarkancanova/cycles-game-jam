using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private PlayerHitObstacle _playerHitObstacleScript;
    
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        _playerHitObstacleScript = GetComponent<PlayerHitObstacle>();
        
    }

    public void OnGameDone()
    {
        _gameOverPanel.SetActive(true);
    }

    public void PressedRestartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}


