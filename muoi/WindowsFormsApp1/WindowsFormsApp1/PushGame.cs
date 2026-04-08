using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public class PushGame
    {
        public Board board;  // thuộc tính
        public int level;
        public PushGame(string pathToResource, int level) {  // Ham khai báo
            this.level = level;
            this.board = new Board(pathToResource, this.level);
        }
        public int moveLeft() 
        {
            int x = board.character.X - 1;
            int y = board.character.Y;
            if (x < 0 || y < 0) return 0;
            if (board.Cells[x - 1, y - 1].type == "wall") return 0;
            foreach(Box b in board.boxes)
            {
                if (x == b.X && y == b.Y) 
                { 
                    int xb = b.X - 1;
                    int yb = b.Y;
                    if (xb < 0 || yb < 0) return 0;
                    if (board.Cells[xb - 1, yb - 1].type == "wall" || board.boxes.Where(k => k.X == xb && k.Y == yb).ToArray().Length > 0) return 0;
                    b.ChangeBoxValue(xb, yb);
                }
            }
            if (board.Cells[board.character.X - 1, board.character.Y - 1].type == "destination") board.character.ChangeImage(true);
            if (board.Cells[x - 1, y - 1].type == "destination") board.character.ChangeImage(false);
            board.character.ChangeCharacterValue(x, y); 
            
            return 1;
        } // phương thức
        public int moveRight()
        {
            int x = board.character.X + 1;
            int y = board.character.Y;
            if (x < 0 || y < 0) return 0;
            if (board.Cells[x - 1, y - 1].type == "wall") return 0;
            foreach (Box b in board.boxes)
            {
                if (x == b.X && y == b.Y)
                {
                    int xb = b.X + 1;
                    int yb = b.Y;
                    if (xb < 0 || yb < 0) return 0;
                    if (board.Cells[xb - 1, yb - 1].type == "wall" || board.boxes.Where(k => k.X == xb && k.Y == yb).ToArray().Length > 0) return 0;
                    b.ChangeBoxValue(xb, yb);
                }
            }
            board.character.ChangeCharacterValue(x, y);
            if (board.Cells[board.character.X - 1, board.character.Y - 1].type == "destination") board.character.ChangeImage(true);
            if (board.Cells[x - 1, y - 1].type == "destination") board.character.ChangeImage(false);
            return 1;
        }
        public int moveUp()
        {
            int x = board.character.X;
            int y = board.character.Y - 1;
            if (x < 0 || y < 0) return 0;
            if (board.Cells[x - 1, y - 1].type == "wall") return 0;
            foreach (Box b in board.boxes)
            {
                if (x == b.X && y == b.Y)
                {
                    int xb = b.X;
                    int yb = b.Y - 1;
                    if (xb < 0 || yb < 0) return 0;
                    if (board.Cells[xb - 1, yb - 1].type == "wall" || board.boxes.Where(k => k.X == xb && k.Y == yb).ToArray().Length > 0) return 0;
                    b.ChangeBoxValue(xb, yb);
                }
            }
            board.character.ChangeCharacterValue(x, y);
            if (board.Cells[board.character.X - 1, board.character.Y - 1].type == "destination") board.character.ChangeImage(true);
            if (board.Cells[x - 1, y - 1].type == "destination") board.character.ChangeImage(false);
            return 1;
        }
        public int moveDown()
        {
            int x = board.character.X;
            int y = board.character.Y + 1;
            if (x < 0 || y < 0) return 0;
            if (board.Cells[x - 1, y - 1].type == "wall") return 0;
            foreach (Box b in board.boxes)
            {
                if (x == b.X && y == b.Y)
                {
                    int xb = b.X ;
                    int yb = b.Y + 1;
                    if (xb < 0 || yb < 0) return 0;
                    if (board.Cells[xb - 1, yb - 1].type == "wall" || board.boxes.Where(k => k.X == xb && k.Y == yb).ToArray().Length > 0) return 0;
                    b.ChangeBoxValue(xb, yb);
                }
            }
            board.character.ChangeCharacterValue(x, y);
            if (board.Cells[board.character.X - 1, board.character.Y - 1].type == "destination") board.character.ChangeImage(true);
            if (board.Cells[x - 1, y - 1].type == "destination") board.character.ChangeImage(false);
            return 1;
        }
        public int checkEnd()
        {
            foreach (Box b in board.boxes)
            {
                int xb = b.X;
                int yb = b.Y;
                if (board.Cells[xb - 1, yb - 1].type != "destination") return 0;
            }
            return 1;
        }

    }
    public class Board
    {
        int maxX, maxY;
        public int minLocationX {get; set;}
        public int minLocationY {get; set;}
        public Cell[,] Cells;
        public Character character;
        public Box[] boxes;

        public Board(string pathToResource, int level) {
            var xml = XDocument.Load(string.Format("{0}\\Data\\level\\level_{1}.xml", pathToResource, level));
            this.maxX = Int32.Parse(xml.Element("level").Attribute("x").Value);
            this.maxY = Int32.Parse(xml.Element("level").Attribute("y").Value);
            this.Cells = new Cell[maxX,maxY];
            var items = xml.Element("level").Elements("items").ToList();
            var unchanges = items.Where(t => new string[] { "wall", "grass", "destination" }.Contains(t.Attribute("id").Value));
            foreach (var itemCatalog in unchanges) {
                string t = itemCatalog.Attribute("id").Value;
                foreach (var item in itemCatalog.Elements("item").ToList())
                {
                    int x = Int32.Parse(item.Element("positionX").Value);
                    int y = Int32.Parse(item.Element("positionY").Value);
                    this.Cells[x-1, y-1] = new Cell(x, y, t); // tập hợp các ô gạch được khiwr tạo
                }
            }
            for (int r = 0; r < this.Cells.GetLength(1); r++)
            {
                for (int c = 0; c < this.Cells.GetLength(0); c++)
                {
                    if (this.Cells[c,r] == null)
                    {
                        this.Cells[c,r] = new Cell(c, r, "out");
                    }
                }
            }
            var charac = items.Where(t => new string[] { "character" }.Contains(t.Attribute("id").Value)).First().Elements("item").First(); 
            this.character = new Character( //khơi 
                Int32.Parse(charac.Element("positionX").Value),
                Int32.Parse(charac.Element("positionY").Value)
            );
            List<XElement> box = items.Where(t => new string[] { "box" }.Contains(t.Attribute("id").Value)).First().Elements("item").ToList();
            List<Box> boxesList = new List<Box>();

            for ( int i = 0; i < box.Count; i++) {
                var item = box[i];
                int x = Int32.Parse(item.Element("positionX").Value);
                int y = Int32.Parse(item.Element("positionY").Value);
                boxesList.Add(new Box(i,x, y));
            }
            this.boxes = boxesList.ToArray();

        }

    }
    public class Cell
    {
        int positionX, positionY;
        int X, Y;
        public string type;
        public string imageBackground;
        public Cell(int X, int Y, string type)
        {
            this.type = type;
            this.X = X;
            this.Y = Y;
            this.positionX = (X - 1) * 100;
            this.positionY = (Y - 1) * 100;
            if (type == "wall")
            {
                this.imageBackground = "wall.png";
            }
            else if (type == "grass")
            {
                this.imageBackground = "grass.png";
            }
            else if (type == "destination")
            {
                this.imageBackground = "destination.png";
            }
            else
            {
                this.imageBackground = "none.png";
            }
        }
    }
    public class Box
    {
        public int id;
        public int positionX, positionY;
        public int X, Y;
        public string imageBackground = "box.png";

        public Box(int id,int X, int Y)
        {
            this.id = id;
            this.X = X;
            this.Y = Y;
            this.positionX = (X - 1) * 100;
            this.positionY = (Y - 1) * 100;
        }
        public void ChangeBoxValue(int X, int Y)// cập nhật vị trí mới của thùng
        {
            this.X = X;
            this.Y = Y;
            this.positionX = (X - 1) * 100;
            this.positionY = (Y - 1) * 100;
        }
    }
    public class Character
    {
        public int positionX, positionY;
        public int X, Y;
        public string imageBackground = "character.png";
        public Character(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.positionX = (X - 1) * 100;
            this.positionY = (Y - 1) * 100;
        }
        public void ChangeCharacterValue(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.positionX = (X - 1) * 100;
            this.positionY = (Y - 1) * 100;
        }
        public void ChangeImage(bool x)
        {
            if (x) 
            {
                this.imageBackground = "character.png";
            }
            else
            {
                this.imageBackground = "character_1.png";
            }
        }

    }
}
