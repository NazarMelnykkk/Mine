using System.Threading.Tasks;
using UnityEngine;

public class FlashEffect 
{
    private Material _whiteMaterial;
    private float _restoreDefaultMaterialTime = 0.2f;

    private Material _defaultMaterial;
    private SpriteHolder _spriteHolder;

    public FlashEffect(SpriteHolder spriteHolder , Material whiteMaterial )
    {
        _spriteHolder = spriteHolder;
        _whiteMaterial = whiteMaterial;

        foreach ( SpriteRenderer mat in spriteHolder.GetSprites())
        {
            _defaultMaterial = mat.material;
            break;
        }
    }


    public async void Flash()
    {
        foreach (SpriteRenderer mat in _spriteHolder.GetSprites())
        {
            mat.material = _whiteMaterial;
        }

        await Task.Delay((int)(_restoreDefaultMaterialTime * 1000));

        foreach (SpriteRenderer mat in _spriteHolder.GetSprites())
        {
            mat.material = _defaultMaterial;
        }
    }
}
