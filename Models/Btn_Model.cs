﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test1.Models
{
    class Btn_Model
    {
        public string Text { get; set; }
        public ICommand Command { get; set; }
    }
}
