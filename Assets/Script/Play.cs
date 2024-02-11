using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    float speed = 10f;
    public GameObject coin, parentHolder, redCoin,RedCoin;
    public GameObject WinObj, PlayObj;
    int score = 0;
    public Text Score, WinScore;
    bool isGoingLeft = false;
    bool isGoingRight = false;
    bool isGoingUp = false;
    bool isGoingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i=1;i<=3;i++)
        {
            int randomX = Random.Range(100, 1820);
            int randomY = Random.Range(100, 980);
            Vector2 pos = new Vector2(randomX, randomY);
            Instantiate(coin, pos, Quaternion.identity, parentHolder.transform);
        }

        InvokeRepeating("generateCoins", 2f, 3f);
        InvokeRepeating("generateRedCoins", 3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 0, 1);
        if(Input.GetKey(KeyCode.LeftArrow) || isGoingLeft)
        {
            float maxLeft = Mathf.Clamp(transform.position.x - speed, 80, Screen.width - 80);
            transform.position = new Vector2(maxLeft, transform.position.y);
            transform.Rotate(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.RightArrow) || isGoingRight)
        {
            float maxRight = Mathf.Clamp(transform.position.x + speed, 80, Screen.width - 80);
            transform.position = new Vector2(maxRight, transform.position.y);
            transform.Rotate(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.UpArrow) || isGoingUp)
        {
            float maxUp = Mathf.Clamp(transform.position.y + speed, 80, Screen.height-80);
            transform.position = new Vector2(transform.position.x, maxUp);
            transform.Rotate(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow) || isGoingDown)
        {
            float maxDown = Mathf.Clamp(transform.position.y - speed, 80, Screen.height - 80);
            transform.position = new Vector2(transform.position.x, maxDown);
            transform.Rotate(0, 0, -1);
        }

        accelerationMove(); 
    }

    void accelerationMove()
    {
        if(Input.acceleration.x < -0.1f)
        {
            //isGoingLeft = true;
            float maxLeft = Mathf.Clamp(transform.position.x - speed, 80, Screen.width - 80);
            transform.position = new Vector2(maxLeft, transform.position.y);
            transform.Rotate(0, 0, -1);
        }
        if(Input.acceleration.x > 0.1f)
        {
            float maxRight = Mathf.Clamp(transform.position.x + speed, 80, Screen.width - 80);
            transform.position = new Vector2(maxRight, transform.position.y);
            transform.Rotate(0, 0, 1);
            //isGoingRight = true;
        }
        if(Input.acceleration.y > 0.1f)
        {
            float maxUp = Mathf.Clamp(transform.position.y + speed, 80, Screen.height - 80);
            transform.position = new Vector2(transform.position.x, maxUp);
            transform.Rotate(0, 0, 1);
            //isGoingUp = true;
        }
        if(Input.acceleration.y < -0.1f)
        {
            float maxDown = Mathf.Clamp(transform.position.y - speed, 80, Screen.height - 80);
            transform.position = new Vector2(transform.position.x, maxDown);
            transform.Rotate(0, 0, -1);
            // isGoingDown = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hello");

        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);

            score++;
            Score.text = "" + score;

            int randomX = Random.Range(100, 1820);
            int randomY = Random.Range(100, 980);
            Vector2 pos = new Vector2(randomX, randomY);
            Instantiate(coin, pos, Quaternion.identity, parentHolder.transform);
        }

        if(score % 5 == 0)
        {
            Destroy(collision.gameObject);

            int randomX = Random.Range(100, 1820);
            int randomY = Random.Range(100, 980);
            Vector2 pos = new Vector2(randomX, randomY);
            //RedCoin = Instantiate(redCoin, pos, Quaternion.identity, parentHolder.transform);

            if (score>1)
            {
                StartCoroutine(Destroye_Coin(RedCoin));
                RedCoin = Instantiate(redCoin, pos, Quaternion.identity, parentHolder.transform);
            }

            //RedCoin = Instantiate(redCoin, pos, Quaternion.identity, parentHolder.transform);

            StartCoroutine(Destroye_Coin(RedCoin));
        }

        if(collision.gameObject.tag == "Red-Coin")
        {
            Debug.Log("Loser");
            Destroy(collision.gameObject);

            PlayObj.SetActive(false);
            WinObj.SetActive(true);

            WinScore.text = "" + score;
        }
    }

    public void onClickRestart()
    {
        WinScore.text = "" + score;
         //score = 0;

        SceneManager.LoadScene("Play");

        //PlayObj.SetActive(true);
        //WinObj.SetActive(false);
    }

    IEnumerator Destroye_Coin(GameObject RedCoin)
    {
        yield return new WaitForSeconds(1f);
        Destroy(RedCoin);
    }

    void generateCoins()
    {
        int randomX = Random.Range(100, 1820);
        int randomY = Random.Range(100, 980);
        Vector2 pos = new Vector2(randomX, randomY);
        Instantiate(coin, pos, Quaternion.identity, parentHolder.transform);
    }

    void generateRedCoins()
    {
        int randomX = Random.Range(100, 1820);
        int randomY = Random.Range(100, 980);
        Vector2 pos = new Vector2(randomX, randomY);
        RedCoin = Instantiate(redCoin, pos, Quaternion.identity, parentHolder.transform);
    }

    public void LeftSideDown()
    {
        isGoingLeft = true;
    }
    public void LeftSideUp()
    {
        isGoingLeft = false;
    }

    public void RightSideDown()
    {
        isGoingRight = true;
    }
    public void RightSideUp()
    {
        isGoingRight = false;
    }

    public void UpSideDown()
    {
        isGoingUp = true;
    }
    public void UpSideUp()
    {
        isGoingUp = false;
    }

    public void DownSideDown()
    {
        isGoingDown = true;
    }
    public void DownSideUp()
    {
        isGoingDown = false;
    }
    
    public void onClickSetting()
    {

    }



}
