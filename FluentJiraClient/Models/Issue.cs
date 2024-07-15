using System.Text.Json.Serialization;

namespace FluentJiraClient.Models;

public class Issue<TCustomFields> : Issue where TCustomFields : StandardFields {
    [JsonPropertyName("fields")] public TCustomFields Fields { get; set; }
}

public class Issue {
    [JsonPropertyName("fields")] public StandardFields Fields { get; set; }

    public string id { get; set; }
    public string key { get; set; }
    public string self { get; set; }
}

public class StandardFields {
    public Watcher watcher { get; set; }
    public Attachment[] attachment { get; set; }
    public Sub_tasks[] sub_tasks { get; set; }
    public string description { get; set; }
    public Project project { get; set; }
    public CommentList comment { get; set; }
    public Issuelinks[] issuelinks { get; set; }
    public WorklogList worklog { get; set; }
    public string updated { get; set; }
    public Timetracking timetracking { get; set; }
}

public class WorklogList {
    public Worklog[] worklogs { get; set; }
    public int maxResults { get; set; }
    public int startAt { get; set; }
    public int total { get; set; }
}

public class Watcher {
    public bool isWatching { get; set; }
    public string self { get; set; }
    public int watchCount { get; set; }
}

public class Attachment {
    public Author author { get; set; }
    public string content { get; set; }
    public string created { get; set; }
    public string filename { get; set; }
    public int id { get; set; }
    public string mimeType { get; set; }
    public string self { get; set; }
    public int size { get; set; }
}

public class Author {
    public string accountId { get; set; }
    public string accountType { get; set; }
    public bool active { get; set; }
    public AvatarUrls avatarUrls { get; set; }
    public string displayName { get; set; }
    public string key { get; set; }
    public string name { get; set; }
    public string self { get; set; }
}

public class AvatarUrls {
    public string _6x16 { get; set; }
    public string _4x24 { get; set; }
    public string _2x32 { get; set; }
    public string _8x48 { get; set; }
}

public class Sub_tasks {
    public string id { get; set; }
    public Issue outwardIssue { get; set; }
    public Type type { get; set; }
}

public class Status {
    public string iconUrl { get; set; }
    public string name { get; set; }
}

public class Type {
    public string id { get; set; }
    public string inward { get; set; }
    public string name { get; set; }
    public string outward { get; set; }
}

public class Project {
    public AvatarUrls avatarUrls { get; set; }
    public string id { get; set; }
    public Insight insight { get; set; }
    public string key { get; set; }
    public string name { get; set; }
    public ProjectCategory projectCategory { get; set; }
    public string self { get; set; }
    public bool simplified { get; set; }
    public string style { get; set; }
}

public class Insight {
    public string lastIssueUpdateTime { get; set; }
    public int totalIssueCount { get; set; }
}

public class ProjectCategory {
    public string description { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string self { get; set; }
}

public class CommentList {
    public Comment[] comments { get; set; }
    public int maxResults { get; set; }
    public int startAt { get; set; }
    public int total { get; set; }
    public string self { get; set; }
}

public class Comment {
    public Author author { get; set; }
    public string body { get; set; }
    public string created { get; set; }
    public string id { get; set; }
    public string self { get; set; }
    public Author updateAuthor { get; set; }
    public string updated { get; set; }
    public Visibility visibility { get; set; }
}

public class Visibility {
    public string identifier { get; set; }
    public string type { get; set; }
    public string value { get; set; }
}

public class Issuelinks {
    public string id { get; set; }
    public Issue outwardIssue { get; set; }
    public Type type { get; set; }
    public Issue inwardIssue { get; set; }
}

public class Worklog {
    public Author author { get; set; }
    public string comment { get; set; }
    public string id { get; set; }
    public string issueId { get; set; }
    public string self { get; set; }
    public string started { get; set; }
    public string timeSpent { get; set; }
    public int timeSpentSeconds { get; set; }
    public Author updateAuthor { get; set; }
    public string updated { get; set; }
    public Visibility visibility { get; set; }
}

public class Timetracking {
    public string originalEstimate { get; set; }
    public int originalEstimateSeconds { get; set; }
    public string remainingEstimate { get; set; }
    public int remainingEstimateSeconds { get; set; }
    public string timeSpent { get; set; }
    public int timeSpentSeconds { get; set; }
}