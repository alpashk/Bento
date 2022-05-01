using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    
    
    void Awake()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
