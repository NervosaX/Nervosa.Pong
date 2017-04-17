using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    public class Paddle : RenderableComponent
    {
        public static float WIDTH = 15;
        public static float HEIGHT = 250;

        public float speed { get; set; }
        public override float width { get { return Paddle.WIDTH; } }
        public override float height { get { return Paddle.HEIGHT; } }

        public Paddle()
        {
            speed = 500f;
        }


        public override void onAddedToEntity()
        {
            entity.addComponent(new BounceableSurface());
        }

        public override void render(Graphics graphics, Camera camera)
        {
            graphics.batcher.drawHollowRect(
                this.entity.position,
                width,
                height,
                Color.Khaki);
        }
    }
}
