﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Business.Dtos
{
    public class GiftInput
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
