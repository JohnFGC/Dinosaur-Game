using UnityEngine;

public class Enemy : MonoBehaviour {

    private float leftEdge;

    private void Start(){
        //Start is called once before the first execution of Update after the MonoBehaviour is created
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5f;
    }

    private void Update(){
        //Moves enemy to the left
        transform.position += Vector3.left * GameManager.instance.gameSpeed * Time.deltaTime;

        if (transform.position.x < leftEdge) {
            //Destroys enemy if offscreen to save space
            Destroy(gameObject);
        }
    }
}
