using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MazeWeb.Helpers
{
    public static class TileHelpers
    {
       
        public static char ConvertChar(string StringTile)
        {
            StringTile = StringTile.Trim();
            if ("Wall" == StringTile)
            {
                return '#';
            }
            else if ("Free" == StringTile)
            {
                return '.';
            }
            else if ("CurrentPos" == StringTile)
            {
                return '0';
            }
            else if ("Path" == StringTile)
            {
                return '°';
            }
            else if ("Unknown" == StringTile)
            {
                return '?';
            }
            else 
            {
                return '*';
            }

        }

    }
}