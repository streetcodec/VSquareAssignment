using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameLogic : MonoBehaviour
{
    public GameObject balloon;
    public Vector2 initPos;
    public float balloonVel;
    public float balloonVelHorizontal;
    public float spawnGap = 1f;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public PlayFabManager playfab;
    public bool IsOver;
    private bool f = false;
    public float Timer = 20f;
    public Receive Rc;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
        string randomHexColorCode = GenerateRandomHexColorCode();
        // Debug.Log(randomHexColorCode);
        if(Rc.data != "") SetVar();
        //timerText.text = Timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerText == null) 
        {
            
        }
        else
        {
        if(Timer < 0) GameOver();
       if(Rc.data != "") SetVar();
    if(!IsOver)
    {
        Timer -= Time.deltaTime;
        
        timerText.text = ((int)Timer).ToString();
        if(transform.position.y >= 6f) Destroy(gameObject);
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            if (hit.collider != null && hit.collider.GetComponent<Rigidbody2D>() != null)
            {
                Destroy(hit.collider.gameObject);
               
                score++;
            scoreText.text = "Score : " + score.ToString();
            }
            
         }
      }
    }
        
        
    }
    IEnumerator SpawnObjects()
    {
             yield return new WaitForSeconds(spawnGap);
             int x = Random.Range(-10, 11);
             initPos = new Vector2(x,-7);
             GameObject newBalloon = Instantiate(balloon, initPos, Quaternion.identity);
            Rigidbody2D rb = newBalloon.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(balloonVelHorizontal, balloonVel);
            
           
        
    }
    private string GenerateRandomHexColorCode()
    {
        // Generate random values for red, green, and blue components
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        // Convert the values to hexadecimal representation
        string hexColorCode = ColorUtility.ToHtmlStringRGB(new Color(r, g, b));
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(r,g,b) ;
        
        return hexColorCode;
    }
    void GameOver()
    {
        
        IsOver = true;
        // if(!f) playfab.UpdateLeaderboard(score);
        if(!f)SceneManager.LoadScene("EndScene");
        f = true;

    }
    void SetVar()
    {
        if(int.Parse(Rc.data) <= 9) balloonVel = int.Parse(Rc.data);
        else if (int.Parse(Rc.data) >=10 && int.Parse(Rc.data)<=90) balloonVelHorizontal = int.Parse(Rc.data)/10; 
        
    }
}
