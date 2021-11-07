using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robot : IId
    {
        public Robot(string model, string id)
        {
            this.id = id;
            Model = model;
        }

        public string id { get; set; }

        public string Model { get; set; }
    }
}
