using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace Nervosa.Pong
{
    public class Ball : RenderableComponent, IUpdatable
    {
        public static float ORIGINAL_SPEED = 500f;
        public static float MAX_SPEED = 700f;
        public static Vector2 ORIGINAL_VELOCITY = new Vector2(-1, 0.5f);

        public Vector2 velocity = ORIGINAL_VELOCITY;
        public float speed = ORIGINAL_SPEED;
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
        }

        public override void render(Graphics graphics, Camera camera)
        {
            graphics.batcher.drawCircle(entity.position, width / 2, this.color);
        }
    }
}
