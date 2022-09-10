namespace mmmSelfservice.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class ApplicationUser : IdentityUser
    {
        [AsyncStateMachine(typeof(<GenerateUserIdentityAsync>d__0)), DebuggerStepThrough]
        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            <GenerateUserIdentityAsync>d__0 stateMachine = new <GenerateUserIdentityAsync>d__0 {
                <>4__this = this,
                manager = manager,
                <>t__builder = AsyncTaskMethodBuilder<ClaimsIdentity>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<GenerateUserIdentityAsync>d__0>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [CompilerGenerated]
        private sealed class <GenerateUserIdentityAsync>d__0 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ClaimsIdentity> <>t__builder;
            public UserManager<ApplicationUser> manager;
            public ApplicationUser <>4__this;
            private ClaimsIdentity <userIdentity>5__1;
            private ClaimsIdentity <>s__2;
            private TaskAwaiter<ClaimsIdentity> <>u__1;

            private void MoveNext()
            {
                ClaimsIdentity identity;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<ClaimsIdentity> awaiter;
                    if (num != 0)
                    {
                        awaiter = this.manager.CreateIdentityAsync(this.<>4__this, "ApplicationCookie").GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            ApplicationUser.<GenerateUserIdentityAsync>d__0 stateMachine = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ClaimsIdentity>, ApplicationUser.<GenerateUserIdentityAsync>d__0>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<ClaimsIdentity>();
                        this.<>1__state = num = -1;
                    }
                    ClaimsIdentity result = awaiter.GetResult();
                    awaiter = new TaskAwaiter<ClaimsIdentity>();
                    this.<>s__2 = result;
                    this.<userIdentity>5__1 = this.<>s__2;
                    this.<>s__2 = null;
                    identity = this.<userIdentity>5__1;
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
                this.<>1__state = -2;
                this.<>t__builder.SetResult(identity);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }
    }
}

