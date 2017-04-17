using System;
using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    public class PaddleComputerAI : Component, IUpdatable
    {
        Ball ball;

        public PaddleComputerAI(Ball ball)
        {
            this.ball = ball;
        }

        public void update()
        {
            var paddle = entity.getComponent<Paddle>();
            var vec = Vector2.Zero;
            vec.Y = (paddle.entity.position.Y + Paddle.HEIGHT / 2) < ball.entity.position.Y ? 1f : -1f;

            var newPosition = paddle.entity.position + (vec * paddle.speed) * Time.deltaTime;

            if (newPosition.Y > 20 && newPosition.Y < Screen.height - Paddle.HEIGHT - 20) {
              paddle.entity.position = newPosition;
            }
        }
    }
}
