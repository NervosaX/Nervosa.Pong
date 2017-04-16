using System;
using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    public class BounceableSurface : BoxCollider
    {
        public BounceableSurface()
        {
        }

        public BounceableSurface(Rectangle rect)
            : base(rect)
        {

        }
    }
}
