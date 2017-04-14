using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace Nervosa.Pong
{
    public static class Draw
    {
        public static void drawLine(Batcher batcher, Vector2 start, Vector2 end, Color color, float thickness = 1f)
        {
            var delta = end - start;
            var angle = (float)Math.Atan2(delta.Y, delta.X);
            batcher.draw(Graphics.instance.pixelTexture, start,
                Graphics.instance.pixelTexture.sourceRect, color, angle, new Vector2(0, 0.5f),
                new Vector2(delta.Length(), thickness), SpriteEffects.None, 1.0f);
        }

        public static void drawBox(Batcher batcher, Vector2 topLeft, float width, float height, Color color, float thickness = 1f)
        {
            var topRight = new Vector2(topLeft.X + width, topLeft.Y);
            var bottomRight = new Vector2(topRight.X, topRight.Y + height);
            var bottomLeft = new Vector2(topLeft.X, topLeft.Y + height);

            drawLine(batcher, topLeft, topRight, color);
            drawLine(batcher, topRight, bottomRight, color);
            drawLine(batcher, bottomRight, bottomLeft, color);
            drawLine(batcher, bottomLeft, topLeft, color);
        }
    }
}
