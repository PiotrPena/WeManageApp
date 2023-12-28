using System.Diagnostics;

public abstract class Panel
{
    protected User User;
    protected WeManageContext Context;

    protected Panel(User user, WeManageContext context)
    {
        User = user;
        Context = context;
    }

    public virtual void Process(){

    }
}