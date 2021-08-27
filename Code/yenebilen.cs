using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class yenebilen : MonoBehaviour
{
    private Rigidbody2D mybody;
    private float mySpeedX;
    public float speed = 5;
    float sayac;
    public Text sayacText;
    public int can = 3;
    private Animator myAnimator;
    public Text canText;
    public GameObject panelbitti;
    private Vector3 defultlocationscale;
    public int time = 3;
    private Coroutine zaman;
    public GameObject menu;
    bool oyun_dulduruldu = false;
    public GameObject slimcat;
    public Text skor2;
    public GameObject boocat;
    public GameObject fatcat;
    public Text skor3;
    public Text skor4;
    public GameObject donmaSuresi;
    public GameObject effect;
    public GameObject effectZarar;
    public GameObject sesMenusu;
    public Joystick joystick;
    #region menüye dönme
    public void main()
    {
        SceneManager.LoadScene("Scenes/Giris");
        Time.timeScale = 1.0f;
    }
    #endregion
    #region menu acılımı
    public void menuAc() //menü açılımı
    {
        menu.SetActive(true);
        Time.timeScale = 0.0f;

    }
    #endregion
    #region menü kapatma
    public void kapatt() //menü kapatma
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    #endregion
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>(); //fizik
        myAnimator = GetComponent<Animator>(); // animasyon(kedi)
        defultlocationscale = transform.localScale;
      
    }
    void Update()
    {
        mySpeedX = joystick.Horizontal; //hareket
        //Vector2 mouseposition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Vector3 kendipos = new Vector3(transform.position.x, transform.position.y, 0);
        //transform.position = Vector3.MoveTowards(kendipos, new Vector3(mouseposition.x, transform.position.y, 0), Time.deltaTime * speed);
        myAnimator.SetFloat("speed", Mathf.Abs(mySpeedX)); //animasyon
        mybody.velocity = new Vector2(mySpeedX * speed, mybody.velocity.y); 
        if (mySpeedX > 0)
        {
            transform.localScale = new Vector3(-defultlocationscale.x, defultlocationscale.y, defultlocationscale.z);

        }
        else if (mySpeedX < 0)
        {

            transform.localScale = new Vector3(defultlocationscale.x, defultlocationscale.y, defultlocationscale.z);
        }
    }
    #region ses menusu
    public void sesmunusu()
    {
        Time.timeScale = 0.0f;
        sesMenusu.SetActive(true);
    }
    public void sesMenuKapatma()
    {
        Time.timeScale = 1.0f;
        sesMenusu.SetActive(false);

    }

    #endregion
    #region pause
    public void durdurma() // pause resume
    {
        oyun_dulduruldu = !oyun_dulduruldu;
        if (oyun_dulduruldu == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
            menu.SetActive(false);
        }
    }
    #endregion
    #region cıkıs metod
    public void cıkıs() // Quit
    {
        Application.Quit();
    }
    #endregion
    #region restart metod
    public void yenidenoyna() //restart
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Scenes/Cat");

    }
    #endregion
    
    public void OnTriggerEnter2D(Collider2D collision)
    
    {
        #region çarpışma kodları
        if (collision.gameObject.tag == "yeme") //etiket yeme +10 puan
        {
            sayac = sayac + 10;

            sayacText.text = "Score: " + sayac;
            skor2.text = "Score: " + sayac;
            skor3.text = "Score: " + sayac;
            skor4.text = "Score: " + sayac;
            Destroy(collision.gameObject);
            GameObject.Find("yeme").GetComponent<AudioSource>().Play();
            Instantiate(effect, collision.gameObject.transform.position, Quaternion.identity);

        }
       
        if (collision.gameObject.tag == "yanma") //etiket yanma -1 can -10 puan
        {
            can = can - 1;
            canText.text = can.ToString();
            sayac = sayac - 10;
            sayacText.text = "Score: " + sayac;
            skor2.text = "Score: " + sayac;
            skor3.text = "Score: " + sayac;
            skor4.text = "Score: " + sayac;
            Destroy(collision.gameObject);
            GameObject.Find("zarar").GetComponent<AudioSource>().Play();
            Instantiate(effectZarar, collision.gameObject.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "donma")
        {
            StartCoroutine(ExampleCoroutine());
            Destroy(collision.gameObject);
            donmaSuresi.SetActive(true);


        }
        if (collision.gameObject.tag == "yıldız")
        {
            StartCoroutine(hız());
            
            
           
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "yavas")
        {
            StartCoroutine(yavaslatma());
            Destroy(collision.gameObject);
        }
        // if (can == 0)
        //{
        //     panelbitti.SetActive(true);
        //     Time.timeScale = 0.0f;
        // }
        #endregion
        #region skora göre resim 
        if (sayac>0 && sayac<100 && can ==0)
        {
            slimcat.SetActive(true);
            Time.timeScale = 0.0f;
            skor2.text = "Highest Score: " +  PlayerPrefs.GetFloat("Rekor").ToString();

        }
        if (sayac <=0 && can ==0)
        {
            boocat.SetActive(true);
            Time.timeScale = 0.0f;
            skor3.text = "Highest Score: " + PlayerPrefs.GetFloat("Rekor").ToString();
        }
        if (sayac>100 && can ==0)
        {
            fatcat.SetActive(true);
            Time.timeScale = 0.0f;
            skor4.text = "Highest Score: " + PlayerPrefs.GetFloat("Rekor").ToString();
        }
        if (sayac > PlayerPrefs.GetFloat("Rekor"))
        {
            PlayerPrefs.SetFloat("Rekor", sayac);
        }
        
        #endregion
    }
    IEnumerator ExampleCoroutine()
    {
        speed = 0;
        yield return new WaitForSeconds(1.5f);
        speed = 5;
        donmaSuresi.SetActive(false);

    }
    IEnumerator hız()
    {
        var y = GetComponent<TrailRenderer>();
        var z = GetComponent<TrailRenderer>();
        z.startColor = Color.cyan;
        speed = 7;
        y.enabled = true;
        yield return new WaitForSeconds(4f);
        speed = 5;
        y.enabled = false;

    }
    IEnumerator yavaslatma()
    {
        var yy = GetComponent<TrailRenderer>();
        var zz = GetComponent<TrailRenderer>();
        zz.startColor = Color.red;
        speed = 3;
        yy.enabled = true;
        yield return new WaitForSeconds(4f);
        speed = 5;
        yy.enabled = false;
    }
   

}

