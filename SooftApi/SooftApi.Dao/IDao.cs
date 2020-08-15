using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SooftApi.Model;

namespace SooftApi.Dao
{
    interface IDao
    {
        bool InsertSinger(SingerModel singer);

        List<SingerModel> GetSingersByKindOfMusic(string kindOfMusic);

        List<SingerModel> GetSingers();
    }
}
