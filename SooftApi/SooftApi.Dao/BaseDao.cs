using System;
using System.Collections.Generic;
using SooftApi.Model;
using SooftApi.Data;

namespace SooftApi.Dao
{
    public abstract class BaseDao : IDao
    {
        public abstract List<SingerModel> GetSingers();


        public abstract List<SingerModel> GetSingersByKindOfMusic(string kindOfMusic);


        public abstract bool InsertSinger(SingerModel singer);

    }
}
