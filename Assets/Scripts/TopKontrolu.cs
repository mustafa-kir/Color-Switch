using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopKontrolu : MonoBehaviour {

    public string mevcutRenk;
    private Color topunRengi;
    public float ziplamaKuvveti = 15f;
    public Color turkuaz;
    public Color sari;
    public Color mor;
    public Color kirmizi;
    public Text skorYazisi;
    public static int skor = 0;
    public GameObject[] cemberler;
    public GameObject RenkTekeri;
    public GameObject baslagicYazisi;
    
    
	// Use this for initialization
	void Start () {
        RastgeleRenkBelirle();
        skorYazisi.text = skor.ToString();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * ziplamaKuvveti;
            baslagicYazisi.gameObject.GetComponent<Text>().text = "";
            if (gameObject.transform.position.y> (-3.5))
            {
                GetComponent<CircleCollider2D>().isTrigger = true;
                

            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SkoruArttir")
        {
            skor += 50;
            skorYazisi.text = skor.ToString();
            int rastgeleCember = Random.Range(0, 2);
           Instantiate(cemberler[rastgeleCember], new Vector3(transform.position.x, transform.position.y + 12f, transform.position.z), transform.rotation);
            Destroy(collision.gameObject);
        }
        if(collision.tag == "RenkTekeri")
        {
            RastgeleRenkBelirle();
            Destroy(collision.gameObject);
            if (Random.Range(0,3) == 1)
            {
                Instantiate(RenkTekeri, new Vector3(transform.position.x, transform.position.y + 12f, transform.position.z), transform.rotation);

            }
            return;
        }
        if(collision.tag != mevcutRenk  && collision.tag != "SkoruArttir" && collision.tag != "Zemin" && collision.tag == "Finish")
        {
            //SceneManager.LoadScene(0);
            skor = 0;
            skorYazisi.text = skor.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Topun Ölmesi");
        }
        
    }

    void RastgeleRenkBelirle()
    {
        int rastgeleSayi = Random.Range(0, 4);
        Debug.Log(rastgeleSayi);
        switch (rastgeleSayi)
        {
            case 0 : mevcutRenk = "Turkuaz";
                topunRengi = turkuaz;
                break;
            case 1: mevcutRenk = "Sarı";
                topunRengi = sari;
               break;
            case 2: mevcutRenk = "Kırmızı";
                topunRengi = kirmizi;
                break;
            case 3: mevcutRenk = "Mor";
                topunRengi = mor;
                break;
        }
        GetComponent<SpriteRenderer>().color = topunRengi;
    }
}
