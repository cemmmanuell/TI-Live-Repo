namespace mmmSelfservice.Controllers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.CSharp.RuntimeBinder;
    using Microsoft.Owin.Security;
    using mmmSelfservice;
    using mmmSelfservice.Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private const string XsrfKey = "XsrfId";

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (string str in result.Errors)
            {
                base.ModelState.AddModelError("", str);
            }
        }

        [AsyncStateMachine(typeof(<ConfirmEmail>d__16)), DebuggerStepThrough, AllowAnonymous]
        public Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            <ConfirmEmail>d__16 stateMachine = new <ConfirmEmail>d__16 {
                <>4__this = this,
                userId = userId,
                code = code,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<ConfirmEmail>d__16>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._userManager > null)
                {
                    this._userManager.Dispose();
                    this._userManager = null;
                }
                if (this._signInManager > null)
                {
                    this._signInManager.Dispose();
                    this._signInManager = null;
                }
            }
            base.Dispose(disposing);
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ChallengeResult(provider, base.Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        [AsyncStateMachine(typeof(<ExternalLoginCallback>d__26)), DebuggerStepThrough, AllowAnonymous]
        public Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            <ExternalLoginCallback>d__26 stateMachine = new <ExternalLoginCallback>d__26 {
                <>4__this = this,
                returnUrl = returnUrl,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<ExternalLoginCallback>d__26>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<ExternalLoginConfirmation>d__27)), DebuggerStepThrough, HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            <ExternalLoginConfirmation>d__27 stateMachine = new <ExternalLoginConfirmation>d__27 {
                <>4__this = this,
                model = model,
                returnUrl = returnUrl,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<ExternalLoginConfirmation>d__27>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return base.View();
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return base.View();
        }

        [AsyncStateMachine(typeof(<ForgotPassword>d__18)), DebuggerStepThrough, HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            <ForgotPassword>d__18 stateMachine = new <ForgotPassword>d__18 {
                <>4__this = this,
                model = model,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<ForgotPassword>d__18>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return base.View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (<>o__10.<>p__0 == null)
            {
                CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) };
                <>o__10.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ReturnUrl", typeof(AccountController), argumentInfo));
            }
            <>o__10.<>p__0.Target(<>o__10.<>p__0, base.ViewBag, returnUrl);
            return base.View();
        }

        [AsyncStateMachine(typeof(<Login>d__11)), DebuggerStepThrough, HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            <Login>d__11 stateMachine = new <Login>d__11 {
                <>4__this = this,
                model = model,
                returnUrl = returnUrl,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<Login>d__11>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            string[] authenticationTypes = new string[] { "ApplicationCookie" };
            this.AuthenticationManager.SignOut(authenticationTypes);
            return base.RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (base.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            return base.RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return base.View();
        }

        [AsyncStateMachine(typeof(<Register>d__15)), DebuggerStepThrough, HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public Task<ActionResult> Register(RegisterViewModel model)
        {
            <Register>d__15 stateMachine = new <Register>d__15 {
                <>4__this = this,
                model = model,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<Register>d__15>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<ResetPassword>d__21)), DebuggerStepThrough, HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            <ResetPassword>d__21 stateMachine = new <ResetPassword>d__21 {
                <>4__this = this,
                model = model,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<ResetPassword>d__21>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return ((code == null) ? base.View("Error") : base.View());
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return base.View();
        }

        [AsyncStateMachine(typeof(<SendCode>d__25)), DebuggerStepThrough, HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            <SendCode>d__25 stateMachine = new <SendCode>d__25 {
                <>4__this = this,
                model = model,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<SendCode>d__25>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<SendCode>d__24)), DebuggerStepThrough, AllowAnonymous]
        public Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            <SendCode>d__24 stateMachine = new <SendCode>d__24 {
                <>4__this = this,
                returnUrl = returnUrl,
                rememberMe = rememberMe,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<SendCode>d__24>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<VerifyCode>d__13)), DebuggerStepThrough, HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            <VerifyCode>d__13 stateMachine = new <VerifyCode>d__13 {
                <>4__this = this,
                model = model,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<VerifyCode>d__13>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<VerifyCode>d__12)), DebuggerStepThrough, AllowAnonymous]
        public Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            <VerifyCode>d__12 stateMachine = new <VerifyCode>d__12 {
                <>4__this = this,
                provider = provider,
                returnUrl = returnUrl,
                rememberMe = rememberMe,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<VerifyCode>d__12>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return (this._signInManager ?? base.HttpContext.GetOwinContext().Get<ApplicationSignInManager>());
            }
            private set
            {
                this._signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return (this._userManager ?? base.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>());
            }
            private set
            {
                this._userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return base.HttpContext.GetOwinContext().Authentication;
            }
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly AccountController.<>c <>9 = new AccountController.<>c();
            public static Func<string, SelectListItem> <>9__24_0;

            internal SelectListItem <SendCode>b__24_0(string purpose)
            {
                return new SelectListItem { 
                    Text = purpose,
                    Value = purpose
                };
            }
        }

        [CompilerGenerated]
        private static class <>o__10
        {
            public static CallSite<Func<CallSite, object, string, object>> <>p__0;
        }

        [CompilerGenerated]
        private static class <>o__26
        {
            public static CallSite<Func<CallSite, object, string, object>> <>p__0;
            public static CallSite<Func<CallSite, object, string, object>> <>p__1;
        }

        [CompilerGenerated]
        private static class <>o__27
        {
            public static CallSite<Func<CallSite, object, string, object>> <>p__0;
        }

        [CompilerGenerated]
        private sealed class <ConfirmEmail>d__16 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public string userId;
            public string code;
            public AccountController <>4__this;
            private IdentityResult <result>5__1;
            private IdentityResult <>s__2;
            private TaskAwaiter<IdentityResult> <>u__1;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IdentityResult> awaiter;
                    IdentityResult result2;
                    if (num != 0)
                    {
                        if ((this.userId != null) && (this.code != null))
                        {
                            awaiter = this.<>4__this.UserManager.ConfirmEmailAsync(this.userId, this.code).GetAwaiter();
                            if (!awaiter.IsCompleted)
                            {
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                AccountController.<ConfirmEmail>d__16 stateMachine = this;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, AccountController.<ConfirmEmail>d__16>(ref awaiter, ref stateMachine);
                                return;
                            }
                            goto Label_00B0;
                        }
                        result = this.<>4__this.View("Error");
                        goto Label_011D;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_00B0:
                    result2 = awaiter.GetResult();
                    awaiter = new TaskAwaiter<IdentityResult>();
                    this.<>s__2 = result2;
                    this.<result>5__1 = this.<>s__2;
                    this.<>s__2 = null;
                    result = this.<>4__this.View(this.<result>5__1.Succeeded ? "ConfirmEmail" : "Error");
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_011D:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <ExternalLoginCallback>d__26 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public string returnUrl;
            public AccountController <>4__this;
            private ExternalLoginInfo <loginInfo>5__1;
            private SignInStatus <result>5__2;
            private ExternalLoginInfo <>s__3;
            private SignInStatus <>s__4;
            private TaskAwaiter<ExternalLoginInfo> <>u__1;
            private TaskAwaiter<SignInStatus> <>u__2;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<ExternalLoginInfo> awaiter;
                    ExternalLoginInfo info;
                    AccountController.<ExternalLoginCallback>d__26 d__;
                    SignInStatus status;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_011D;

                        default:
                            awaiter = this.<>4__this.AuthenticationManager.GetExternalLoginInfoAsync().GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_007D;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ExternalLoginInfo>, AccountController.<ExternalLoginCallback>d__26>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<ExternalLoginInfo>();
                    this.<>1__state = num = -1;
                Label_007D:
                    info = awaiter.GetResult();
                    awaiter = new TaskAwaiter<ExternalLoginInfo>();
                    this.<>s__3 = info;
                    this.<loginInfo>5__1 = this.<>s__3;
                    this.<>s__3 = null;
                    if (this.<loginInfo>5__1 == null)
                    {
                        result = this.<>4__this.RedirectToAction("Login");
                        goto Label_02F2;
                    }
                    TaskAwaiter<SignInStatus> awaiter2 = this.<>4__this.SignInManager.ExternalSignInAsync(this.<loginInfo>5__1, false).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_013A;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<SignInStatus>, AccountController.<ExternalLoginCallback>d__26>(ref awaiter2, ref d__);
                    return;
                Label_011D:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<SignInStatus>();
                    this.<>1__state = num = -1;
                Label_013A:
                    status = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<SignInStatus>();
                    this.<>s__4 = status;
                    this.<result>5__2 = this.<>s__4;
                    switch (this.<result>5__2)
                    {
                        case SignInStatus.Success:
                            result = this.<>4__this.RedirectToLocal(this.returnUrl);
                            goto Label_02F2;

                        case SignInStatus.LockedOut:
                            result = this.<>4__this.View("Lockout");
                            goto Label_02F2;

                        case SignInStatus.RequiresVerification:
                            result = this.<>4__this.RedirectToAction("SendCode", new { 
                                ReturnUrl = this.returnUrl,
                                RememberMe = false
                            });
                            goto Label_02F2;
                    }
                    if (AccountController.<>o__26.<>p__0 == null)
                    {
                        CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) };
                        AccountController.<>o__26.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ReturnUrl", typeof(AccountController), argumentInfo));
                    }
                    AccountController.<>o__26.<>p__0.Target(AccountController.<>o__26.<>p__0, this.<>4__this.ViewBag, this.returnUrl);
                    if (AccountController.<>o__26.<>p__1 == null)
                    {
                        CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) };
                        AccountController.<>o__26.<>p__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LoginProvider", typeof(AccountController), argumentInfo));
                    }
                    AccountController.<>o__26.<>p__1.Target(AccountController.<>o__26.<>p__1, this.<>4__this.ViewBag, this.<loginInfo>5__1.Login.LoginProvider);
                    ExternalLoginConfirmationViewModel model = new ExternalLoginConfirmationViewModel {
                        Email = this.<loginInfo>5__1.Email
                    };
                    result = this.<>4__this.View("ExternalLoginConfirmation", model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_02F2:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <ExternalLoginConfirmation>d__27 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public ExternalLoginConfirmationViewModel model;
            public string returnUrl;
            public AccountController <>4__this;
            private ExternalLoginInfo <info>5__1;
            private ApplicationUser <user>5__2;
            private IdentityResult <result>5__3;
            private ExternalLoginInfo <>s__4;
            private IdentityResult <>s__5;
            private IdentityResult <>s__6;
            private TaskAwaiter<ExternalLoginInfo> <>u__1;
            private TaskAwaiter<IdentityResult> <>u__2;
            private TaskAwaiter <>u__3;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<ExternalLoginInfo> awaiter;
                    ExternalLoginInfo info;
                    AccountController.<ExternalLoginConfirmation>d__27 d__;
                    IdentityResult result2;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_01BD;

                        case 2:
                            goto Label_027A;

                        case 3:
                            goto Label_0329;

                        default:
                            if (this.<>4__this.User.Identity.IsAuthenticated)
                            {
                                result = this.<>4__this.RedirectToAction("Index", "Manage");
                                goto Label_042C;
                            }
                            if (!this.<>4__this.ModelState.IsValid)
                            {
                                goto Label_0396;
                            }
                            awaiter = this.<>4__this.AuthenticationManager.GetExternalLoginInfoAsync().GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00E7;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ExternalLoginInfo>, AccountController.<ExternalLoginConfirmation>d__27>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<ExternalLoginInfo>();
                    this.<>1__state = num = -1;
                Label_00E7:
                    info = awaiter.GetResult();
                    awaiter = new TaskAwaiter<ExternalLoginInfo>();
                    this.<>s__4 = info;
                    this.<info>5__1 = this.<>s__4;
                    this.<>s__4 = null;
                    if (this.<info>5__1 == null)
                    {
                        result = this.<>4__this.View("ExternalLoginFailure");
                        goto Label_042C;
                    }
                    ApplicationUser user = new ApplicationUser {
                        UserName = this.model.Email,
                        Email = this.model.Email
                    };
                    this.<user>5__2 = user;
                    TaskAwaiter<IdentityResult> awaiter2 = this.<>4__this.UserManager.CreateAsync(this.<user>5__2).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_01DA;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, AccountController.<ExternalLoginConfirmation>d__27>(ref awaiter2, ref d__);
                    return;
                Label_01BD:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_01DA:
                    result2 = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<IdentityResult>();
                    this.<>s__5 = result2;
                    this.<result>5__3 = this.<>s__5;
                    this.<>s__5 = null;
                    if (!this.<result>5__3.Succeeded)
                    {
                        goto Label_036E;
                    }
                    TaskAwaiter<IdentityResult> awaiter3 = this.<>4__this.UserManager.AddLoginAsync(this.<user>5__2.Id, this.<info>5__1.Login).GetAwaiter();
                    if (awaiter3.IsCompleted)
                    {
                        goto Label_0297;
                    }
                    this.<>1__state = num = 2;
                    this.<>u__2 = awaiter3;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, AccountController.<ExternalLoginConfirmation>d__27>(ref awaiter3, ref d__);
                    return;
                Label_027A:
                    awaiter3 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_0297:
                    result2 = awaiter3.GetResult();
                    awaiter3 = new TaskAwaiter<IdentityResult>();
                    this.<>s__6 = result2;
                    this.<result>5__3 = this.<>s__6;
                    this.<>s__6 = null;
                    if (!this.<result>5__3.Succeeded)
                    {
                        goto Label_036E;
                    }
                    TaskAwaiter awaiter4 = this.<>4__this.SignInManager.SignInAsync(this.<user>5__2, false, false).GetAwaiter();
                    if (awaiter4.IsCompleted)
                    {
                        goto Label_0346;
                    }
                    this.<>1__state = num = 3;
                    this.<>u__3 = awaiter4;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, AccountController.<ExternalLoginConfirmation>d__27>(ref awaiter4, ref d__);
                    return;
                Label_0329:
                    awaiter4 = this.<>u__3;
                    this.<>u__3 = new TaskAwaiter();
                    this.<>1__state = num = -1;
                Label_0346:
                    awaiter4.GetResult();
                    awaiter4 = new TaskAwaiter();
                    result = this.<>4__this.RedirectToLocal(this.returnUrl);
                    goto Label_042C;
                Label_036E:
                    this.<>4__this.AddErrors(this.<result>5__3);
                    this.<info>5__1 = null;
                    this.<user>5__2 = null;
                    this.<result>5__3 = null;
                Label_0396:
                    if (AccountController.<>o__27.<>p__0 == null)
                    {
                        CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) };
                        AccountController.<>o__27.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ReturnUrl", typeof(AccountController), argumentInfo));
                    }
                    AccountController.<>o__27.<>p__0.Target(AccountController.<>o__27.<>p__0, this.<>4__this.ViewBag, this.returnUrl);
                    result = this.<>4__this.View(this.model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_042C:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <ForgotPassword>d__18 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public ForgotPasswordViewModel model;
            public AccountController <>4__this;
            private ApplicationUser <user>5__1;
            private ApplicationUser <>s__2;
            private bool <>s__3;
            private bool <>s__4;
            private TaskAwaiter<ApplicationUser> <>u__1;
            private TaskAwaiter<bool> <>u__2;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<ApplicationUser> awaiter;
                    ApplicationUser user;
                    AccountController.<ForgotPassword>d__18 d__;
                    bool flag3;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_013A;

                        default:
                            if (!this.<>4__this.ModelState.IsValid)
                            {
                                goto Label_01A7;
                            }
                            awaiter = this.<>4__this.UserManager.FindByNameAsync(this.model.Email).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00A0;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ApplicationUser>, AccountController.<ForgotPassword>d__18>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<ApplicationUser>();
                    this.<>1__state = num = -1;
                Label_00A0:
                    user = awaiter.GetResult();
                    awaiter = new TaskAwaiter<ApplicationUser>();
                    this.<>s__2 = user;
                    this.<user>5__1 = this.<>s__2;
                    this.<>s__2 = null;
                    this.<>s__3 = this.<user>5__1 == null;
                    if (this.<>s__3)
                    {
                        goto Label_017F;
                    }
                    TaskAwaiter<bool> awaiter2 = this.<>4__this.UserManager.IsEmailConfirmedAsync(this.<user>5__1.Id).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_0157;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, AccountController.<ForgotPassword>d__18>(ref awaiter2, ref d__);
                    return;
                Label_013A:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<bool>();
                    this.<>1__state = num = -1;
                Label_0157:
                    flag3 = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<bool>();
                    this.<>s__4 = flag3;
                    this.<>s__3 = !this.<>s__4;
                Label_017F:
                    if (this.<>s__3)
                    {
                        result = this.<>4__this.View("ForgotPasswordConfirmation");
                        goto Label_01D5;
                    }
                    this.<user>5__1 = null;
                Label_01A7:
                    result = this.<>4__this.View(this.model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_01D5:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <Login>d__11 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public LoginViewModel model;
            public string returnUrl;
            public AccountController <>4__this;
            private SignInStatus <result>5__1;
            private SignInStatus <>s__2;
            private TaskAwaiter<SignInStatus> <>u__1;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<SignInStatus> awaiter;
                    SignInStatus status;
                    if (num != 0)
                    {
                        if (this.<>4__this.ModelState.IsValid)
                        {
                            awaiter = this.<>4__this.SignInManager.PasswordSignInAsync(this.model.Email, this.model.Password, this.model.RememberMe, false).GetAwaiter();
                            if (!awaiter.IsCompleted)
                            {
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                AccountController.<Login>d__11 stateMachine = this;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<SignInStatus>, AccountController.<Login>d__11>(ref awaiter, ref stateMachine);
                                return;
                            }
                            goto Label_00C6;
                        }
                        result = this.<>4__this.View(this.model);
                        goto Label_01A8;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<SignInStatus>();
                    this.<>1__state = num = -1;
                Label_00C6:
                    status = awaiter.GetResult();
                    awaiter = new TaskAwaiter<SignInStatus>();
                    this.<>s__2 = status;
                    this.<result>5__1 = this.<>s__2;
                    switch (this.<result>5__1)
                    {
                        case SignInStatus.Success:
                            result = this.<>4__this.RedirectToLocal(this.returnUrl);
                            goto Label_01A8;

                        case SignInStatus.LockedOut:
                            result = this.<>4__this.View("Lockout");
                            goto Label_01A8;

                        case SignInStatus.RequiresVerification:
                            result = this.<>4__this.RedirectToAction("SendCode", new { 
                                ReturnUrl = this.returnUrl,
                                RememberMe = this.model.RememberMe
                            });
                            goto Label_01A8;
                    }
                    this.<>4__this.ModelState.AddModelError("", "Invalid login attempt.");
                    result = this.<>4__this.View(this.model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_01A8:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <Register>d__15 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public RegisterViewModel model;
            public AccountController <>4__this;
            private ApplicationUser <user>5__1;
            private IdentityResult <result>5__2;
            private IdentityResult <>s__3;
            private TaskAwaiter<IdentityResult> <>u__1;
            private TaskAwaiter <>u__2;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IdentityResult> awaiter;
                    IdentityResult result2;
                    AccountController.<Register>d__15 d__;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_016F;

                        default:
                        {
                            if (!this.<>4__this.ModelState.IsValid)
                            {
                                goto Label_01D5;
                            }
                            ApplicationUser user = new ApplicationUser {
                                UserName = this.model.Email,
                                Email = this.model.Email
                            };
                            this.<user>5__1 = user;
                            awaiter = this.<>4__this.UserManager.CreateAsync(this.<user>5__1, this.model.Password).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00DD;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, AccountController.<Register>d__15>(ref awaiter, ref d__);
                            return;
                        }
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_00DD:
                    result2 = awaiter.GetResult();
                    awaiter = new TaskAwaiter<IdentityResult>();
                    this.<>s__3 = result2;
                    this.<result>5__2 = this.<>s__3;
                    this.<>s__3 = null;
                    if (!this.<result>5__2.Succeeded)
                    {
                        goto Label_01B4;
                    }
                    TaskAwaiter awaiter2 = this.<>4__this.SignInManager.SignInAsync(this.<user>5__1, false, false).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_018C;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, AccountController.<Register>d__15>(ref awaiter2, ref d__);
                    return;
                Label_016F:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter();
                    this.<>1__state = num = -1;
                Label_018C:
                    awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter();
                    result = this.<>4__this.RedirectToAction("Index", "Home");
                    goto Label_0203;
                Label_01B4:
                    this.<>4__this.AddErrors(this.<result>5__2);
                    this.<user>5__1 = null;
                    this.<result>5__2 = null;
                Label_01D5:
                    result = this.<>4__this.View(this.model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_0203:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <ResetPassword>d__21 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public ResetPasswordViewModel model;
            public AccountController <>4__this;
            private ApplicationUser <user>5__1;
            private IdentityResult <result>5__2;
            private ApplicationUser <>s__3;
            private IdentityResult <>s__4;
            private TaskAwaiter<ApplicationUser> <>u__1;
            private TaskAwaiter<IdentityResult> <>u__2;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<ApplicationUser> awaiter;
                    ApplicationUser user;
                    AccountController.<ResetPassword>d__21 d__;
                    IdentityResult result2;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_017B;

                        default:
                            if (!this.<>4__this.ModelState.IsValid)
                            {
                                result = this.<>4__this.View(this.model);
                                goto Label_0228;
                            }
                            awaiter = this.<>4__this.UserManager.FindByNameAsync(this.model.Email).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00BA;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ApplicationUser>, AccountController.<ResetPassword>d__21>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<ApplicationUser>();
                    this.<>1__state = num = -1;
                Label_00BA:
                    user = awaiter.GetResult();
                    awaiter = new TaskAwaiter<ApplicationUser>();
                    this.<>s__3 = user;
                    this.<user>5__1 = this.<>s__3;
                    this.<>s__3 = null;
                    if (this.<user>5__1 == null)
                    {
                        result = this.<>4__this.RedirectToAction("ResetPasswordConfirmation", "Account");
                        goto Label_0228;
                    }
                    TaskAwaiter<IdentityResult> awaiter2 = this.<>4__this.UserManager.ResetPasswordAsync(this.<user>5__1.Id, this.model.Code, this.model.Password).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_0198;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, AccountController.<ResetPassword>d__21>(ref awaiter2, ref d__);
                    return;
                Label_017B:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_0198:
                    result2 = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<IdentityResult>();
                    this.<>s__4 = result2;
                    this.<result>5__2 = this.<>s__4;
                    this.<>s__4 = null;
                    if (this.<result>5__2.Succeeded)
                    {
                        result = this.<>4__this.RedirectToAction("ResetPasswordConfirmation", "Account");
                    }
                    else
                    {
                        this.<>4__this.AddErrors(this.<result>5__2);
                        result = this.<>4__this.View();
                    }
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_0228:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <SendCode>d__24 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public string returnUrl;
            public bool rememberMe;
            public AccountController <>4__this;
            private string <userId>5__1;
            private IList<string> <userFactors>5__2;
            private List<SelectListItem> <factorOptions>5__3;
            private string <>s__4;
            private IList<string> <>s__5;
            private TaskAwaiter<string> <>u__1;
            private TaskAwaiter<IList<string>> <>u__2;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<string> awaiter;
                    string str;
                    AccountController.<SendCode>d__24 d__;
                    IList<string> list;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_011C;

                        default:
                            awaiter = this.<>4__this.SignInManager.GetVerifiedUserIdAsync().GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_007D;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, AccountController.<SendCode>d__24>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<string>();
                    this.<>1__state = num = -1;
                Label_007D:
                    str = awaiter.GetResult();
                    awaiter = new TaskAwaiter<string>();
                    this.<>s__4 = str;
                    this.<userId>5__1 = this.<>s__4;
                    this.<>s__4 = null;
                    if (this.<userId>5__1 == null)
                    {
                        result = this.<>4__this.View("Error");
                        goto Label_01F5;
                    }
                    TaskAwaiter<IList<string>> awaiter2 = this.<>4__this.UserManager.GetValidTwoFactorProvidersAsync(this.<userId>5__1).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_0139;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IList<string>>, AccountController.<SendCode>d__24>(ref awaiter2, ref d__);
                    return;
                Label_011C:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<IList<string>>();
                    this.<>1__state = num = -1;
                Label_0139:
                    list = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<IList<string>>();
                    this.<>s__5 = list;
                    this.<userFactors>5__2 = this.<>s__5;
                    this.<>s__5 = null;
                    this.<factorOptions>5__3 = this.<userFactors>5__2.Select<string, SelectListItem>((AccountController.<>c.<>9__24_0 ?? (AccountController.<>c.<>9__24_0 = new Func<string, SelectListItem>(AccountController.<>c.<>9.<SendCode>b__24_0)))).ToList<SelectListItem>();
                    SendCodeViewModel model = new SendCodeViewModel {
                        Providers = this.<factorOptions>5__3,
                        ReturnUrl = this.returnUrl,
                        RememberMe = this.rememberMe
                    };
                    result = this.<>4__this.View(model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_01F5:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <SendCode>d__25 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public SendCodeViewModel model;
            public AccountController <>4__this;
            private bool <>s__1;
            private TaskAwaiter<bool> <>u__1;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<bool> awaiter;
                    bool flag3;
                    if (num != 0)
                    {
                        if (this.<>4__this.ModelState.IsValid)
                        {
                            awaiter = this.<>4__this.SignInManager.SendTwoFactorCodeAsync(this.model.SelectedProvider).GetAwaiter();
                            if (!awaiter.IsCompleted)
                            {
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                AccountController.<SendCode>d__25 stateMachine = this;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, AccountController.<SendCode>d__25>(ref awaiter, ref stateMachine);
                                return;
                            }
                            goto Label_00A9;
                        }
                        result = this.<>4__this.View();
                        goto Label_0136;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<bool>();
                    this.<>1__state = num = -1;
                Label_00A9:
                    flag3 = awaiter.GetResult();
                    awaiter = new TaskAwaiter<bool>();
                    this.<>s__1 = flag3;
                    if (!this.<>s__1)
                    {
                        result = this.<>4__this.View("Error");
                    }
                    else
                    {
                        result = this.<>4__this.RedirectToAction("VerifyCode", new { 
                            Provider = this.model.SelectedProvider,
                            ReturnUrl = this.model.ReturnUrl,
                            RememberMe = this.model.RememberMe
                        });
                    }
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_0136:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <VerifyCode>d__12 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public string provider;
            public string returnUrl;
            public bool rememberMe;
            public AccountController <>4__this;
            private bool <>s__1;
            private TaskAwaiter<bool> <>u__1;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<bool> awaiter;
                    if (num != 0)
                    {
                        awaiter = this.<>4__this.SignInManager.HasBeenVerifiedAsync().GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            AccountController.<VerifyCode>d__12 stateMachine = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, AccountController.<VerifyCode>d__12>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<bool>();
                        this.<>1__state = num = -1;
                    }
                    bool flag2 = awaiter.GetResult();
                    awaiter = new TaskAwaiter<bool>();
                    this.<>s__1 = flag2;
                    if (!this.<>s__1)
                    {
                        result = this.<>4__this.View("Error");
                    }
                    else
                    {
                        VerifyCodeViewModel model = new VerifyCodeViewModel {
                            Provider = this.provider,
                            ReturnUrl = this.returnUrl,
                            RememberMe = this.rememberMe
                        };
                        result = this.<>4__this.View(model);
                    }
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <VerifyCode>d__13 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public VerifyCodeViewModel model;
            public AccountController <>4__this;
            private SignInStatus <result>5__1;
            private SignInStatus <>s__2;
            private TaskAwaiter<SignInStatus> <>u__1;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<SignInStatus> awaiter;
                    SignInStatus status;
                    if (num != 0)
                    {
                        if (this.<>4__this.ModelState.IsValid)
                        {
                            awaiter = this.<>4__this.SignInManager.TwoFactorSignInAsync(this.model.Provider, this.model.Code, this.model.RememberMe, this.model.RememberBrowser).GetAwaiter();
                            if (!awaiter.IsCompleted)
                            {
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                AccountController.<VerifyCode>d__13 stateMachine = this;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<SignInStatus>, AccountController.<VerifyCode>d__13>(ref awaiter, ref stateMachine);
                                return;
                            }
                            goto Label_00D0;
                        }
                        result = this.<>4__this.View(this.model);
                        goto Label_018B;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<SignInStatus>();
                    this.<>1__state = num = -1;
                Label_00D0:
                    status = awaiter.GetResult();
                    awaiter = new TaskAwaiter<SignInStatus>();
                    this.<>s__2 = status;
                    this.<result>5__1 = this.<>s__2;
                    switch (this.<result>5__1)
                    {
                        case SignInStatus.Success:
                            result = this.<>4__this.RedirectToLocal(this.model.ReturnUrl);
                            goto Label_018B;

                        case SignInStatus.LockedOut:
                            result = this.<>4__this.View("Lockout");
                            goto Label_018B;
                    }
                    this.<>4__this.ModelState.AddModelError("", "Invalid code.");
                    result = this.<>4__this.View(this.model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_018B:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri) : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                this.LoginProvider = provider;
                this.RedirectUri = redirectUri;
                this.UserId = userId;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                AuthenticationProperties properties = new AuthenticationProperties {
                    RedirectUri = this.RedirectUri
                };
                if (this.UserId > null)
                {
                    properties.Dictionary["XsrfId"] = this.UserId;
                }
                string[] authenticationTypes = new string[] { this.LoginProvider };
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, authenticationTypes);
            }

            public string LoginProvider { get; set; }

            public string RedirectUri { get; set; }

            public string UserId { get; set; }
        }
    }
}

