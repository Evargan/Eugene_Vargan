
using WebAPI.Support;

namespace WebAPI.StepDefinitions
{
    [Binding]
    public class Dropbox_FileStepDefinitions
    {
        [Given(@"I upload file to dropbox")]
        public void GivenIUploadFileToDropbox()
        {
            new UploadMethod(Config.token, Config.FilePath, Config.DropBoxFilePath);
        }

        [When(@"I get file meta data")]
        public void WhenIGetFileMetaData()
        {
            GetMetaDataMethod method = new GetMetaDataMethod(Config.token, Config.DropBoxFilePath);
            JObject info = method.value;
            JToken tokenName;
            if (info.TryGetValue("name", out tokenName) == false)
            {
               throw new Exception("Don't receive data");
            }
        }

        [Then(@"I delete file from dropbox")]
        public void ThenIDeleteFileFromDropbox()
        {
            new DeleteMethod(Config.token, Config.DropBoxFilePath);
        }
    }
}
