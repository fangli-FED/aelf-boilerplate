using System.Threading.Tasks;
using AElf.Contracts.TestKit;
using AElf.Types;
using Shouldly;
using Xunit;

namespace AElf.Contracts.ACS6DemoContract
{
    public class ACS6Test : ACS6DemoContractTestBase
    {
        [Fact]
        public async Task Test()
        {
            var keyPair = SampleECKeyPairs.KeyPairs[0];
            var acs6DemoContractStub = GetACS6DemoContractStub(keyPair);

            var secret = HashHelper.ComputeFrom("Test");
            var commitment = HashHelper.ComputeFrom(secret);

            await acs6DemoContractStub.RequestRandomNumber.SendAsync(commitment);

            var wrongCommitment = HashHelper.ComputeFrom("Wrong");
            var errorMessage = await acs6DemoContractStub.GetRandomNumber.CallWithExceptionAsync(wrongCommitment);
            errorMessage.Value.ShouldContain("Incorrect commitment.");

            var randomHash = await acs6DemoContractStub.GetRandomNumber.CallAsync(secret);
            randomHash.ShouldNotBeNull();
        }
    }
}