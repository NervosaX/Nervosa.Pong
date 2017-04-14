using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    public enum PaddleType
    {
        PLAYER,
        COMPUTER
    }

    public class Paddle : RenderableComponent
    {
        public PaddleType type;
        public float speed { get { return 450f; } }
        public override float width { get { return 15; } }
        public override float height { get { return 250; } }

        public Paddle(PaddleType type)
        {
            this.type = type;
        }

        public override void onAddedToEntity()
        {
            var positionY = (Screen.height / 2) - (height / 2);
            if (type == PaddleType.PLAYER)
            {
                this.entity.position = new Vector2(50, positionY);
                this.entity.addComponent(new PlayerMovement());
            }
            else
            {
                this.entity.position = new Vector2(Screen.width - width - 50, positionY);
            }
        }

        public override void render(Graphics graphics, Camera camera)
        {
            Draw.drawBox(graphics.batcher,
                this.entity.position,
                width,
                height,
                Color.Khaki);
        }
    }
}
