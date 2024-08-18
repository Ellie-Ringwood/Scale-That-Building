using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimer : MonoBehaviour
{
    public GameObject gameController;
    private float Timer;
    [SerializeField] private TextMeshProUGUI _textUGUI;

    void Update()
    {
        Timer = gameController.GetComponent<GameController>().countdown;
        //int minutes = Mathf.FloorToInt(Timer / 60F);
        int seconds = Mathf.FloorToInt(Timer % 60F);
        //int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
        //_textUGUI.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        _textUGUI.text = seconds.ToString("00");
    }
}
