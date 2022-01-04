using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private Animator anim;
    private static GameObject Instance;

   

    // Start is called before the first frame update
    void Start()
    {

        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x,y,0);

        if(moveDelta.x > 0){
            transform.localScale = Vector3.one;
        }else if(moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));
        if(hit.collider == null){

            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
       
       hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));
        if(hit.collider == null){

            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        
    }

    /*void Awake()
    {
        if (Instance == null)
        {
            Instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/

    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(moveDelta.x));

    }


}