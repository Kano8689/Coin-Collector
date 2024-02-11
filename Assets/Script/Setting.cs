using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickArrow()
    {
        SceneManager.LoadScene("Arrow");
    }

    public void onClickButton()
    {
        SceneManager.LoadScene("Button");
    }

    public void onClickTield()
    {
        SceneManager.LoadScene("Tield");
    }

}
