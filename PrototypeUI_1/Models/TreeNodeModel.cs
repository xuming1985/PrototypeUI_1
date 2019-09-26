using System.Collections.Generic;

namespace PrototypeUI_1.Models
{
    public class TreeNodeModel
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public string ImagePath { get; set; }
        public List<TreeNodeModel> Children { get; set; }
    }
}
