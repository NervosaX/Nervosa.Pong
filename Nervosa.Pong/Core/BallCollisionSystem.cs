using System;
using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    public class BallCollisionSystem : EntityProcessingSystem
    {
        public BallCollisionSystem(Matcher matcher)
            : base(matcher)
        {
        }

        public override void process(Entity entity)
        {
            var ball = entity.getComponent<Ball>();

            CollisionResult result;
            if (ball.collider.collidesWithAny(out result))
            {
                var bounce = result.collider.entity.getComponent<BounceableSurface>();
                if (bounce != null)
                {
                    var newVelocity = ball.velocity;
                    // Calculate a reflection vector and apply it to the ball
                    newVelocity = -2 * Vector2.Dot(result.normal, ball.velocity) * result.normal + ball.velocity;

                    ball.velocity = newVelocity;
                    ball.entity.position += (newVelocity * 10);

                    // If a paddle...
                    var paddle = result.collider.entity.getComponent<Paddle>();
                    if (paddle != null)
                    {
                        var isMinus = ball.velocity.Y < 0;
                        var distanceFromMiddle = Math.Abs((paddle.height / 2) - Math.Abs(bounce.entity.position.Y - ball.entity.position.Y));

                        ball.velocity.Y = Math.Abs(distanceFromMiddle / (paddle.height / 2));

                        // Don't let the ball become too straight
                        if (ball.velocity.Y < 0.7f) {
                            ball.velocity.Y = 0.7f;
                        }

                        ball.speed = (ball.velocity.Y) * Ball.MAX_SPEED;

                        // Keep it moving in the right direction
                        if (isMinus)
                        {
                            ball.velocity.Y *= -1;
                        }
                    }
                }
            }
        }
    }
}
