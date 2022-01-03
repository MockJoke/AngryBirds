using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button reloadButton;

    private void Start()
    {
        reloadButton.onClick.AddListener(onReloadButtonClick); 
    }
    void onReloadButtonClick()
    {
        SceneManager.LoadScene(0); 
    }
}
