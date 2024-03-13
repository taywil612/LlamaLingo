using System;
using System.Collections.Generic;

namespace LlamaLingo.Models;

public partial class ParseSentence
{
    public int SentenceId { get; set; }

    public string SentenceText { get; set; }

    public string SSubject { get; set; }

    public string SVerb { get; set; }

    public string SObject { get; set; }

    public string SStatus { get; set; }

    public string RuleSubject { get; set; }

    public string RuleVerb { get; set; }

    public string RuleObject { get; set; }
}
