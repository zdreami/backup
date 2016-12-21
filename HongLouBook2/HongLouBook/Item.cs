using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HongLouBook
{
    class Item
    {
        public string Text = "";
        public string Value = "";
        public Item(string _Text, string _Value)
        {
            Text = _Text;
            Value = _Value;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
