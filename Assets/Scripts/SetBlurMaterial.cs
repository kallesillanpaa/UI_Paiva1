using UnityEngine;
using UnityEngine.UI;

public class SetBlurMaterial : MonoBehaviour
{
    public Material blurMaterial;
    private void OnEnable()
    {
        GetComponent<Image>().material = blurMaterial;
    }


}
