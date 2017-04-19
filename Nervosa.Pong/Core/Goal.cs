using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    public class Goal : RenderableComponent
    {
        public int score { get; set; } = 0;
        public override float width { get { return 20; } }
        public override float height { get { return Screen.height; } }
        NezSpriteFont font;

        public Goal(NezSpriteFont font)
        {
            this.font = font;
        }

        public override void onAddedToEntity()
        {
            entity.addComponent(new BoxCollider());
        }

        public override void render(Graphics graphics, Camera camera)
        {
            var position = new Vector2(100, 100);
            if (entity.position.X > Screen.width / 2)
            {
                position.X = Screen.width - 100 - font.measureString(score.ToString()).X;
            }

            graphics.batcher.drawString(font, score.ToString(), position, Color.Gray);
        }
    }
}
