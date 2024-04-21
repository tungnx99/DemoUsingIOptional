using Infrastructure.Extension;
using Models.DTOs.Test;
using Optional;

namespace Services.Implements.Test
{
    public interface ITestDataAccess
    {
        Option<TestInitialDTO, string> Initial();

        Option<TestProcessDTO, string> Process(TestInitialDTO initialDTO);

        Option<TestCompleteDTO, string> Complete(TestProcessDTO processDTO);

        Option<bool, string> Result(TestCompleteDTO testComplete);
    }

    public class TestDataAccess : ITestDataAccess
    {
        public Option<TestInitialDTO, string> Initial()
        {
            // condition
            if (1 == 1)
            {
                return $"Error Msg {nameof(Initial)}".ToNoneOption<TestInitialDTO>();
            }

            // hanlde code
            var initial = new TestInitialDTO();

            return initial.ToOption();
        }

        public Option<TestProcessDTO, string> Process(TestInitialDTO initialDTO)
        {
            if (initialDTO == null)
            {
                return $"Error Msg {nameof(Process)}".ToNoneOption<TestProcessDTO>();
            }

            var process = new TestProcessDTO();

            return process.ToOption();
        }

        public Option<TestCompleteDTO, string> Complete(TestProcessDTO processDTO)
        {
            if (processDTO == null)
            {
                return $"Error Msg {nameof(Complete)}".ToNoneOption<TestCompleteDTO>();
            }

            var complete = new TestCompleteDTO();

            return complete.ToOption();
        }

        public Option<bool, string> Result(TestCompleteDTO testComplete)
        {
            if (testComplete == null)
            {
                return $"Error Msg {nameof(Result)}".ToNoneOption<bool>();
            }

            return true.ToOption();
        }
    }
}
