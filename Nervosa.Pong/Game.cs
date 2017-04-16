using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Nez;

namespace Nervosa.Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Core
    {
        public Game()
            : base()
        {
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            Window.AllowUserResizing = true;
            createScene();
        }

        void createScene()
        {
            var scene = Scene.createWithDefaultRenderer(Color.Black);

            var ent = scene.createEntity("middleLine");
            ent.addComponent(new MiddleLine());

            var ball = scene.createEntity("ball");
            ball.addComponent(new Ball());

            var positionY = (Screen.height / 2) - (Paddle.HEIGHT / 2);
            var playerPaddle = scene.createEntity("playerPaddle", new Vector2(50, positionY));
            playerPaddle.addComponent(new Paddle());
            // playerPaddle.addComponent(new PaddleComputerAI(ball.getComponent<Ball>()));
            playerPaddle.addComponent(new PlayerMovement());

            var computerPaddle = scene.createEntity("computerPaddle", new Vector2(Screen.width - Paddle.WIDTH - 50, positionY));
            computerPaddle.addComponent(new Paddle());
            computerPaddle.addComponent(new PaddleComputerAI(ball.getComponent<Ball>()));

            var walls = scene.createEntity("walls");
            walls.addComponent(new Walls());

            scene.addEntityProcessor(new BallCollisionSystem(new Matcher().all(typeof(Ball))));

            Window.ClientSizeChanged += onScreenResized;

            Core.scene = scene;
        }

        void onScreenResized(object sender, EventArgs args)
        {
            createScene();
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            base.OnExiting(sender, args);

            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                // Brutal exit...
                // http://community.monogame.net/t/window-freezes-on-exit-for-linux/8391
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
