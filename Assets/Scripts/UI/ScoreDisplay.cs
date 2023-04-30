using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;


    private void Start()
    {
        _score.text = _player.Score.ToString();
    }

    private void OnEnable()
    {
        _player.ScoreEncreased += ChangeScoreValue;
    }

    private void OnDisable()
    {
        _player.ScoreEncreased -= ChangeScoreValue;
    }

    public void ChangeScoreValue()
    {
        _score.text = _player.Score.ToString();
    }
}
