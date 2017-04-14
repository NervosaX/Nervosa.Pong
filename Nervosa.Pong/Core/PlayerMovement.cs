using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    public class PlayerMovement : Component, IUpdatable
    {
        public void update()
        {
            var paddle = this.getComponent<Paddle>();
            var moveDir = Vector2.Zero;
            var padding = 20;

            if (Input.isKeyDown(Keys.Up) && entity.position.Y >= padding)
                moveDir.Y = -1f;
            else if (Input.isKeyDown(Keys.Down) && entity.position.Y <= Screen.height - paddle.height - padding)
                moveDir.Y = 1f;

            entity.position += moveDir * paddle.speed * Time.deltaTime;
        }
    }
}
