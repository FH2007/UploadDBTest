using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadDB.Models;

namespace UploadDB.Controllers
{
    internal class UpdateDBDataController
    {
        public void UpdateData()
        {
            ReadTXTController read = new ReadTXTController { path ="" };
            List<WordModel> txtData = read.Read();

            GetDataFromDBController getDBData = new GetDataFromDBController();
            List<WordModel> DBData = getDBData.GetData(txtData.Select(x => x.Word).ToList());

            WorkWordsDataController workController = new WorkWordsDataController();
            List<WordModel> readyData = workController.WorkData(txtData, DBData);
        }
    }
}
