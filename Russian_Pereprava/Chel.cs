using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Russian_Pereprava
{
    class Chel
    {
        public void Draw(Graphics gr)
        {
            gr.DrawImage(Image.FromFile(@way), x, y);
        }
        string way,name;
        int x, y,width, height;
        Positions posit;
        public Positions Posit
        {
            get { return posit; }
            set { posit = value; }
        }
        public string Way { get=>way; }
        public int X
        {
            get { return x; }
            set
            {
                if(value>=0&&value<=1920)
                {
                    x = value;
                }
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value >= 0 && value<=1080)
                {
                    y = value;
                }
            }
            
        }
        public string Name { get => name; }
        public int Width { get => width; }
        public int Height { get=> height; }
        public void Change_cords(Point point)
        {
            x = point.X;y = point.Y;
        }
        public Chel(Point point,int Height,int Width,string Way,string Name)
        {
            x = point.X;y = point.Y;height = Height;width = Width;
            way = Way;name = Name;
        }
    }
}
