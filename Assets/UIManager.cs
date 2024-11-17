using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}
