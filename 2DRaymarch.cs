// Recursively march from some arbitrary point along some arbitrary angle
// `> assuming distance to any and all objects in
// `> any arbitrary field of reference can be found via
// `> FindMinimumDistance(position)
// `> Only minor edits needed to extend dimensions any arbitrary amount.
static class 2DRaymarch{
  // Maximum number of steps the ray will be allowed to march.
  internal static int nMaxRepeats;

  internal static void RayMarch(int nPrevious, Vec vPos, float fAngle, ref Ray rMarcher) {
    if (nPrevious == 0) rMarcher.vOrigin = vPos;
    if (nPrevious > nMaxRepeats) return;

    int nMinDistance = (int)FindMinimumDistance(vPos);
    float fNewX = (float)(vPos.X + Math.Cos(fAngle * Math.PI / 180) * nMinDistance);
    float fNewY = (float)(vPos.Y + Math.Sin(fAngle * Math.PI / 180) * nMinDistance);

    rMarcher.vHit.nX = (int)fNewX;
    rMarcher.vHit.nY = (int)fNewY;
    rMarcher.fLength += nMinDistance;
    rMarcher.nSteps++;
    RayMarch(++nPrevious, rMarcher.vHit, fAngle, ref rMarcher);
    }
}

// Store hit results in some format.
 struct Ray {
  internal Vec vOrigin, vHit;
  internal float fLength;
  internal int nSteps;
}

// Store vector of ints in some format.
struct Vec {
  internal int nX, nY;
  
  internal Vec(int nX, int nY) {
    this.nX = nX;
    this.nY = nY;
  }
}

// Naive extension of Vec to three dimensions
// `> for reference.
struct Vec3 : Vec {
  internal int nZ;
  
  internal Vec3(int nX, int nY, int nZ) : base(nX, nY) {
    this.nZ = nZ;
  }
}
