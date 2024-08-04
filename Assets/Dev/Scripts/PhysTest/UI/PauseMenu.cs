using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _catapult;
    [SerializeField] private GameObject _train;

    private bool _paused;

    void Start()
    {
        _pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_paused)
            {
                ResumeGame();
            }
            else 
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        _paused = true;
        Time.timeScale = .0f;
        Cursor.visible = true;

        var catapult = _catapult.GetComponent<CatapultBehavior>();
        catapult.canMove = false;

        var train = _train.GetComponent<TrainBehavior>();
        train.canMove = false;
    }

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        _paused = false;
        Time.timeScale = 1.0f;
        Cursor.visible = false;

        var fuckYou = _catapult.GetComponent<CatapultBehavior>();
        fuckYou.canMove = true;

        var train = _train.GetComponent<TrainBehavior>();
        train.canMove = true;
    }
}
