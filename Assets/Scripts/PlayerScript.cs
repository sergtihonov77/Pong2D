using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public float playerVelocity;
    public float boundary;
    private Vector3 _playerPosition;
    private int _playerLives;
    private int _playerPoints;
    public AudioClip pointSound;
    public AudioClip lifeSound;

  
    void Start ()
    {
        _playerPosition = gameObject.transform.position;
        _playerLives = 5;
        _playerPoints = 0;
    }
   
	void FixedUpdate ()
    {
        // Horizontal movement
        _playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;
        transform.position = _playerPosition;

        //Exit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //Lose game
        if (_playerLives == 0)
        {
            Debug.Log(_playerPoints);
        }



        // Checking out beyond the playing field

        if (_playerPosition.x < -boundary)
        {
            transform.position = new Vector3(-boundary + 1 / 10, _playerPosition.y, _playerPosition.z);
        }
        if (_playerPosition.x > boundary)
        {
            transform.position = new Vector3(boundary - 1/10, _playerPosition.y, _playerPosition.z);
        }

        WinLose();
    }

        void addPoints(int points)
        {
            _playerPoints += points;
            GetComponent<AudioSource>().PlayOneShot(pointSound);
        }

    //Life's and score dynamic label
    void OnGUI()
    {
        GUI.Label(new Rect(5.0f, 3.0f, 600, 200.0f), 
            "Life's: " + _playerLives + "  Score: " + _playerPoints + "     Press 'P' to pause game!" + "    Press 'Space' to force up the ball");
    }
        //Life take
        void TakeLife()
        {
            _playerLives--;
            GetComponent<AudioSource>().PlayOneShot(lifeSound);
        }


        void WinLose()
        {
            // перезапускаем уровень
            if (_playerLives == 0)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
                
            }

            // все блоки уничтожены
            if ((GameObject.FindGameObjectsWithTag("Block")).Length <= 0)
            {
                // проверяем текущий уровень
                if (SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1) != null)
                {
                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    Application.Quit();
                }
            }
        }

}
