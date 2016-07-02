using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Models;
using DAL.Data;

namespace BL.Repository
{
    public static class MapperInstance
    {
        public static IMapper Mapper { get; } = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<BaseEntity, BaseEntityDAL>();
            cfg.CreateMap<BaseEntityDAL, BaseEntity>();
            cfg.CreateMap<RankingRace, RankingRaceDAL>();
            cfg.CreateMap<RankingRaceDAL, RankingRace>();
            cfg.CreateMap<RankingResult, RankingResultDAL>();
            cfg.CreateMap<RankingResultDAL, RankingResult>();
            cfg.CreateMap<Competitor, CompetitorDAL>();
            cfg.CreateMap<CompetitorDAL, Competitor>();
        }).CreateMapper();
    }
}
