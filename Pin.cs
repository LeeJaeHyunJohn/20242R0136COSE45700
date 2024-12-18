using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]

    private float moveSpeed = 10f;

    private bool isPinned=false;
    private bool isLaunched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(isPinned==false && isLaunched == true){
        transform.position +=Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        isPinned = true;
        if(other.gameObject.tag == "Target"){
            //GameObject childObject = transform.Find("Square").gameObject;
            GameObject childObject = transform.GetChild(0).gameObject;
            SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>();
            childSprite.enabled = true;
            transform.SetParent(other.gameObject.transform);

            GameManager.instance.DecreaseGoal();
        } else if (other.gameObject.tag=="Pin"){
            GameManager.instance.SetGameOver(false);
        } else if (other.gameObject.tag == "Obstacle") // 장애물과 충돌했을 때
    {
        GameManager.instance.SetGameOver(false); // 게임 종료
    }
    }

    public void Launch(){
        isLaunched=true;
    }
}
