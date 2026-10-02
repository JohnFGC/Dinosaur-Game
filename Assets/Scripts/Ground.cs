using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer renderer;


    private void Awake(){
        //Initialize
        renderer = GetComponent<MeshRenderer>();
    }

    
    void Update(){
        //Update is called once per frame

        float speed = GameManager.instance.gameSpeed / transform.localScale.x;
        renderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
        //Implement Sidescrolling
    }
}
