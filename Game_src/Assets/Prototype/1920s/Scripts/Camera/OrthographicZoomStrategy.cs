using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicZoomStrategy : Zoom

{
   public void ZoomIn(Camera cam, float delta, float nearZoom_limit)
   {
       if (cam.orthographicSize == nearZoom_limit)
       return;
       cam.orthographicSize = Mathf.Max(cam.orthographicSize - delta, nearZoom_limit);
   }

   public void ZoomOut(Camera cam, float delta, float nearZoom_limit)
   {
       if (cam.orthographicSize == nearZoom_limit)
       return;
       cam.orthographicSize = Mathf.Max(cam.orthographicSize - delta, nearZoom_limit);
   }
}
