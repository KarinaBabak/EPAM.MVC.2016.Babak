using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day3.HomeTask.Models
{
    public enum Faction
    {
        Light,
        Dark
    }

    public class Person
    {
        public Faction Role { get; set; }
        public string Name { get; set; }

        public void ChangeSide()
        {
            this.Role = Faction.Dark;           
        }
    }
}