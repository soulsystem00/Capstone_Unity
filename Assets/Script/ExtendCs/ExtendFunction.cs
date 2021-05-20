using UnityEngine;
using UnityEngine.U2D;

public class ExtendFunctionAttribute : GHSingletonAttribute
{
    public override string OrigianlPath { get { return "ExtendFunction"; } }
}
public class ExtendFunction : GHSingleton<ExtendFunction, ExtendFunctionAttribute>
{
    public SpriteAtlas mySpriteAtlas;

    private void Start()
    {
        mySpriteAtlas = Resources.Load<SpriteAtlas>("SpriteAtlas");
    }

    public Sprite SpriteReturn(string spriteName)
    {
        return mySpriteAtlas.GetSprite(spriteName);
    }
}
