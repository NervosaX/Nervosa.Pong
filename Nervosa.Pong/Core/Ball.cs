using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    public class Ball : RenderableComponent
    {
        public override float width { get { return 20; } }
        public override float height { get { return width; } }

        public override void onAddedToEntity()
        {
            this.entity.position = new Vector2(Screen.width / 2 - (width  / 2), Screen.height / 2 - (height / 2));
        }

        public override void render(Graphics graphics, Camera camera)
        {
            Draw.drawBox(graphics.batcher, this.entity.position, width, height, Color.White);
        }
    }
}
