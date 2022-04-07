using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    float score;

    [SerializeField] bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;
    SceneLoader sceneloader;

    public Text ScoreTxt;
    
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        sceneloader = FindObjectOfType<SceneLoader>();
        score = 0;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(isGrounded == true)
            {
                Vector3 position = this.transform.position;
                position.x--;
                this.transform.position = position;
                isGrounded = false;
            }

        }
                 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(isGrounded == true)
            {
                Vector3 position = this.transform.position;
                position.x++;
                this.transform.position = position;
                isGrounded = false;
            }
        }
                 
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(isGrounded == true)
            {
                Vector3 position = this.transform.position;
                position.x++;
                this.transform.position = position;
                isGrounded = false;
            }
        }
                 
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(isGrounded == true)
            {
                Vector3 position = this.transform.position;
                position.y--;
                this.transform.position = position;
                isGrounded = false;
            }
        }

        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "SCORE : " + score.ToString("F");
        }

    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
           if(isGrounded == false)
           {
               isGrounded = true;
           }
        }
   
        if(collision.gameObject.CompareTag("spike"))
        {
           isAlive = false;
           sceneloader.LoadNextScene();
        }
    }
}

