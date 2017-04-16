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
            batcher.drawLine(start, end, color, thickness);
        }

        public static void drawBox(Batcher batcher, Vector2 topLeft, float width, float height, Color color, float thickness = 1f)
        {
            batcher.drawHollowRect(topLeft, width, height, color, thickness);
        }
    }
}
