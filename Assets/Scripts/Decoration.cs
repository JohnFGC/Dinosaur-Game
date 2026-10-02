using UnityEngine;

public class Decoration : MonoBehaviour {

    private float leftEdge;

    private void Start(){
        //Start is called once before the first execution of Update after the MonoBehaviour is created
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 5f;
    }

    private void Update(){
        //Moves decoration to the left
        transform.position += Vector3.left * GameManager.instance.gameSpeed * Time.deltaTime * 0.5f;

        if (transform.position.x < leftEdge) {
            //Destroys decoration if offscreen to save space
            Destroy(gameObject);
        }
    }
}