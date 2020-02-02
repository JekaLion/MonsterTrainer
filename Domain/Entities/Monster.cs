using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.entities
{
    public class Monster : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RarityLevel { get; set; }
        public long? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
