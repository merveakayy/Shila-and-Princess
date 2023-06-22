using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameover;
    public GameObject playmenu;
    [ContextMenu("Test")]
    public void EndGame()
    {
        gameover.SetActive(true);
        playmenu.SetActive(false);
    }
}
