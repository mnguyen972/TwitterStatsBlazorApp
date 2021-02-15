using System;
using TwitterStatsBlazorApp.Server.Helpers;
using Xunit;

namespace TwitterStatsBlazorApp.Tests
{
    //TODO: need to complete unit testing
    public class WorkerHelperUnitTest
    {
        [Fact]
        public void IsDomain_ValidDomain_ReturnTrue()
        {
            var workerHelper = new WorkerHelper();
            (var isValid, string dom, _) = workerHelper.IsDomain("https://www.facebook.com");

            Assert.True(isValid);
            Assert.Equal("facebook.com", dom);
        }

        [Fact]
        public void IsDomain_InvalidDomain_ReturnFalse()
        {
            var workerHelper = new WorkerHelper();
            (var isValid, _, _) = workerHelper.IsDomain("test");

            Assert.False(isValid);
        }
    }
}
