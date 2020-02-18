using Game.ViewModels;
using System.Threading.Tasks;

namespace Game.Helpers
{
    static public class DataSetsHelper
    {
        static public void WarmUp()
        {
            ScoreIndexViewModel.Instance.GetCurrentDataSource();
            ItemIndexViewModel.Instance.GetCurrentDataSource();
        }

        static public async Task<bool> WipeData()
        {
            await ScoreIndexViewModel.Instance.WipeDataListAsync();
            await ItemIndexViewModel.Instance.WipeDataListAsync();

            return true;
        }
    }
}