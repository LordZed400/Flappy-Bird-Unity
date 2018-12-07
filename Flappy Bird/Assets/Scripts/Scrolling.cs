using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

    [SerializeField] private float scrollSpeed;
    [SerializeField] private bool isMainMenu;
    private Renderer quadRenderer;
    

    void Start() {
        quadRenderer = GetComponent<Renderer>();
    }

    void Update() {
        if(isMainMenu){
            Scroll();
        }else{
            if(GameManager.Instance.GameState()){
                Scroll();
            }
        }
    }

    public void Scroll(){
        // Continuously scroll the image of the ground to simulate Left to Right movement
        Vector2 textureOffset = new Vector2( Time.time * scrollSpeed, 0);
        quadRenderer.material.mainTextureOffset = textureOffset;
    }
	
}
