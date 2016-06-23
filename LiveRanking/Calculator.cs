using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveRanking
{
    class Calculator
    {
        private readonly int _timeOf3Best;
        private readonly int _pointsOf5RankBest;
        private readonly int _startKoef;
        private readonly int _raceKoef;
        private readonly int _finished;


        public Calculator(int timeOf3Best, int pointsOf5RankBest, int startKoef, int raceKoef, int finished)
        {
            _timeOf3Best = timeOf3Best;
            _pointsOf5RankBest = pointsOf5RankBest;
            _startKoef = startKoef;
            _raceKoef = raceKoef;
            _finished = finished;
        }
        public int Calculate(int time, int place)
        {
            float casy = (float)time/(float)_timeOf3Best;
            float result= (2 - casy)*_pointsOf5RankBest*(1 - _startKoef*(place - 1)/(_finished - 1))*_raceKoef;
            return (int)Math.Round(result,0);
        }
    }
}
