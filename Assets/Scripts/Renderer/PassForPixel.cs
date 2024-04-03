
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PassForPixel : ScriptableRenderPass
{
    PixelizedView.CustomPassSettings settings;

    RenderTargetIdentifier colorBuffer, pixelBuffer;
    int pixelBufferID = Shader.PropertyToID("_PixelBuffer");

    Material material;
    int pixelScreenHeight, pixelScreenWidth;

    public PassForPixel(PixelizedView.CustomPassSettings settings)
    {
        this.settings = settings;
        this.renderPassEvent = settings.renderPassEvent;
        if (material == null) material = CoreUtils.CreateEngineMaterial("Hidden/Pixelize");
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        throw new System.NotImplementedException();
    }
}
