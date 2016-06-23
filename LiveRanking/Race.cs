using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveRanking
{
    class Race
    {
        public int Id { get; }
        public bool results;
        public bool rankingDone;

        public Race(int id)
        {
            Id = id;
        }
    }
}
