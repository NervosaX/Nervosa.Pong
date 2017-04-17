using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace Nervosa.Pong
{
    public class MiddleLine : RenderableComponent
    {
        public override float width { get { return 1; } }
        public override float height { get { return Screen.height; } }

        public override void render(Graphics graphics, Camera camera)
        {
            var lineHeight = 6;
            var times = (int)Math.Floor((double)(Screen.height / lineHeight));

            foreach (int num in Enumerable.Range(0, times))
            {
                if (num % 2 == 0)
                {
                    var position = num * lineHeight;

                    graphics.batcher.drawLine(
                        new Vector2(Screen.center.X, position),
                        new Vector2(Screen.center.X, position + lineHeight),
                        Color.Gray);
                }
            }
        }
    }
}
