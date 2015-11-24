using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuTest
{
    public interface DragAndDrop
    {
        Vector2 Position { get; set; }
        bool IsSelected { set; }
        bool IsMouseOver { set; }
        bool Contains(Vector2 pointToCheck);
        Rectangle Border { get; }
    }
}
