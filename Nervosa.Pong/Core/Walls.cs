using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    public class Walls : Component
    {
        public override void onAddedToEntity()
        {
            var wallHeight = 20;
            var size = new Point(Screen.width, wallHeight);
            entity.addComponent(new BounceableSurface(new Rectangle(new Point(0, 0), size)));
            entity.addComponent(new BounceableSurface(new Rectangle(new Point(0, Screen.height - wallHeight), size)));

            // TODO: Remove me
            // entity.addComponent(new BounceableSurface(new Rectangle(new Point(0, 0), new Point(20, Screen.height))));
            // entity.addComponent(new BounceableSurface(new Rectangle(new Point(Screen.width - wallHeight, 0), new Point(20, Screen.height))));
        }
    }
}
