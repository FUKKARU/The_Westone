
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PixelizedView : ScriptableRendererFeature
{
    [System.Serializable]
    public class CustomPassSettings 
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
        public int screenHeight = 144;
    }

    [SerializeField] CustomPassSettings settings;
    PassForPixel custompass;

    public override void Create()
    {
        //custompass = new PassForPixel(settings);
    }
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
#if UNITY_EDITOR
        if (renderingData.cameraData.isSceneViewCamera) return;
#endif
        renderer.EnqueuePass(custompass);
    }
}
