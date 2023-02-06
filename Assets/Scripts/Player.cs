using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigid;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI heathTxt;
    public TextMeshProUGUI BulletTxt;
    
    public float speed;
    public float jumpPower;
    public bool isJumping;
    public float inputAxis;

    public bool Shooting;
    private int currentScore = 0;
    private int maxHealth = 10;
    private int maxBullet = 50;
    private int currentBullet = 10 ;
    private int currentHeath;
    public HealthBar healthBar;
    public bool isRight;

    private void Awake()
    {
        Debug.Log("Awake");

    }
    // Start is called before the first frame update
 
    private void OnEnable()
    {
        Debug.Log("OnEnable");

    }

    void Start()
    {
        currentHeath = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        heathTxt.SetText(currentHeath.ToString());

        currentBullet = 10;
        BulletTxt.SetText(currentBullet.ToString());
        Shooting = false;
    }

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    public float axis = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && !Shooting && currentBullet >0)
        {
            var bullet = Instantiate(bulletPrefab, firePoint.transform.position, bulletPrefab.transform.rotation);
            
            
            // tao ra tu vi tri firepoint
            Bullet bul = bullet.GetComponent<Bullet>();
            bul.SetRotate(isRight);

            bul.OnTrigger += AddScore; // Set event cho Action Ontrigger
            currentBullet -= 1;
            BulletTxt.SetText(currentBullet.ToString());
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJumping)
        {
            rigid.AddForce(Vector2.up * jumpPower);
            isJumping = false;
        }
        this.inputAxis = Input.GetAxis("Horizontal");
        // Di chuyen theo luc
        //rigid.AddForce(Vector2.right * this.inputAxis * speed * Time.deltaTime);

        // Di chuyen theo vi tri
        transform.Translate(Vector2.right * Time.deltaTime * inputAxis * speed);
        if (inputAxis != 0)
            axis = inputAxis;

        isRight = this.axis > 0 ? true : false;

        Flip(isRight);

    }
    private void Flip(bool value)
    {
        if (value)
            this.transform.localScale = new Vector2(5, 5);
        else
            this.transform.localScale = new Vector2(-5, 5);

    }
    private void FixedUpdate()
    {
        
    }
    private void LateUpdate()
    {
        
    }
    private void OnDisable()
    {
        
    }
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = true;
       // ham tru mau
        if (collision.collider.CompareTag("Trap"))
        {
            TakeDamage (1);
            rigid.AddForce(new Vector2(-10, 10) * 30);
           
            heathTxt.SetText(currentHeath.ToString());
            if (currentHeath <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.collider.CompareTag("Push"))
        {
            rigid.AddForce(new Vector2(0, 35) * 30);
        }
        
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(3);
            
            //rigid.AddForce(new Vector2(-10, 10) * 30);
            heathTxt.SetText(currentHeath.ToString());
            if (currentHeath <= 0)
            {
                Destroy(this.gameObject);
            }
           
        }
        if(collision.collider.CompareTag("Boss"))

        {
            TakeDamage(5);
            heathTxt.SetText(currentHeath.ToString());
            if (currentHeath <= 0)
            {
                Destroy(this.gameObject);
            }
        }
     

    }
   
    void TakeDamage(int dmg)
    {
        currentHeath -= dmg;

        healthBar.SetHealth(currentHeath);
    }
    //hàm + dan
    void TakeBullet (int bull)
    {
        currentBullet += bull;
        if(currentBullet>= 50)
        {
            currentBullet = maxBullet;
        }
        BulletTxt.SetText(currentBullet.ToString());
    }

    // Ham cong diem
   public void AddScore(int score)
    {
        this.currentScore += score;
        scoreTxt.SetText(currentScore.ToString());
    }

    // ham cong mau 
    void TakeBuff(int Healer)
    {
        currentHeath += Healer;
        if(currentHeath >= 10)
        {
            currentHeath = maxHealth;
        }
        healthBar.SetHealth(currentHeath);
        heathTxt.SetText(currentHeath.ToString());

    }
   
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Item"))
        {
            Item item = col.GetComponent<Item>();
            Destroy(col.gameObject);
            AddScore(item.CollectItem());
        }
        if (col.CompareTag("Buff"))
        {

            Buff buff = col.GetComponent<Buff>();
            Destroy(col.gameObject);
            TakeBuff(buff.CollectBuff());
        }
        
       if(col.CompareTag("Enemy"))
        {
            Enemy ene = col.GetComponent<Enemy>();
            Destroy(col.gameObject);
            AddScore(ene.CollectEnemy());
        }
       
        if (col.CompareTag("Bullet"))
        {
            Bullet bul = col.GetComponent<Bullet>();
            Destroy(col.gameObject);
            TakeBullet(bul.CollectBullet());
        }
      

    }
}
