using UnityEngine;

public class FadeOutWithHero : FadeOutDisable
{
    public override void DisableGameObject()
    {
        GameObject.Find("HeroSprite").GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        base.DisableGameObject();
    }
}
