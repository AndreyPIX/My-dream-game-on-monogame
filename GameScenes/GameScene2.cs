﻿
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using StrategyRTS.Controle;
using StrategyRTS.GameObjects;
using Microsoft.Xna.Framework.Graphics;

namespace StrategyRTS.GameScenes
{
    public class GameScene2 : GameSceneBase
    {
        GameObject map;
        public GameScene2(GameEngine engine, GraphicsDeviceManager graphics) : base(engine, graphics)
        {
            
        }
        public override void Initialize()
        {
            map = new GameObject();

            
        }
        public override void LoadContent(ContentManager content)
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
