using System;

namespace CodeGenerator.Model
{
    public class TableObj
    {
        public String Description { get; set; }
        public Boolean AllowNull { get; set; }
        public Int32 Length { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
    }
}