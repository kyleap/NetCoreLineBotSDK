using NetCoreLineBotSDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreLineBotSDK.Models.Message.RichMenu
{

    public class CreateRichmenu
    {
        public string richMenuId { get; set; }
        public string name { get; set; }
        public CreateSize size { get; set; }
        public string chatBarText { get; set; }
        public bool selected { get; set; }
        public List<CreateArea> areas { get; set; }
    }

    public class CreateArea
    {
        public CreateArea(int boundx, int boundy, int width, int height, IAction _action)
        {
            bounds = new CreateBounds(boundx, boundy, width, height);
            action = _action;
        }
        public CreateBounds bounds { get; set; }
        public IAction action { get; set; }
    }

    public class CreateSize
    {
        public CreateSize(int _width, int _height)
        {
            width = _width;
            height = _height;
        }
        public int width { get; set; }
        public int height { get; set; }
    }
    
    public class CreateBounds
    {
        public CreateBounds(int _x, int _y, int _w, int _h)
        {
            x = _x;
            y = _y;
            width = _w;
            height = _h;
        }
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
