﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    public partial class ChatRoom
    {
        public int id { get; set; }

        public string Topic { get; set; }
        
        public string GetLastMessage { get; set; }
    }
}
