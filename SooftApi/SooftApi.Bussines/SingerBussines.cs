using SooftApi.Dao;
using SooftApi.Mock;
using SooftApi.Model;
using SooftApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using SooftApi.Helper;

namespace SooftApi.Bussines
{
    public class SingerBussines
    {

        #region Properties
        private bool useMock;
        private SingerDao singerDao;
        private SingerDaoMock singerDaoMock;
        #endregion

        #region Constructor
        public SingerBussines()
        {
            useMock = Convert.ToBoolean(ConfigurationManager.AppSettings["UseMock"]);
        }
        #endregion

        #region Public Methods
        public List<SingerViewModel> GetSingers()
        {
            List<SingerViewModel> singerViewModels = new List<SingerViewModel>();
            List<SingerModel> singers = new List<SingerModel>(); 
            if (useMock)
            {
                singerDaoMock = new SingerDaoMock();
                 singers = singerDaoMock.GetSingers();
            }
            else
            {
                singerDao = new SingerDao();
                singers = singerDao.GetSingers();
            }

            foreach (SingerModel item in singers)
            {
                singerViewModels.Add(SingerMapper.ModelToViewModel(item));
            }
            return singerViewModels;
        }

        public List<SingerViewModel> GetSingersByKindOfMusic(string kindOfMusic)
        {
            List<SingerViewModel> singerViewModels = new List<SingerViewModel>();
            List<SingerModel> singers =new List<SingerModel>();
            if (useMock)
            {
                singerDaoMock = new SingerDaoMock();
                singers = singerDaoMock.GetSingersByKindOfMusic(kindOfMusic);
            }
            else
            {
                singerDao = new SingerDao();
                singers = singerDao.GetSingersByKindOfMusic(kindOfMusic);
            }

            foreach (SingerModel item in singers)
            {
                singerViewModels.Add(SingerMapper.ModelToViewModel(item));
            }
            return singerViewModels;
        }

        public bool CreateSinger(SingerViewModel singer)
        {
            bool inserted;
            if (useMock)
            {
                singerDaoMock = new SingerDaoMock();
                inserted = singerDaoMock.InsertSinger(SingerMapper.ViewModelToModel(singer));
            }
            else
            {
                singerDao = new SingerDao();
                inserted = singerDao.InsertSinger(SingerMapper.ViewModelToModel(singer));
            }

            return inserted;
        }
        #endregion
    }
}
