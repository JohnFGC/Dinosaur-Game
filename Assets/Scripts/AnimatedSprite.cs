using UnityEngine;

public class AnimatedSprite : MonoBehaviour {
    public Sprite[] sprites;
    private SpriteRenderer renderer;
    private int frameIndex;

    private void Awake(){
        //Initialize
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable(){
        //Initial Animate Call
        Invoke(nameof(Animate), 0f);
    }

    private void OnDisable(){
        //Stops animation after game end
        CancelInvoke();
    }

    private void Animate(){
        //Cycles through sprites to animate
        frameIndex++;
        
        if (frameIndex >= sprites.Length){
            //Resets after iterating through animation, looping it
            frameIndex = 0;
        }

        if (frameIndex >= 0 && frameIndex < sprites.Length){
            //Safety check in case Sprites[] is empty
            renderer.sprite = sprites[frameIndex];
        }

        Invoke(nameof(Animate), 1f / GameManager.instance.gameSpeed);
        //Increases animation speed as game continues
    }
}
