using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(1);

        // 레벨 받을 수 있도록 (
        // 게임 오버에서 마지막레벨 저장
    }
}