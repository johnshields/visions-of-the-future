using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Zoom
{
    void ZoomIn (Camera cam, float delta, float neerZoom_limit);
    void ZoomOut (Camera cam, float delta, float farZoom_limit);
}
