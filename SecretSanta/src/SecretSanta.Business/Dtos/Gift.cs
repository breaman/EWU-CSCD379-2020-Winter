using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Business.Dtos
{
    public class Gift : GiftInput
    {
        public int Id { get; set; }
        public User User { get; set; }
    }
}
