using System.Collections.Generic;
using System.Windows;

namespace PrototypeUI_2.Model
{
    public class TreeItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Thickness OutterLine { get; set; }
        public Thickness Padding { get; set; }

        public List<TreeItemModel> Children { get; set; }

        public TreeItemModel()
        {
            OutterLine = new Thickness(0);
            Padding = new Thickness(0);
        }
    }
}
