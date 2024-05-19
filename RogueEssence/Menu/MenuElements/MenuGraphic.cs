﻿using RogueElements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueEssence.Content;

namespace RogueEssence.Menu
{
    public class MenuGraphic : IMenuElement
    {
        public enum GraphicType
        {
            Button
        }

        public string Label { get; set; }
        public Loc Loc { get; set; }
        public GraphicType Type { get; set; }
        public Loc Texture { get; set; }

        public MenuGraphic(Loc loc, GraphicType type, Loc texture)
        {
            Loc = loc;
            Type = type;
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Loc offset)
        {
            switch (Type)
            {
                case GraphicType.Button:
                    GraphicsManager.Buttons.DrawTile(spriteBatch, new Vector2(Loc.X + offset.X, Loc.Y + offset.Y), Texture.X, Texture.Y);
                    break;
            }
            
        }
    }
}
