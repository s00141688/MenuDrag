using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MenuTest
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;

        private DragAndDropController<Item> _dragDropController;
        private KeyboardState _keyboardState;


        public Game1()
        {
            new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _dragDropController = new DragAndDropController<Item>(this, _spriteBatch);
            Components.Add(_dragDropController);
            SetupDraggableItems();
        }

        private void SetupDraggableItems()
        {
            Texture2D itemTexture = Content.Load<Texture2D>(@"Textures\btnBanker");
            _dragDropController.Clear();
            for (int i = 0; i < 10; i++)
            {
                Item item = new Item(_spriteBatch, itemTexture, new Vector2(50 + i * 70, 100));
                _dragDropController.Add(item);
            }
        }

        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {

            HandleKeyboardInput();

            #region Lerp Attempt
            //float d = Vector2.Distance(itemPosition, basketPosition);


            //itemPosition = Vector2.Lerp(itemPosition, basketPosition, 0.001f);

            //else if (!moving)
            //{
            //    itemPosition = startingPos;
            //}

            //if (InputEngine.IsMouseLeftClick())
            //{
            //    if (itemRect.Contains(new Point((int)InputEngine.MousePosition.X,
            //                        (int)InputEngine.MousePosition.Y)))
            //    {
            //        moving = true;
            //    }
            //    else moving = false;
            //}
            #endregion

            #region Drag Attempt

            //if (itemRect.Contains(mouse.X, mouse.Y) &&  mouse.LeftButton == ButtonState.Pressed &&
            //         prevMouse.LeftButton == ButtonState.Released)
            //    {
            //        moving = true;

            //        mouseOffset = new Vector2(itemPosition.X - mouse.X, itemPosition.Y - mouse.Y);
            //    }

            //    if (moving)
            //    {
            //        if (mouse.LeftButton == ButtonState.Released)
            //            moving = false;

            //        //modifies the position
            //        itemPosition.X = mouse.X;// + mouseOffset.X;
            //        itemPosition.Y = mouse.Y;// + mouseOffset.Y;

            //        //updates the collision rectangle
            //        itemRect = new Rectangle((int)itemPosition.X, (int)itemPosition.Y, item.Width, item.Height);
            //    }

            //    prevMouse = mouse;
            #endregion

            base.Update(gameTime);
        }

        private void HandleKeyboardInput()
        {
            _keyboardState = Keyboard.GetState();
            if (_keyboardState.IsKeyDown(Keys.Escape)) { Exit(); }
            if (_keyboardState.IsKeyDown(Keys.F5)) { SetupDraggableItems(); }
            //if (_keyboardState.IsKeyDown(Keys.A) && AControlKeyIsPressed) { _dragDropController.SelectAll(); }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Pink);

            GraphicsDevice.Clear(Color.Green);
            _spriteBatch.Begin();
            foreach (var item in _dragDropController.Items) { item.Draw(gameTime); }
            base.Draw(gameTime);
            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
