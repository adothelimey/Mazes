using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended.Input;
using System.Runtime.CompilerServices;
using MonoMaze.Models;
using System.Xml;

namespace MonoMaze
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private OrthographicCamera _camera;
        private ViewportAdapter _viewportAdapter;

        private Tilesheet tileSheet;
        

        private int screenWidth = 1920;
        private int screenHeight = 1080;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ApplyChanges();
            _viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, screenWidth, screenHeight);
            _camera = new OrthographicCamera(_viewportAdapter);
            _camera.MinimumZoom = 0.25f; 
            _camera.MaximumZoom = 1.25f;
            _camera.Zoom = 1;

            tileSheet = new Tilesheet();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tileSheet.Texture = Content.Load<Texture2D>("medievalRTS_spritesheet");
            tileSheet.Atlas = Content.Load<TilesheetAtlas>("medievalRTS_spritesheetAtlas");
        }

        protected override void Update(GameTime gameTime)
        {
           var keyboardState = KeyboardExtended.GetState();
           var mouseState = MouseExtended.GetState();

            if (keyboardState.WasKeyJustDown(Keys.Escape)){
                Exit();
            }

            if (mouseState.IsButtonDown(MouseButton.Right)){
                Vector2 delta = mouseState.DeltaPosition.ToVector2() * new Vector2(0.5f,0.5f);
                _camera.Move(delta);
            }

            if (mouseState.DeltaScrollWheelValue != 0)
            {
                _camera.Zoom = MathHelper.Clamp(_camera.Zoom + mouseState.DeltaScrollWheelValue * 0.001f, _camera.MinimumZoom, _camera.MaximumZoom);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());

            _spriteBatch.Draw(
                texture:tileSheet.Texture, 
                position: new Vector2(0,0),
                sourceRectangle: tileSheet.Atlas.SubTexture[69].GetRectangle(),
                color: Color.White,
                rotation: 0f,
                origin: Vector2.Zero,
                scale: 1f,
                effects: SpriteEffects.None,
                layerDepth: 0f);

            //_spriteBatch.Draw(tileSheet.Texture, Vector2.Zero, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}