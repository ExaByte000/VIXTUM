using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class FadeOutWithHero : FadeOutDisable
{

    private GameObject camera;

    private void Start()
    {
        camera = GameObject.Find("CinemachineCamera");
        
    }
    public override void DisableGameObject()
    {
        
        GameObject.Find("HeroSprite").GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        base.DisableGameObject();
    }

    public void FixCamera()
    {
        camera.GetComponent<Animator>().enabled = false;
        camera.GetComponent<CinemachinePositionComposer>().Composition.ScreenPosition = new(0, 0.05f);
    }
}
