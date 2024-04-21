namespace Services.Implements.Test
{
    using Infrastructure.Extension;
    using Models.DTOs.Test;
    using Optional;

    public interface ITestService
    {
        Option<bool, string> DoSomeThing();
    }

    public class TestService : ITestService
    {
        private readonly ITestDataAccess _dataAccess;

        public TestService(ITestDataAccess dataAccess)
        {
            _dataAccess=dataAccess;
        }

        public Option<bool, string> DoSomeThing()
        {
            var result = default(Option<bool, string>);

            try
            {
                result = Initial()
                            .FlatMap(n => Process(n))
                            .FlatMap(n => Complete(n))
                            .FlatMap(n => Result(n));
            }
            catch (Exception ex)
            {
                return ex.Message.ToNoneOption<bool>();
            }

            return result;
        }

        #region private method
        private Option<TestInitialDTO, string> Initial()
        {
            return _dataAccess.Initial();
        }

        public Option<TestProcessDTO, string> Process(TestInitialDTO initialDTO)
        {
            return _dataAccess.Process(initialDTO);
        }

        public Option<TestCompleteDTO, string> Complete(TestProcessDTO processDTO)
        {
            return _dataAccess.Complete(processDTO);
        }

        public Option<bool, string> Result(TestCompleteDTO testComplete)
        {
            return _dataAccess.Result(testComplete);
        }
        #endregion
    }
}
