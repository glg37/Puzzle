using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirarSurface : MonoBehaviour
{

    [SerializeField] SurfaceEffector2D surfaceEffector;
   public void Virar()
   {
        surfaceEffector.speed = surfaceEffector.speed * -1;
   }
}
