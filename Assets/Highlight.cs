using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Highlight : MonoBehaviour
{
    public Material mat_Hover = null;
    public Material mat_Highlight = null;

    private Material mat_Original = null;
    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabObject = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mat_Original = meshRenderer.material;
        grabObject = GetComponent<XRGrabInteractable>();

        grabObject.onActivate.AddListener(SetHighlight);
        grabObject.onDeactivate.AddListener(SetOriginal);
        grabObject.onHoverEnter.AddListener(SetHover);
        grabObject.onHoverExit.AddListener(SetHoverOriginal);
    }

    private void OnDestroy()
    {
        grabObject.onActivate.RemoveListener(SetHighlight);
        grabObject.onDeactivate.RemoveListener(SetOriginal);
        grabObject.onHoverEnter.RemoveListener(SetHover);
        grabObject.onHoverExit.RemoveListener(SetHoverOriginal);
    }

    private void SetHover(XRBaseInteractor arg0)
    {
        meshRenderer.material = mat_Hover;
    }
    private void SetHoverOriginal(XRBaseInteractor arg0)
    {
        meshRenderer.material = mat_Original;
    }
    private void SetOriginal(XRBaseInteractor arg0)
    {
        meshRenderer.material = mat_Original;
    }

    private void SetHighlight(XRBaseInteractor arg0)
    {
        meshRenderer.material = mat_Highlight;
    }
}
