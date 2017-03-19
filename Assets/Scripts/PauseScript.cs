using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    private int _window;
    private bool _show;

    void Start()
    {
        _window = 1;
        _show = false;
        Cursor.visible = false;

    }

    public void ExitGame()
    {
        Application.Quit();
    }

   

    private void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {                
            _show = !(_show);
        }
    }

    void OnGUI()
    {
        if (_show == true)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
            if (_window == 1)
            {
                if (GUI.Button(new Rect(10, 30, 180, 30), "Resume"))
                {
                    _show = false;
                    Cursor.visible = false;
                    Time.timeScale = 1;

                }
                if (GUI.Button(new Rect(10, 70, 180, 30), "Change level"))
                {
                    _window = 2;
                }
                if (GUI.Button(new Rect(10, 110, 180, 30), "About"))
                {
                    _window = 4;
                }
                if (GUI.Button(new Rect(10, 150, 180, 30), "Exit"))
                {
                    _window = 5;
                }
            }

            if (_window == 2)
            {
                GUI.Label(new Rect(50, 10, 180, 30), "Change level");
                if (GUI.Button(new Rect(10, 40, 180, 30), "Level 0"))
                {
                    _show = false;
                    Cursor.visible = false;
                    Time.timeScale = 1;
                    SceneManager.LoadSceneAsync(0);
                }
                if (GUI.Button(new Rect(10, 80, 180, 30), "Level 1"))
                {
                    _show = false;
                    Cursor.visible = false;
                    Time.timeScale = 1;
                    SceneManager.LoadSceneAsync(1); 
                }
                if (GUI.Button(new Rect(10, 120, 180, 30), "Level 2"))
                {
                    _show = false;
                    Cursor.visible = false;
                    Time.timeScale = 1;
                    SceneManager.LoadSceneAsync(2);
                }
                if (GUI.Button(new Rect(10, 160, 180, 30), "Back"))
                {
                    _window = 1;
                }
            }     

            if (_window == 4)
            {
                GUI.Label(new Rect(10, 10, 250, 100),
                    "This game is Arkanoid, which contains several fascinating levels in which you have to destroy all the blocks to win. Good luck! This is a study project, so do not judge strictly)");
                GUI.Label(new Rect(10, 110, 250, 40), "Tihonov Sergey, sergtihonov77@gmail.com");
                if (GUI.Button(new Rect(10, 170, 180, 30), "Back"))
                {
                    _window = 1;
                }
            }

            if (_window == 5)
            {
                GUI.Label(new Rect(10, 10, 200, 50), "Are you already getting out?");
                if (GUI.Button(new Rect(10, 40, 180, 30), "Yes"))
                {
                    ExitGame();
                }
                if (GUI.Button(new Rect(10, 80, 180, 30), "No"))
                {
                    _window = 1;
                }
            }
            GUI.EndGroup();
        }
    }
}