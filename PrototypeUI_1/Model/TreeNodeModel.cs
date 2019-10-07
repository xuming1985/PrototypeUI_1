using System.Collections.Generic;
using System.Windows;

namespace PrototypeUI_1.Model
{
    public class TreeNodeModel
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public string ImagePath { get; set; }

        public int FontSize { get; set; }
        public Thickness Thickness { get; set; }
        public List<TreeNodeModel> Children { get; set; }

        public TreeNodeModel()
        {
            FontSize = 14;
            Thickness = new Thickness(0, 0, 0, 0);
        }

    }
}
