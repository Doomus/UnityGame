using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionBlur : MonoBehaviour
{
    
    public Material postprocessMaterial;
    public float blurSize = 0;
    // Start is called before the first frame update
    void Start()
    {
        blurSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalFloat("_BlurSize", blurSize);
    }

   void OnRenderImage(RenderTexture source, RenderTexture destination)
   {
       //draws the pixels from the source texture to the destination texture
       var temporaryTexture = RenderTexture.GetTemporary(source.width, source.height);
       Graphics.Blit(source, temporaryTexture, postprocessMaterial, 0);
       Graphics.Blit(temporaryTexture, destination, postprocessMaterial, 1);
       RenderTexture.ReleaseTemporary(temporaryTexture);
   }


}
