using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using March_Game_Jam.Helpers;

namespace March_Game_Jam.Entities
{
    public class Storage : Entity
    {
        public List<Item> item_storage_list;
        public Storage() : base()
        {
            item_storage_list = new List<Item>();
        }

        public void add_to_storage(Item item)
        {
            item_storage_list.Add(item);
        }

        public void remove_item_from_storage(Item item)
        {
            item.Destroy();
        }
    }
}