
namespace WebAPI.StepDefinitions
{
    [Binding]
    public class DeleteFileStepDefinitions
    {
        private string res;
        [Given(@"I check if file with this name exists\(delete\)")]
        public void IfFileExists()
        {
            CheckFiles check = new CheckFiles(Config.token, Config.DropBoxFolderPath);
            check.res.Contains(Config.FileName).Should().BeTrue();
        }

        [When(@"I delete file")]
        public void WhenIDeleteFile()
        {
            DeleteMethod delete = new DeleteMethod(Config.token, Config.DropBoxFilePath);
            res = delete.res;
        }

        [Then(@"I check if file is deleted")]
        public void IfFileIsDeleted()
        {
            res.Contains(Config.FileName).Should().BeTrue();
        }
    }
}
