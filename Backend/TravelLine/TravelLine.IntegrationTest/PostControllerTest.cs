using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TravelLine.IntegrationTest
{
    public class PostControllerTest : IntegrationTest
    {
        [Fact]
        public async Task Task_GetAll_WithoutAnyPost_ReturnEmptyResponse()
        {
            //Arrange

            //Act
            var res = await _TestClient.GetAsync("https://localhost:44342/api/posts");
            //Assert
            res.StatusCode.Should().Be(HttpStatusCode.OK);
            (await res.Content.ReadAsStringAsync()).Should().BeEmpty();
        }
    }
}
