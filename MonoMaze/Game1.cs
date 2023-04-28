using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended.Input;
using System.Runtime.CompilerServices;
using MonoMaze.Models;
using System.Xml;
using MonoGame.Extended.BitmapFonts;
using TheGrid;
using System.Linq;
using SharpDX.Direct3D9;
using TheGrid.Mazes.Algorithms;

namespace MonoMaze
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private OrthographicCamera _camera;
        private ViewportAdapter _viewportAdapter;

        private Tilesheet tileSheet;
        private SpriteFont font;

        private int screenWidth = 1080;
        private int screenHeight = 720;

        Grid? grid { get; set; }
        MazeSettings currentMazeSettings = new MazeSettings { CellHeight = 16, CellWidth = 16, NumberOfColumns = 8, NumberOfRows = 8};

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

            grid = new Grid(currentMazeSettings.NumberOfRows, currentMazeSettings.NumberOfColumns);

            var bt = new Sidewinder();
            bt.ExecuteOn(grid);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tileSheet.Texture = Content.Load<Texture2D>("medievalRTS_spritesheet");
            tileSheet.Atlas = Content.Load<TilesheetAtlas>("medievalRTS_spritesheetAtlas");

            font = Content.Load<SpriteFont>("mazefont");
        }

        private int textureAtlasIndex = 0;
        protected override void Update(GameTime gameTime)
        {
           var keyboardState = KeyboardExtended.GetState();
           var mouseState = MouseExtended.GetState();

            if (keyboardState.WasKeyJustDown(Keys.Escape)){
                Exit();
            }

            if (mouseState.IsButtonDown(MouseButton.Middle)){
                Vector2 delta = mouseState.DeltaPosition.ToVector2() * new Vector2(0.5f,0.5f);
                _camera.Move(delta);
            }

            if (keyboardState.WasKeyJustDown(Keys.Space))
            {
                textureAtlasIndex += 1;
                grid = new Grid(currentMazeSettings.NumberOfRows, currentMazeSettings.NumberOfColumns);

                var bt = new AldousBroder();
                bt.ExecuteOn(grid);
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



            if (grid != null)
            {
                for (var x = 0; x < grid.Columns; x++)
                {
                    for (var y = 0; y < grid.Rows; y++)
                    {
                        AtlasItem texture = null;

                        var cell = grid.GetCellAt(x, y);
                        if (!cell.HasLinkedNeighbourInDirection(Direction.North) && !cell.HasLinkedNeighbourInDirection(Direction.East) && !cell.HasLinkedNeighbourInDirection(Direction.South) && !cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_48.png").SingleOrDefault();
                        }

                        if (!cell.HasLinkedNeighbourInDirection(Direction.North) && !cell.HasLinkedNeighbourInDirection(Direction.East) && !cell.HasLinkedNeighbourInDirection(Direction.South) && cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_19.png").SingleOrDefault();
                        }
                        else if (!cell.HasLinkedNeighbourInDirection(Direction.North) && !cell.HasLinkedNeighbourInDirection(Direction.East) && cell.HasLinkedNeighbourInDirection(Direction.South) && !cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_35.png").SingleOrDefault();
                        }
                        else if (!cell.HasLinkedNeighbourInDirection(Direction.North) && cell.HasLinkedNeighbourInDirection(Direction.East) && !cell.HasLinkedNeighbourInDirection(Direction.South) && !cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_33.png").SingleOrDefault();
                        }
                        else if (cell.HasLinkedNeighbourInDirection(Direction.North) && !cell.HasLinkedNeighbourInDirection(Direction.East) && !cell.HasLinkedNeighbourInDirection(Direction.South) && !cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_34.png").SingleOrDefault();
                        }


                        if (cell.HasLinkedNeighbourInDirection(Direction.North) && cell.HasLinkedNeighbourInDirection(Direction.East) && !cell.HasLinkedNeighbourInDirection(Direction.South) && !cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_31.png").SingleOrDefault();
                        }
                        else if (!cell.HasLinkedNeighbourInDirection(Direction.North) && cell.HasLinkedNeighbourInDirection(Direction.East) && cell.HasLinkedNeighbourInDirection(Direction.South) && !cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_17.png").SingleOrDefault();
                        }
                        else if (!cell.HasLinkedNeighbourInDirection(Direction.North) && !cell.HasLinkedNeighbourInDirection(Direction.East) && cell.HasLinkedNeighbourInDirection(Direction.South) && cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_18.png").SingleOrDefault();
                        }
                        else if (cell.HasLinkedNeighbourInDirection(Direction.North) && !cell.HasLinkedNeighbourInDirection(Direction.East) && !cell.HasLinkedNeighbourInDirection(Direction.South) && cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_32.png").SingleOrDefault();
                        }
                        else if (cell.HasLinkedNeighbourInDirection(Direction.North) && !cell.HasLinkedNeighbourInDirection(Direction.East) && cell.HasLinkedNeighbourInDirection(Direction.South) && !cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_03.png").SingleOrDefault();
                        }
                        else if (!cell.HasLinkedNeighbourInDirection(Direction.North) && cell.HasLinkedNeighbourInDirection(Direction.East) && !cell.HasLinkedNeighbourInDirection(Direction.South) && cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_04.png").SingleOrDefault();
                        }

                        if (!cell.HasLinkedNeighbourInDirection(Direction.North) && cell.HasLinkedNeighbourInDirection(Direction.East) && cell.HasLinkedNeighbourInDirection(Direction.South) && cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_06.png").SingleOrDefault();
                        }
                        else if (cell.HasLinkedNeighbourInDirection(Direction.North) && !cell.HasLinkedNeighbourInDirection(Direction.East) && cell.HasLinkedNeighbourInDirection(Direction.South) && cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_20.png").SingleOrDefault();
                        }
                        else if (cell.HasLinkedNeighbourInDirection(Direction.North) && cell.HasLinkedNeighbourInDirection(Direction.East) && !cell.HasLinkedNeighbourInDirection(Direction.South) && cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_07.png").SingleOrDefault();
                        }
                        else if (cell.HasLinkedNeighbourInDirection(Direction.North) && cell.HasLinkedNeighbourInDirection(Direction.East) && cell.HasLinkedNeighbourInDirection(Direction.South) && !cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_21.png").SingleOrDefault();
                        }

                        if (cell.HasLinkedNeighbourInDirection(Direction.North) && cell.HasLinkedNeighbourInDirection(Direction.East) && cell.HasLinkedNeighbourInDirection(Direction.South) && cell.HasLinkedNeighbourInDirection(Direction.West))
                        {
                            texture = tileSheet.Atlas.SubTexture.Where(x => x.Name == "medievalTile_05.png").SingleOrDefault();
                        }

                        _spriteBatch.Draw(
                            texture: tileSheet.Texture,
                            position: new Vector2(x * texture.Width, y * texture.Height),
                            sourceRectangle: texture.GetRectangle(),
                            color: Color.White,
                            rotation: 0f,
                            origin: Vector2.Zero,
                            scale: 1f,
                            effects: SpriteEffects.None,
                            layerDepth: 0f);

                    }
                }
            }


            //_spriteBatch.Draw(
            //    texture: tileSheet.Texture,
            //    position: Vector2.Zero,
            //    sourceRectangle: tileSheet.Atlas.SubTexture[textureAtlasIndex].GetRectangle(),
            //    color: Color.White,
            //    rotation: 0f,
            //    origin: Vector2.Zero,
            //    scale: 1f,
            //    effects: SpriteEffects.None,
            //    layerDepth: 0f);


            //_spriteBatch.DrawString(font, $"{tileSheet.Atlas.SubTexture[textureAtlasIndex].Name}", new Vector2(0, tileSheet.Atlas.SubTexture[textureAtlasIndex].Height), Color.Black);

            //_spriteBatch.Draw(tileSheet.Texture, Vector2.Zero, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}