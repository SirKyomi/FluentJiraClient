namespace FluentJiraClient;

public class JiraClientBuilder : IUrlSelectionStage, IUsernameSelectionStage, IPasswordSelectionStage, IBuildStage {
    private string _url;
    private string _username;
    private string _password;
    private string _onlyAccessToken;
    private string _authMethod = "Basic";

    public static IUrlSelectionStage Create() {
        return new JiraClientBuilder();
    }

    public IUsernameSelectionStage WithUrl(string url) {
        _url = url;
        return this;
    }

    public IPasswordSelectionStage WithUsername(string username) {
        _username = username;
        return this;
    }

    public IPasswordSelectionStage WithEmail(string email) {
        _username = email;
        return this;
    }

    public IBuildStage UsingOnlyAccessToken(string accessToken) {
        _onlyAccessToken = accessToken;
        return this;
    }

    public IBuildStage WithPassword(string password) {
        _password = password;
        return this;
    }


    public IBuildStage WithAccessToken(string accessToken) {
        _password = accessToken;
        return this;
    }

    public IBuildStage UsingAuthMethod(string authMethod) {
        _authMethod = authMethod;
        return this;
    } 
    public IBuildStage UsingBearerAuthentication() {
        UsingAuthMethod("Bearer");
        return this;
    } 
    public IBuildStage UsingBasicAuthentication() {
        UsingAuthMethod("Basic");
        return this;
    }

    public JiraClient Build() {
        return _onlyAccessToken == "Bearer" ? new JiraClient(_url,_authMethod, _onlyAccessToken) : new JiraClient(_url,_authMethod, _username, _password);
    }
}

public interface IUrlSelectionStage {
    IUsernameSelectionStage WithUrl(string url);
}

public interface IUsernameSelectionStage {
    IPasswordSelectionStage WithUsername(string username);
    IPasswordSelectionStage WithEmail(string email);
    IBuildStage UsingOnlyAccessToken(string accessToken);
}

public interface IPasswordSelectionStage {
    IBuildStage WithPassword(string password);
    IBuildStage WithAccessToken(string accessToken);
}

public interface IBuildStage {
    IBuildStage UsingAuthMethod(string authMethod);
    IBuildStage UsingBearerAuthentication();
    IBuildStage UsingBasicAuthentication();
    JiraClient Build();
}