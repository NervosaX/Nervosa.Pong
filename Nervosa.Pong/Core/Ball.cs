using System;
using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    public class Ball : RenderableComponent, IUpdatable
    {
        public static float MAX_SPEED = 700f;

        public Vector2 velocity;
        public float speed = 500f;
        public override float width { get { return 20; } }
        public override float height { get { return width; } }
        public BoxCollider collider;

        public void update()
        {
            entity.position += velocity * speed * Time.deltaTime;
        }

        public override void onAddedToEntity()
        {
            color = Color.White;
            entity.position = new Vector2(Screen.width / 2 - (width / 2), Screen.height / 2 - (height / 2));
            collider = new BoxCollider();
            entity.addComponent(collider);
            velocity = new Vector2(-1, 0.5f);
        }

        public override void render(Graphics graphics, Camera camera)
        {
            graphics.batcher.drawCircle(entity.position, width / 2, this.color);
        }
    }
}
