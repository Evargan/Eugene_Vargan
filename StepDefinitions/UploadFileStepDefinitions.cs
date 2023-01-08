
namespace WebAPI.StepDefinitions
{
    [Binding]
    public class UploadFileStepDefinitions
    {
        private string res;
        [Given(@"I check if file with this name exists\(upload\)")]
        public void IfFileExists()
        {
            CheckFiles check = new CheckFiles(Config.token, Config.DropBoxFolderPath);
            check.res.Contains(Config.FileName).Should().BeFalse();
        }

        [When(@"I upload file")]
        public void WhenIUploadFile()
        {
            UploadMethod upload = new UploadMethod(Config.token, Config.FilePath, Config.DropBoxFilePath);
            res = upload.res;
        }

        [Then(@"I check if file is uploaded")]
        public void IfFileIsUploaded()
        {
            res.Contains(Config.FileName).Should().BeTrue();
        }
    }
}
