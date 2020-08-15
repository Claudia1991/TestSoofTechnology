using SooftApi.Model;
using SooftApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SooftApi.Helper
{
    public static class SingerMapper
    {
        public static SingerModel ViewModelToModel(SingerViewModel viewModel)
        {
            return new SingerModel() { Name = viewModel.Name, KindOfMusic = viewModel.KindOfMusic, Songs = viewModel.Songs };

        }

        public static SingerViewModel ModelToViewModel(SingerModel model)
        {
            return new SingerViewModel() { Name = model.Name, KindOfMusic = model.KindOfMusic, Songs = model.Songs };
        }
    }
}
