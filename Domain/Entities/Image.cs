using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Image : BaseEntity
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] Data { get; set; }
    }
}
