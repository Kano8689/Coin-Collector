using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tield : MonoBehaviour
{
    float speed = 10f;
    public GameObject coin, parentHolder, redCoin;
    public GameObject PlayObj, LoserObj;
    int score = 0;
    public Text Score, WinScore;
    bool isGoingLeft = false;
    bool isGoingRight = false;
    bool isGoingUp = false;
    bool isGoingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 3; i++)
        {
            int randomX = Random.Range(100, 1820);
            int randomY = Random.Range(100, 980);
            Vector2 pos = new Vector2(randomX, randomY);
            Instantiate(coin, pos, Quaternion.identity, parentHolder.transform);
        }

        InvokeRepeating("generateCoin", 2f, 3f);
        InvokeRepeating("generateRedCoin", 5f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 0, 1);
        if (Input.acceleration.x < -0.1f)
        {
            //isGoingLeft = true;
            float maxLeft = Mathf.Clamp(transform.position.x - speed, 80, Screen.width - 80);
            transform.position = new Vector2(maxLeft, transform.position.y);
            transform.Rotate(0, 0, -1);
        }
        if (Input.acceleration.x > 0.1f)
        {
            //isGoingRight = true;
            float maxRight = Mathf.Clamp(transform.position.x + speed, 80, Screen.width - 80);
            transform.position = new Vector2(maxRight, transform.position.y);
            transform.Rotate(0, 0, 1);
        }
        if (Input.acceleration.y > 0.1f)
        {
            //isGoingUp = true;
            float maxUp = Mathf.Clamp(transform.position.y + speed, 80, Screen.height - 80);
            transform.position = new Vector2(transform.position.x, maxUp);
            transform.Rotate(0, 0, 1);
        }
        if (Input.acceleration.y < -0.1f)
        {
            //isGoingDown = true;
            float maxDown = Mathf.Clamp(transform.position.y - speed, 80, Screen.height - 80);
            transform.position = new Vector2(transform.position.x, maxDown);
            transform.Rotate(0, 0, -1);
        }

        //accelerationMove();
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
            //isGoingRight = true;
            float maxRight = Mathf.Clamp(transform.position.x + speed, 80, Screen.width - 80);
            transform.position = new Vector2(maxRight, transform.position.y);
            transform.Rotate(0, 0, 1);
        }
        if(Input.acceleration.y > 0.1f)
        {
            //isGoingUp = true;
            float maxUp = Mathf.Clamp(transform.position.y + speed, 80, Screen.height - 80);
            transform.position = new Vector2(transform.position.x, maxUp);
            transform.Rotate(0, 0, 1);
        }
        if (Input.acceleration.y < -0.1f)
        {
            //isGoingDown = true;
            float maxDown = Mathf.Clamp(transform.position.y - speed, 80, Screen.height - 80);
            transform.position = new Vector2(transform.position.x, maxDown);
            transform.Rotate(0, 0, -1);
        }
    }
    void generateCoin()
    {
        int randomX = Random.Range(100, 1820);
        int randomY = Random.Range(100, 980);
        Vector2 pos = new Vector2(randomX, randomY);
        Instantiate(coin, pos, Quaternion.identity, parentHolder.transform);
    }
    void generateRedCoin()
    {
        int randomX = Random.Range(100, 1820);
        int randomY = Random.Range(100, 980);
        Vector2 pos = new Vector2(randomX, randomY);
        GameObject g = Instantiate(redCoin, pos, Quaternion.identity, parentHolder.transform);
        StartCoroutine(DestroyeCoin(g));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hello");

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);

            score++;
            Score.text = "" + score;

            int randomX = Random.Range(100, 1820);
            int randomY = Random.Range(100, 980);
            Vector2 pos = new Vector2(randomX, randomY);
            Instantiate(coin, pos, Quaternion.identity, parentHolder.transform);
        }

        if (score % 5 == 0)
        {
            int randomX = Random.Range(100, 1820);
            int randomY = Random.Range(100, 980);
            Vector2 pos = new Vector2(randomX, randomY);
            GameObject g = Instantiate(redCoin, pos, Quaternion.identity, parentHolder.transform);
            StartCoroutine(DestroyeCoin(g));
        }

        if (collision.gameObject.tag == "Red-Coin")
        {
            Debug.Log("Loser");
            Destroy(collision.gameObject);

            WinScore.text = "" + score;

            LoserObj.SetActive(true);
            PlayObj.SetActive(false);
        }
    }

    public void onClickRestart()
    {
        SceneManager.LoadScene("Tield");
    }

    public void onClickSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    IEnumerator DestroyeCoin(GameObject g)
    {
        yield return new WaitForSeconds(3f);
        Destroy(g);
    }
}
