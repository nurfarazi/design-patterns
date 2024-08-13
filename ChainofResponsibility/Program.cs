namespace ChainofResponsibility;

class Program
{
    static async Task Main(string[] args)
    {
        // Usage
        var sendGridHandler = new SendGridHandler(new SendGridEmailSender());
        var gmailHandler = new GmailHandler(new GmailEmailSender());
        var yahooHandler = new YahooHandler(new YahooEmailSender());

        // Chain the handlers
        sendGridHandler.SetNext(gmailHandler).SetNext(yahooHandler);

        // Send email
        var emailSent = await sendGridHandler.Handle("Test@test.co", "subject", "body");

        Console.WriteLine(emailSent ? "Email sent successfully" : "Email could not be sent");
    }
}

// Handler Interface
public interface IEmailHandler
{
    IEmailHandler SetNext(IEmailHandler handler);
    Task<bool> Handle(string to, string subject, string body);
}

// EmailSender Interface
public interface IEmailSender
{
    Task<bool> SendEmailAsync(string to, string subject, string body);
}

// Abstract Handler (Base Class for Concrete Handlers)
public abstract class AbstractEmailHandler : IEmailHandler
{
    private IEmailHandler _nextHandler;

    public IEmailHandler SetNext(IEmailHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual async Task<bool> Handle(string to, string subject, string body)
    {
        if (_nextHandler != null)
        {
            return await _nextHandler.Handle(to, subject, body);
        }
        else
        {
            return false; // End of chain, no handler could send the email
        }
    }
}

// Concrete Handlers
public class SendGridHandler : AbstractEmailHandler
{
    private readonly IEmailSender _emailSender;

    public SendGridHandler(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public override async Task<bool> Handle(string to, string subject, string body)
    {
        var result = await _emailSender.SendEmailAsync(to, subject, body);
        if (!result)
        {
            return await base.Handle(to, subject, body);
        }

        return result;
    }
}

public class GmailHandler : AbstractEmailHandler
{
    private readonly IEmailSender _emailSender;

    public GmailHandler(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public override async Task<bool> Handle(string to, string subject, string body)
    {
        var result = await _emailSender.SendEmailAsync(to, subject, body);
        if (!result)
        {
            return await base.Handle(to, subject, body);
        }

        return result;
    }
}

public class YahooHandler : AbstractEmailHandler
{
    private readonly IEmailSender _emailSender;

    public YahooHandler(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public override async Task<bool> Handle(string to, string subject, string body)
    {
        var result = await _emailSender.SendEmailAsync(to, subject, body);
        if (!result)
        {
            return await base.Handle(to, subject, body);
        }

        return result;
    }
}

// Concrete Email Senders

public class SendGridEmailSender : IEmailSender
{
    public async Task<bool> SendEmailAsync(string to, string subject, string body)
    {
        // Send email using SendGrid
        return true;
    }
}

public class GmailEmailSender : IEmailSender
{
    public async Task<bool> SendEmailAsync(string to, string subject, string body)
    {
        // Send email using Gmail
        return true;
    }
}

public class YahooEmailSender : IEmailSender
{
    public async Task<bool> SendEmailAsync(string to, string subject, string body)
    {
        // Send email using Yahoo
        return true;
    }
}