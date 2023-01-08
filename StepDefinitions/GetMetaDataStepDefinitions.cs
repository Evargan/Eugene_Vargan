
using NUnit.Framework;

namespace WebAPI.StepDefinitions
{
    [Binding]

    public class GetMetaDataStepDefinitions
    {
        private JObject res;
        [Given(@"I check if file with this name exists\(getdata\)")]
        public void IfFileExists()
        {
            CheckFiles check = new CheckFiles(Config.token, Config.DropBoxFolderPath);
            check.res.Contains(Config.FileName).Should().BeTrue();
        }

        [When(@"I get file's meta data")]
        public void IGetFilesMetaData()
        {
            GetMetaDataMethod getdata = new GetMetaDataMethod(Config.token, Config.DropBoxFilePath);
            res = getdata.value;
        }

        [Then(@"I check if I recieved file's data")]
        public void IfDataReceived()
        {
            JToken tokenName;
            res.TryGetValue("name", out tokenName).Should().BeTrue();
        }
    }
}
