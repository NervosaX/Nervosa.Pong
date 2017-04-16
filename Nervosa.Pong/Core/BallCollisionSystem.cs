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
                if (bounce != null) {
                    // Calculate a reflection vector and apply it to the ball
                    ball.velocity = -2 * Vector2.Dot(result.normal, ball.velocity) * result.normal + ball.velocity;
                }
            }
        }
    }
}
