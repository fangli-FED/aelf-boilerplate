using System.Threading.Tasks;
using AElf.Contracts.TestKit;
using AElf.Types;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Shouldly;
using Xunit;

namespace AElf.Contracts.BingContract
{
    public class BingoContractTest : BingoContractTestBase
    {
        [Fact]
        public async Task Test()
        {
            // Get a stub for testing.
            var keyPair = SampleECKeyPairs.KeyPairs[0];
            var stub = GetBingoContractStub(keyPair);

            // Use CallAsync or SendAsync method of this stub to test.
            // await stub.Hello.SendAsync(new Empty())

            // Or maybe you want to get its return value.
            // var output = (await stub.Hello.SendAsync(new Empty())).Output;

            // Or transaction result.
            // var transactionResult = (await stub.Hello.SendAsync(new Empty())).TransactionResult;
        }
    }
}