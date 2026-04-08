using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
namespace WindowsFormsApp1
{
    public class WaveDetailTag
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public WaveDetailTag[] Controls { get; set; }
        public string callFuntion { get; set; }
    }

    public class Players // lưu thông tin tất cả người chơi
    {
        public Player[] listPlayer;
        public Player currentPlayer { get; set; }
        XDocument xml;
        public Players(string pathToResource)
        { 
            xml = XDocument.Load(string.Format("{0}\\Data\\user\\profile.xml", pathToResource));
            listPlayer = xml.Element("players").Elements("player").ToList().Select(player => new Player(player)).ToArray();
        }
        public void SetCurrentPlayer(string player_id)
        {
            currentPlayer = listPlayer.Where(p => p.Id == player_id).First();
        }
        public void SaveLevel(string pathToResource, int lvl)
        {
            var node = xml.Element("players").Elements("player")
                 .Where(e => e.Attribute("id").Value == currentPlayer.Id)
                 .Single();
            node.Element("level").Value = string.Format("{0}",lvl);
            xml.Save(string.Format("{0}\\Data\\user\\profile.xml", pathToResource));
        }

    }
    public class Player // lưu thông tinn1 người chơi
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Id { get; }
        public Player(XElement player)
        {
            Name = player.Element("name").Value;
            Level = Int32.Parse(player.Element("level").Value);
            Id = player.Attribute("id").Value;
        }
        

    }
   



    //        XDocument xdoc = XDocument.Load("file.xml");
    //        var element = xdoc.Elements("MyXmlElement").Single();
    //        element.Value = "foo";
    //xdoc.Save("file.xml");


}
