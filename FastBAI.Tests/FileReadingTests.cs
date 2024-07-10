using FastBAI.Services;
using FluentAssertions;

namespace FastBAI.Tests
{
    public class FileReadingTests
    {
        [Fact]
        public async Task Read_Returns_BaiFile()
        {
            // Arrange && Act
            var service = new BaiFileService();
            var actual = service.ProcessFile(@"../../../../FastBAIExe/Files/BAIDAY1.txt");

            // Assert
            actual.Should().NotBeNull();
            actual.FileHeader.Should().NotBeNull();
            actual.FileTrailer.Should().NotBeNull();
        }
    }
}
