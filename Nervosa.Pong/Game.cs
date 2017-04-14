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

            var playerPaddle = scene.createEntity("playerPaddle");
            playerPaddle.addComponent(new Paddle(PaddleType.PLAYER));

            var computerPaddle = scene.createEntity("computerPaddle");
            computerPaddle.addComponent(new Paddle(PaddleType.COMPUTER));

            var ball = scene.createEntity("ball");
            ball.addComponent(new Ball());

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
