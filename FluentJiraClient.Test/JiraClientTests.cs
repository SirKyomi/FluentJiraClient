using FluentAssertions;

namespace FluentJiraClient.Test;

public class JiraClientTests {
    [Fact]
    public void AlwaysTrue() {
        true.Should().BeTrue();
    }
}