using SooftApi.Dao;
using SooftApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SooftApi.Mock
{
    public class SingerDaoMock : BaseDao
    {
        #region Properties
        private static List<Model.SingerModel> singers = new List<SingerModel>();
        #endregion

        public override List<SooftApi.Model.SingerModel> GetSingers()
        {
            singers.Add(new SingerModel() 
            { 
                Name = "Uno",
                KindOfMusic = "Uno",
                Songs = new List<string>() { "Uno", "Uno", "Uno" }
            });

            singers.Add(new SingerModel()
            {
                Name = "Dos",
                KindOfMusic = "Dos",
                Songs = new List<string>() { "Uno", "Uno", "Uno" }
            });

            singers.Add(new SingerModel()
            {
                Name = "Tres",
                KindOfMusic = "Tres",
                Songs = new List<string>() { "Uno", "Uno", "Uno" }
            });

            return singers;
        }

        public override List<SooftApi.Model.SingerModel> GetSingersByKindOfMusic(string kindOfMusic)
        {
            return singers.Where(x => x.KindOfMusic == kindOfMusic).ToList();
        }

        public override bool InsertSinger(SooftApi.Model.SingerModel singer)
        {
            bool exist = singers.Any(x=> x.Name == singer.Name);
            bool inserted = !exist;
            if (!exist)
            {
                //Si no existe un cantante con el mismo nombre, lo agrego
                singers.Add(singer);
            }
            return inserted;
        }
    }
}
