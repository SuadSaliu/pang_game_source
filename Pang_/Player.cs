using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Pang_
{
    [Serializable]
    class Player : ISerializable
    {
        public string playerName { get; set; }
        public int points { get; set; }
        public Player(string name, int point)
        {
            this.playerName = name;
            this.points = point;
        }

        private Player(SerializationInfo info, StreamingContext context)
        {
            playerName = info.GetString("playerName");
            points = info.GetInt32("points");
        }

        public void GetObjectData(SerializationInfo inf, StreamingContext con)
        {
            // Always serialize the employee's name and age.
            inf.AddValue("playerName", playerName);
            inf.AddValue("points", points);

        }
        // Override Object.ToString to return a string representation of the
        // Employee state.
        public override string ToString()
        {
            String s = playerName;
            s =s.PadRight(25-playerName.Length ,' ');
            return s+points.ToString();
        }
    }
}