﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EosSharp
{
    public class EosConfigurator
    {
        public string HttpEndpoint { get; set; } = "http://127.0.0.1:8888";
        public string ChainId { get; set; }
        public double ExpireSeconds { get; set; } = 60;
        public ISignProvider SignProvider { get; set; }
    }
}
