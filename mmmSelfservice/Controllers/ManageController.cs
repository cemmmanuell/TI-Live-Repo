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
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private const string XsrfKey = "XsrfId";

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        public ActionResult AddPhoneNumber()
        {
            return base.View();
        }

        [AsyncStateMachine(typeof(<AddPhoneNumber>d__13)), DebuggerStepThrough, HttpPost, ValidateAntiForgeryToken]
        public Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            <AddPhoneNumber>d__13 stateMachine = new <AddPhoneNumber>d__13 {
                <>4__this = this,
                model = model,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<AddPhoneNumber>d__13>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        public ActionResult ChangePassword()
        {
            return base.View();
        }

        [AsyncStateMachine(typeof(<ChangePassword>d__20)), DebuggerStepThrough, HttpPost, ValidateAntiForgeryToken]
        public Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            <ChangePassword>d__20 stateMachine = new <ChangePassword>d__20 {
                <>4__this = this,
                model = model,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<ChangePassword>d__20>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<DisableTwoFactorAuthentication>d__15)), DebuggerStepThrough, HttpPost, ValidateAntiForgeryToken]
        public Task<ActionResult> DisableTwoFactorAuthentication()
        {
            <DisableTwoFactorAuthentication>d__15 stateMachine = new <DisableTwoFactorAuthentication>d__15 {
                <>4__this = this,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<DisableTwoFactorAuthentication>d__15>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this._userManager > null))
            {
                this._userManager.Dispose();
                this._userManager = null;
            }
            base.Dispose(disposing);
        }

        [AsyncStateMachine(typeof(<EnableTwoFactorAuthentication>d__14)), DebuggerStepThrough, HttpPost, ValidateAntiForgeryToken]
        public Task<ActionResult> EnableTwoFactorAuthentication()
        {
            <EnableTwoFactorAuthentication>d__14 stateMachine = new <EnableTwoFactorAuthentication>d__14 {
                <>4__this = this,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<EnableTwoFactorAuthentication>d__14>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        private bool HasPassword()
        {
            ApplicationUser user = this.UserManager.FindById<ApplicationUser, string>(base.User.Identity.GetUserId());
            return ((user > null) && (user.PasswordHash > null));
        }

        private bool HasPhoneNumber()
        {
            ApplicationUser user = this.UserManager.FindById<ApplicationUser, string>(base.User.Identity.GetUserId());
            return ((user > null) && (user.PhoneNumber > null));
        }

        [AsyncStateMachine(typeof(<Index>d__10)), DebuggerStepThrough]
        public Task<ActionResult> Index(ManageMessageId? message)
        {
            <Index>d__10 stateMachine = new <Index>d__10 {
                <>4__this = this,
                message = message,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<Index>d__10>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            return new AccountController.ChallengeResult(provider, base.Url.Action("LinkLoginCallback", "Manage"), base.User.Identity.GetUserId());
        }

        [AsyncStateMachine(typeof(<LinkLoginCallback>d__25)), DebuggerStepThrough]
        public Task<ActionResult> LinkLoginCallback()
        {
            <LinkLoginCallback>d__25 stateMachine = new <LinkLoginCallback>d__25 {
                <>4__this = this,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<LinkLoginCallback>d__25>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<ManageLogins>d__23)), DebuggerStepThrough]
        public Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            <ManageLogins>d__23 stateMachine = new <ManageLogins>d__23 {
                <>4__this = this,
                message = message,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<ManageLogins>d__23>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<RemoveLogin>d__11)), DebuggerStepThrough, HttpPost, ValidateAntiForgeryToken]
        public Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            <RemoveLogin>d__11 stateMachine = new <RemoveLogin>d__11 {
                <>4__this = this,
                loginProvider = loginProvider,
                providerKey = providerKey,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<RemoveLogin>d__11>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<RemovePhoneNumber>d__18)), DebuggerStepThrough, HttpPost, ValidateAntiForgeryToken]
        public Task<ActionResult> RemovePhoneNumber()
        {
            <RemovePhoneNumber>d__18 stateMachine = new <RemovePhoneNumber>d__18 {
                <>4__this = this,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<RemovePhoneNumber>d__18>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        public ActionResult SetPassword()
        {
            return base.View();
        }

        [AsyncStateMachine(typeof(<SetPassword>d__22)), DebuggerStepThrough, HttpPost, ValidateAntiForgeryToken]
        public Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            <SetPassword>d__22 stateMachine = new <SetPassword>d__22 {
                <>4__this = this,
                model = model,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<SetPassword>d__22>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<VerifyPhoneNumber>d__17)), DebuggerStepThrough, HttpPost, ValidateAntiForgeryToken]
        public Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            <VerifyPhoneNumber>d__17 stateMachine = new <VerifyPhoneNumber>d__17 {
                <>4__this = this,
                model = model,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<VerifyPhoneNumber>d__17>(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<VerifyPhoneNumber>d__16)), DebuggerStepThrough]
        public Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            <VerifyPhoneNumber>d__16 stateMachine = new <VerifyPhoneNumber>d__16 {
                <>4__this = this,
                phoneNumber = phoneNumber,
                <>t__builder = AsyncTaskMethodBuilder<ActionResult>.Create(),
                <>1__state = -1
            };
            stateMachine.<>t__builder.Start<<VerifyPhoneNumber>d__16>(ref stateMachine);
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

        [CompilerGenerated]
        private static class <>o__10
        {
            public static CallSite<Func<CallSite, object, string, object>> <>p__0;
        }

        [CompilerGenerated]
        private static class <>o__23
        {
            public static CallSite<Func<CallSite, object, string, object>> <>p__0;
            public static CallSite<Func<CallSite, object, bool, object>> <>p__1;
        }

        [CompilerGenerated]
        private sealed class <AddPhoneNumber>d__13 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public AddPhoneNumberViewModel model;
            public ManageController <>4__this;
            private string <code>5__1;
            private string <>s__2;
            private IdentityMessage <message>5__3;
            private TaskAwaiter<string> <>u__1;
            private TaskAwaiter <>u__2;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<string> awaiter;
                    string str;
                    ManageController.<AddPhoneNumber>d__13 d__;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_01A6;

                        default:
                            if (!this.<>4__this.ModelState.IsValid)
                            {
                                result = this.<>4__this.View(this.model);
                                goto Label_0218;
                            }
                            awaiter = this.<>4__this.UserManager.GenerateChangePhoneNumberTokenAsync(this.<>4__this.User.Identity.GetUserId(), this.model.Number).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00CF;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, ManageController.<AddPhoneNumber>d__13>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<string>();
                    this.<>1__state = num = -1;
                Label_00CF:
                    str = awaiter.GetResult();
                    awaiter = new TaskAwaiter<string>();
                    this.<>s__2 = str;
                    this.<code>5__1 = this.<>s__2;
                    this.<>s__2 = null;
                    if (this.<>4__this.UserManager.SmsService <= null)
                    {
                        goto Label_01DB;
                    }
                    IdentityMessage message = new IdentityMessage {
                        Destination = this.model.Number,
                        Body = "Your security code is: " + this.<code>5__1
                    };
                    this.<message>5__3 = message;
                    TaskAwaiter awaiter2 = this.<>4__this.UserManager.SmsService.SendAsync(this.<message>5__3).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_01C3;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ManageController.<AddPhoneNumber>d__13>(ref awaiter2, ref d__);
                    return;
                Label_01A6:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter();
                    this.<>1__state = num = -1;
                Label_01C3:
                    awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter();
                    this.<message>5__3 = null;
                Label_01DB:
                    result = this.<>4__this.RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = this.model.Number });
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_0218:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <ChangePassword>d__20 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public ChangePasswordViewModel model;
            public ManageController <>4__this;
            private IdentityResult <result>5__1;
            private IdentityResult <>s__2;
            private ApplicationUser <user>5__3;
            private ApplicationUser <>s__4;
            private TaskAwaiter<IdentityResult> <>u__1;
            private TaskAwaiter<ApplicationUser> <>u__2;
            private TaskAwaiter <>u__3;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IdentityResult> awaiter;
                    IdentityResult result2;
                    ManageController.<ChangePassword>d__20 d__;
                    ApplicationUser user;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_0187;

                        case 2:
                            goto Label_0234;

                        default:
                            if (!this.<>4__this.ModelState.IsValid)
                            {
                                result = this.<>4__this.View(this.model);
                                goto Label_02BB;
                            }
                            awaiter = this.<>4__this.UserManager.ChangePasswordAsync(this.<>4__this.User.Identity.GetUserId(), this.model.OldPassword, this.model.NewPassword).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00E8;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, ManageController.<ChangePassword>d__20>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_00E8:
                    result2 = awaiter.GetResult();
                    awaiter = new TaskAwaiter<IdentityResult>();
                    this.<>s__2 = result2;
                    this.<result>5__1 = this.<>s__2;
                    this.<>s__2 = null;
                    if (!this.<result>5__1.Succeeded)
                    {
                        goto Label_027B;
                    }
                    TaskAwaiter<ApplicationUser> awaiter2 = this.<>4__this.UserManager.FindByIdAsync(this.<>4__this.User.Identity.GetUserId()).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_01A4;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ApplicationUser>, ManageController.<ChangePassword>d__20>(ref awaiter2, ref d__);
                    return;
                Label_0187:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<ApplicationUser>();
                    this.<>1__state = num = -1;
                Label_01A4:
                    user = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<ApplicationUser>();
                    this.<>s__4 = user;
                    this.<user>5__3 = this.<>s__4;
                    this.<>s__4 = null;
                    if (this.<user>5__3 <= null)
                    {
                        goto Label_0262;
                    }
                    TaskAwaiter awaiter3 = this.<>4__this.SignInManager.SignInAsync(this.<user>5__3, false, false).GetAwaiter();
                    if (awaiter3.IsCompleted)
                    {
                        goto Label_0251;
                    }
                    this.<>1__state = num = 2;
                    this.<>u__3 = awaiter3;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ManageController.<ChangePassword>d__20>(ref awaiter3, ref d__);
                    return;
                Label_0234:
                    awaiter3 = this.<>u__3;
                    this.<>u__3 = new TaskAwaiter();
                    this.<>1__state = num = -1;
                Label_0251:
                    awaiter3.GetResult();
                    awaiter3 = new TaskAwaiter();
                Label_0262:
                    result = this.<>4__this.RedirectToAction("Index", new { Message = ManageController.ManageMessageId.ChangePasswordSuccess });
                    goto Label_02BB;
                Label_027B:
                    this.<>4__this.AddErrors(this.<result>5__1);
                    result = this.<>4__this.View(this.model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_02BB:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <DisableTwoFactorAuthentication>d__15 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public ManageController <>4__this;
            private ApplicationUser <user>5__1;
            private ApplicationUser <>s__2;
            private TaskAwaiter<IdentityResult> <>u__1;
            private TaskAwaiter<ApplicationUser> <>u__2;
            private TaskAwaiter <>u__3;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IdentityResult> awaiter;
                    ManageController.<DisableTwoFactorAuthentication>d__15 d__;
                    ApplicationUser user;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_010D;

                        case 2:
                            goto Label_01B3;

                        default:
                            awaiter = this.<>4__this.UserManager.SetTwoFactorEnabledAsync(this.<>4__this.User.Identity.GetUserId(), false).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00A0;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, ManageController.<DisableTwoFactorAuthentication>d__15>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_00A0:
                    awaiter.GetResult();
                    awaiter = new TaskAwaiter<IdentityResult>();
                    TaskAwaiter<ApplicationUser> awaiter2 = this.<>4__this.UserManager.FindByIdAsync(this.<>4__this.User.Identity.GetUserId()).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_012A;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ApplicationUser>, ManageController.<DisableTwoFactorAuthentication>d__15>(ref awaiter2, ref d__);
                    return;
                Label_010D:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<ApplicationUser>();
                    this.<>1__state = num = -1;
                Label_012A:
                    user = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<ApplicationUser>();
                    this.<>s__2 = user;
                    this.<user>5__1 = this.<>s__2;
                    this.<>s__2 = null;
                    if (this.<user>5__1 <= null)
                    {
                        goto Label_01E1;
                    }
                    TaskAwaiter awaiter3 = this.<>4__this.SignInManager.SignInAsync(this.<user>5__1, false, false).GetAwaiter();
                    if (awaiter3.IsCompleted)
                    {
                        goto Label_01D0;
                    }
                    this.<>1__state = num = 2;
                    this.<>u__3 = awaiter3;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ManageController.<DisableTwoFactorAuthentication>d__15>(ref awaiter3, ref d__);
                    return;
                Label_01B3:
                    awaiter3 = this.<>u__3;
                    this.<>u__3 = new TaskAwaiter();
                    this.<>1__state = num = -1;
                Label_01D0:
                    awaiter3.GetResult();
                    awaiter3 = new TaskAwaiter();
                Label_01E1:
                    result = this.<>4__this.RedirectToAction("Index", "Manage");
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
        private sealed class <EnableTwoFactorAuthentication>d__14 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public ManageController <>4__this;
            private ApplicationUser <user>5__1;
            private ApplicationUser <>s__2;
            private TaskAwaiter<IdentityResult> <>u__1;
            private TaskAwaiter<ApplicationUser> <>u__2;
            private TaskAwaiter <>u__3;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IdentityResult> awaiter;
                    ManageController.<EnableTwoFactorAuthentication>d__14 d__;
                    ApplicationUser user;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_010D;

                        case 2:
                            goto Label_01B3;

                        default:
                            awaiter = this.<>4__this.UserManager.SetTwoFactorEnabledAsync(this.<>4__this.User.Identity.GetUserId(), true).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00A0;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, ManageController.<EnableTwoFactorAuthentication>d__14>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_00A0:
                    awaiter.GetResult();
                    awaiter = new TaskAwaiter<IdentityResult>();
                    TaskAwaiter<ApplicationUser> awaiter2 = this.<>4__this.UserManager.FindByIdAsync(this.<>4__this.User.Identity.GetUserId()).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_012A;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ApplicationUser>, ManageController.<EnableTwoFactorAuthentication>d__14>(ref awaiter2, ref d__);
                    return;
                Label_010D:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<ApplicationUser>();
                    this.<>1__state = num = -1;
                Label_012A:
                    user = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<ApplicationUser>();
                    this.<>s__2 = user;
                    this.<user>5__1 = this.<>s__2;
                    this.<>s__2 = null;
                    if (this.<user>5__1 <= null)
                    {
                        goto Label_01E1;
                    }
                    TaskAwaiter awaiter3 = this.<>4__this.SignInManager.SignInAsync(this.<user>5__1, false, false).GetAwaiter();
                    if (awaiter3.IsCompleted)
                    {
                        goto Label_01D0;
                    }
                    this.<>1__state = num = 2;
                    this.<>u__3 = awaiter3;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ManageController.<EnableTwoFactorAuthentication>d__14>(ref awaiter3, ref d__);
                    return;
                Label_01B3:
                    awaiter3 = this.<>u__3;
                    this.<>u__3 = new TaskAwaiter();
                    this.<>1__state = num = -1;
                Label_01D0:
                    awaiter3.GetResult();
                    awaiter3 = new TaskAwaiter();
                Label_01E1:
                    result = this.<>4__this.RedirectToAction("Index", "Manage");
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
        private sealed class <Index>d__10 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public ManageController.ManageMessageId? message;
            public ManageController <>4__this;
            private string <userId>5__1;
            private IndexViewModel <model>5__2;
            private IndexViewModel <>s__3;
            private string <>s__4;
            private IndexViewModel <>s__5;
            private bool <>s__6;
            private IndexViewModel <>s__7;
            private IList<UserLoginInfo> <>s__8;
            private IndexViewModel <>s__9;
            private bool <>s__10;
            private IndexViewModel <>s__11;
            private TaskAwaiter<string> <>u__1;
            private TaskAwaiter<bool> <>u__2;
            private TaskAwaiter<IList<UserLoginInfo>> <>u__3;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<string> awaiter;
                    string str;
                    ManageController.<Index>d__10 d__;
                    bool flag;
                    IList<UserLoginInfo> list;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_02C0;

                        case 2:
                            goto Label_0363;

                        case 3:
                            goto Label_0406;

                        default:
                        {
                            if (ManageController.<>o__10.<>p__0 == null)
                            {
                                CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) };
                                ManageController.<>o__10.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "StatusMessage", typeof(ManageController), argumentInfo));
                            }
                            ManageController.ManageMessageId? message = this.message;
                            ManageController.ManageMessageId changePasswordSuccess = ManageController.ManageMessageId.ChangePasswordSuccess;
                            ManageController.<>o__10.<>p__0.Target(ManageController.<>o__10.<>p__0, this.<>4__this.ViewBag, ((((ManageController.ManageMessageId) message.GetValueOrDefault()) == changePasswordSuccess) ? ((string) message.HasValue) : ((string) false)) ? "Your password has been changed." : (((((ManageController.ManageMessageId) (message = this.message).GetValueOrDefault()) == (changePasswordSuccess = ManageController.ManageMessageId.SetPasswordSuccess)) ? ((string) message.HasValue) : ((string) false)) ? "Your password has been set." : (((((ManageController.ManageMessageId) (message = this.message).GetValueOrDefault()) == (changePasswordSuccess = ManageController.ManageMessageId.SetTwoFactorSuccess)) ? ((string) message.HasValue) : ((string) false)) ? "Your two-factor authentication provider has been set." : (((((ManageController.ManageMessageId) (message = this.message).GetValueOrDefault()) == (changePasswordSuccess = ManageController.ManageMessageId.Error)) ? ((string) message.HasValue) : ((string) false)) ? "An error has occurred." : (((((ManageController.ManageMessageId) (message = this.message).GetValueOrDefault()) == (changePasswordSuccess = ManageController.ManageMessageId.AddPhoneSuccess)) ? ((string) message.HasValue) : ((string) false)) ? "Your phone number was added." : (((((ManageController.ManageMessageId) (message = this.message).GetValueOrDefault()) == (changePasswordSuccess = ManageController.ManageMessageId.RemovePhoneSuccess)) ? ((string) message.HasValue) : ((string) false)) ? "Your phone number was removed." : ""))))));
                            this.<userId>5__1 = this.<>4__this.User.Identity.GetUserId();
                            this.<>s__11 = new IndexViewModel();
                            this.<>s__11.HasPassword = this.<>4__this.HasPassword();
                            this.<>s__3 = this.<>s__11;
                            awaiter = this.<>4__this.UserManager.GetPhoneNumberAsync(this.<userId>5__1).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_023A;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, ManageController.<Index>d__10>(ref awaiter, ref d__);
                            return;
                        }
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<string>();
                    this.<>1__state = num = -1;
                Label_023A:
                    str = awaiter.GetResult();
                    awaiter = new TaskAwaiter<string>();
                    this.<>s__4 = str;
                    this.<>s__3.PhoneNumber = this.<>s__4;
                    this.<>s__5 = this.<>s__11;
                    TaskAwaiter<bool> awaiter2 = this.<>4__this.UserManager.GetTwoFactorEnabledAsync(this.<userId>5__1).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_02DD;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, ManageController.<Index>d__10>(ref awaiter2, ref d__);
                    return;
                Label_02C0:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<bool>();
                    this.<>1__state = num = -1;
                Label_02DD:
                    flag = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<bool>();
                    this.<>s__6 = flag;
                    this.<>s__5.TwoFactor = this.<>s__6;
                    this.<>s__7 = this.<>s__11;
                    TaskAwaiter<IList<UserLoginInfo>> awaiter3 = this.<>4__this.UserManager.GetLoginsAsync(this.<userId>5__1).GetAwaiter();
                    if (awaiter3.IsCompleted)
                    {
                        goto Label_0380;
                    }
                    this.<>1__state = num = 2;
                    this.<>u__3 = awaiter3;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IList<UserLoginInfo>>, ManageController.<Index>d__10>(ref awaiter3, ref d__);
                    return;
                Label_0363:
                    awaiter3 = this.<>u__3;
                    this.<>u__3 = new TaskAwaiter<IList<UserLoginInfo>>();
                    this.<>1__state = num = -1;
                Label_0380:
                    list = awaiter3.GetResult();
                    awaiter3 = new TaskAwaiter<IList<UserLoginInfo>>();
                    this.<>s__8 = list;
                    this.<>s__7.Logins = this.<>s__8;
                    this.<>s__9 = this.<>s__11;
                    TaskAwaiter<bool> awaiter4 = this.<>4__this.AuthenticationManager.TwoFactorBrowserRememberedAsync(this.<userId>5__1).GetAwaiter();
                    if (awaiter4.IsCompleted)
                    {
                        goto Label_0423;
                    }
                    this.<>1__state = num = 3;
                    this.<>u__2 = awaiter4;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, ManageController.<Index>d__10>(ref awaiter4, ref d__);
                    return;
                Label_0406:
                    awaiter4 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<bool>();
                    this.<>1__state = num = -1;
                Label_0423:
                    flag = awaiter4.GetResult();
                    awaiter4 = new TaskAwaiter<bool>();
                    this.<>s__10 = flag;
                    this.<>s__9.BrowserRemembered = this.<>s__10;
                    this.<model>5__2 = this.<>s__11;
                    this.<>s__3 = null;
                    this.<>s__4 = null;
                    this.<>s__5 = null;
                    this.<>s__7 = null;
                    this.<>s__8 = null;
                    this.<>s__9 = null;
                    this.<>s__11 = null;
                    result = this.<>4__this.View(this.<model>5__2);
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
        private sealed class <LinkLoginCallback>d__25 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public ManageController <>4__this;
            private ExternalLoginInfo <loginInfo>5__1;
            private IdentityResult <result>5__2;
            private ExternalLoginInfo <>s__3;
            private IdentityResult <>s__4;
            private TaskAwaiter<ExternalLoginInfo> <>u__1;
            private TaskAwaiter<IdentityResult> <>u__2;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<ExternalLoginInfo> awaiter;
                    ExternalLoginInfo info;
                    ManageController.<LinkLoginCallback>d__25 d__;
                    IdentityResult result2;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_0156;

                        default:
                            awaiter = this.<>4__this.AuthenticationManager.GetExternalLoginInfoAsync("XsrfId", this.<>4__this.User.Identity.GetUserId()).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_0097;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ExternalLoginInfo>, ManageController.<LinkLoginCallback>d__25>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<ExternalLoginInfo>();
                    this.<>1__state = num = -1;
                Label_0097:
                    info = awaiter.GetResult();
                    awaiter = new TaskAwaiter<ExternalLoginInfo>();
                    this.<>s__3 = info;
                    this.<loginInfo>5__1 = this.<>s__3;
                    this.<>s__3 = null;
                    if (this.<loginInfo>5__1 == null)
                    {
                        result = this.<>4__this.RedirectToAction("ManageLogins", new { Message = ManageController.ManageMessageId.Error });
                        goto Label_01F1;
                    }
                    TaskAwaiter<IdentityResult> awaiter2 = this.<>4__this.UserManager.AddLoginAsync(this.<>4__this.User.Identity.GetUserId(), this.<loginInfo>5__1.Login).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_0173;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, ManageController.<LinkLoginCallback>d__25>(ref awaiter2, ref d__);
                    return;
                Label_0156:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_0173:
                    result2 = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<IdentityResult>();
                    this.<>s__4 = result2;
                    this.<result>5__2 = this.<>s__4;
                    this.<>s__4 = null;
                    result = this.<result>5__2.Succeeded ? this.<>4__this.RedirectToAction("ManageLogins") : this.<>4__this.RedirectToAction("ManageLogins", new { Message = ManageController.ManageMessageId.Error });
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_01F1:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <ManageLogins>d__23 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public ManageController.ManageMessageId? message;
            public ManageController <>4__this;
            private ManageController.<>c__DisplayClass23_0 <>8__1;
            private ApplicationUser <user>5__2;
            private List<AuthenticationDescription> <otherLogins>5__3;
            private ApplicationUser <>s__4;
            private IList<UserLoginInfo> <>s__5;
            private TaskAwaiter<ApplicationUser> <>u__1;
            private ManageController.<>c__DisplayClass23_0 <>s__6;
            private TaskAwaiter<IList<UserLoginInfo>> <>u__2;

            private unsafe void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<ApplicationUser> awaiter;
                    ApplicationUser user;
                    ManageController.<ManageLogins>d__23 d__;
                    IList<UserLoginInfo> list;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_021F;

                        default:
                        {
                            this.<>8__1 = new ManageController.<>c__DisplayClass23_0();
                            if (ManageController.<>o__23.<>p__0 == null)
                            {
                                CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) };
                                ManageController.<>o__23.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "StatusMessage", typeof(ManageController), argumentInfo));
                            }
                            ManageController.ManageMessageId? message = this.message;
                            ManageController.ManageMessageId removeLoginSuccess = ManageController.ManageMessageId.RemoveLoginSuccess;
                            ManageController.<>o__23.<>p__0.Target(ManageController.<>o__23.<>p__0, this.<>4__this.ViewBag, ((((ManageController.ManageMessageId) message.GetValueOrDefault()) == removeLoginSuccess) ? ((string) message.HasValue) : ((string) false)) ? "The external login was removed." : (((((ManageController.ManageMessageId) (message = this.message).GetValueOrDefault()) == (removeLoginSuccess = ManageController.ManageMessageId.Error)) ? ((string) message.HasValue) : ((string) false)) ? "An error has occurred." : ""));
                            awaiter = this.<>4__this.UserManager.FindByIdAsync(this.<>4__this.User.Identity.GetUserId()).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_0156;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ApplicationUser>, ManageController.<ManageLogins>d__23>(ref awaiter, ref d__);
                            return;
                        }
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<ApplicationUser>();
                    this.<>1__state = num = -1;
                Label_0156:
                    user = awaiter.GetResult();
                    awaiter = new TaskAwaiter<ApplicationUser>();
                    this.<>s__4 = user;
                    this.<user>5__2 = this.<>s__4;
                    this.<>s__4 = null;
                    if (this.<user>5__2 == null)
                    {
                        result = this.<>4__this.View("Error");
                        goto Label_037C;
                    }
                    this.<>s__6 = this.<>8__1;
                    ref IList<UserLoginInfo> listRef = (IList<UserLoginInfo>) &this.<>s__6.userLogins;
                    TaskAwaiter<IList<UserLoginInfo>> awaiter2 = this.<>4__this.UserManager.GetLoginsAsync(this.<>4__this.User.Identity.GetUserId()).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_023C;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IList<UserLoginInfo>>, ManageController.<ManageLogins>d__23>(ref awaiter2, ref d__);
                    return;
                Label_021F:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<IList<UserLoginInfo>>();
                    this.<>1__state = num = -1;
                Label_023C:
                    list = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<IList<UserLoginInfo>>();
                    this.<>s__5 = list;
                    this.<>s__6.userLogins = this.<>s__5;
                    this.<>s__6 = null;
                    this.<>s__5 = null;
                    this.<otherLogins>5__3 = this.<>4__this.AuthenticationManager.GetExternalAuthenticationTypes().Where<AuthenticationDescription>(new Func<AuthenticationDescription, bool>(this.<>8__1.<ManageLogins>b__0)).ToList<AuthenticationDescription>();
                    if (ManageController.<>o__23.<>p__1 == null)
                    {
                        CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null), CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null) };
                        ManageController.<>o__23.<>p__1 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ShowRemoveButton", typeof(ManageController), argumentInfo));
                    }
                    ManageController.<>o__23.<>p__1.Target(ManageController.<>o__23.<>p__1, this.<>4__this.ViewBag, (this.<user>5__2.PasswordHash != null) || (this.<>8__1.userLogins.Count > 1));
                    ManageLoginsViewModel model = new ManageLoginsViewModel {
                        CurrentLogins = this.<>8__1.userLogins,
                        OtherLogins = this.<otherLogins>5__3
                    };
                    result = this.<>4__this.View(model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_037C:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <RemoveLogin>d__11 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public string loginProvider;
            public string providerKey;
            public ManageController <>4__this;
            private ManageController.ManageMessageId? <message>5__1;
            private IdentityResult <result>5__2;
            private IdentityResult <>s__3;
            private ApplicationUser <user>5__4;
            private ApplicationUser <>s__5;
            private TaskAwaiter<IdentityResult> <>u__1;
            private TaskAwaiter<ApplicationUser> <>u__2;
            private TaskAwaiter <>u__3;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IdentityResult> awaiter;
                    IdentityResult result2;
                    ManageController.<RemoveLogin>d__11 d__;
                    ApplicationUser user;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_014E;

                        case 2:
                            goto Label_01FB;

                        default:
                            awaiter = this.<>4__this.UserManager.RemoveLoginAsync(this.<>4__this.User.Identity.GetUserId(), new UserLoginInfo(this.loginProvider, this.providerKey)).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00B1;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, ManageController.<RemoveLogin>d__11>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_00B1:
                    result2 = awaiter.GetResult();
                    awaiter = new TaskAwaiter<IdentityResult>();
                    this.<>s__3 = result2;
                    this.<result>5__2 = this.<>s__3;
                    this.<>s__3 = null;
                    if (!this.<result>5__2.Succeeded)
                    {
                        goto Label_023F;
                    }
                    TaskAwaiter<ApplicationUser> awaiter2 = this.<>4__this.UserManager.FindByIdAsync(this.<>4__this.User.Identity.GetUserId()).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_016B;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ApplicationUser>, ManageController.<RemoveLogin>d__11>(ref awaiter2, ref d__);
                    return;
                Label_014E:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<ApplicationUser>();
                    this.<>1__state = num = -1;
                Label_016B:
                    user = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<ApplicationUser>();
                    this.<>s__5 = user;
                    this.<user>5__4 = this.<>s__5;
                    this.<>s__5 = null;
                    if (this.<user>5__4 <= null)
                    {
                        goto Label_0229;
                    }
                    TaskAwaiter awaiter3 = this.<>4__this.SignInManager.SignInAsync(this.<user>5__4, false, false).GetAwaiter();
                    if (awaiter3.IsCompleted)
                    {
                        goto Label_0218;
                    }
                    this.<>1__state = num = 2;
                    this.<>u__3 = awaiter3;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ManageController.<RemoveLogin>d__11>(ref awaiter3, ref d__);
                    return;
                Label_01FB:
                    awaiter3 = this.<>u__3;
                    this.<>u__3 = new TaskAwaiter();
                    this.<>1__state = num = -1;
                Label_0218:
                    awaiter3.GetResult();
                    awaiter3 = new TaskAwaiter();
                Label_0229:
                    this.<message>5__1 = 4;
                    this.<user>5__4 = null;
                    goto Label_024D;
                Label_023F:
                    this.<message>5__1 = 6;
                Label_024D:
                    result = this.<>4__this.RedirectToAction("ManageLogins", new { Message = this.<message>5__1 });
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
        private sealed class <RemovePhoneNumber>d__18 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public ManageController <>4__this;
            private IdentityResult <result>5__1;
            private ApplicationUser <user>5__2;
            private IdentityResult <>s__3;
            private ApplicationUser <>s__4;
            private TaskAwaiter<IdentityResult> <>u__1;
            private TaskAwaiter<ApplicationUser> <>u__2;
            private TaskAwaiter <>u__3;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IdentityResult> awaiter;
                    IdentityResult result2;
                    ManageController.<RemovePhoneNumber>d__18 d__;
                    ApplicationUser user;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_015A;

                        case 2:
                            goto Label_0201;

                        default:
                            awaiter = this.<>4__this.UserManager.SetPhoneNumberAsync(this.<>4__this.User.Identity.GetUserId(), null).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00A1;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, ManageController.<RemovePhoneNumber>d__18>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_00A1:
                    result2 = awaiter.GetResult();
                    awaiter = new TaskAwaiter<IdentityResult>();
                    this.<>s__3 = result2;
                    this.<result>5__1 = this.<>s__3;
                    this.<>s__3 = null;
                    if (!this.<result>5__1.Succeeded)
                    {
                        result = this.<>4__this.RedirectToAction("Index", new { Message = ManageController.ManageMessageId.Error });
                        goto Label_0262;
                    }
                    TaskAwaiter<ApplicationUser> awaiter2 = this.<>4__this.UserManager.FindByIdAsync(this.<>4__this.User.Identity.GetUserId()).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_0177;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ApplicationUser>, ManageController.<RemovePhoneNumber>d__18>(ref awaiter2, ref d__);
                    return;
                Label_015A:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<ApplicationUser>();
                    this.<>1__state = num = -1;
                Label_0177:
                    user = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<ApplicationUser>();
                    this.<>s__4 = user;
                    this.<user>5__2 = this.<>s__4;
                    this.<>s__4 = null;
                    if (this.<user>5__2 <= null)
                    {
                        goto Label_022F;
                    }
                    TaskAwaiter awaiter3 = this.<>4__this.SignInManager.SignInAsync(this.<user>5__2, false, false).GetAwaiter();
                    if (awaiter3.IsCompleted)
                    {
                        goto Label_021E;
                    }
                    this.<>1__state = num = 2;
                    this.<>u__3 = awaiter3;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ManageController.<RemovePhoneNumber>d__18>(ref awaiter3, ref d__);
                    return;
                Label_0201:
                    awaiter3 = this.<>u__3;
                    this.<>u__3 = new TaskAwaiter();
                    this.<>1__state = num = -1;
                Label_021E:
                    awaiter3.GetResult();
                    awaiter3 = new TaskAwaiter();
                Label_022F:
                    result = this.<>4__this.RedirectToAction("Index", new { Message = ManageController.ManageMessageId.RemovePhoneSuccess });
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_0262:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <SetPassword>d__22 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public SetPasswordViewModel model;
            public ManageController <>4__this;
            private IdentityResult <result>5__1;
            private IdentityResult <>s__2;
            private ApplicationUser <user>5__3;
            private ApplicationUser <>s__4;
            private TaskAwaiter<IdentityResult> <>u__1;
            private TaskAwaiter<ApplicationUser> <>u__2;
            private TaskAwaiter <>u__3;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IdentityResult> awaiter;
                    IdentityResult result2;
                    ManageController.<SetPassword>d__22 d__;
                    ApplicationUser user;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_0165;

                        case 2:
                            goto Label_0212;

                        default:
                            if (!this.<>4__this.ModelState.IsValid)
                            {
                                goto Label_0273;
                            }
                            awaiter = this.<>4__this.UserManager.AddPasswordAsync(this.<>4__this.User.Identity.GetUserId(), this.model.NewPassword).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00C6;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, ManageController.<SetPassword>d__22>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_00C6:
                    result2 = awaiter.GetResult();
                    awaiter = new TaskAwaiter<IdentityResult>();
                    this.<>s__2 = result2;
                    this.<result>5__1 = this.<>s__2;
                    this.<>s__2 = null;
                    if (!this.<result>5__1.Succeeded)
                    {
                        goto Label_0259;
                    }
                    TaskAwaiter<ApplicationUser> awaiter2 = this.<>4__this.UserManager.FindByIdAsync(this.<>4__this.User.Identity.GetUserId()).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_0182;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ApplicationUser>, ManageController.<SetPassword>d__22>(ref awaiter2, ref d__);
                    return;
                Label_0165:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<ApplicationUser>();
                    this.<>1__state = num = -1;
                Label_0182:
                    user = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<ApplicationUser>();
                    this.<>s__4 = user;
                    this.<user>5__3 = this.<>s__4;
                    this.<>s__4 = null;
                    if (this.<user>5__3 <= null)
                    {
                        goto Label_0240;
                    }
                    TaskAwaiter awaiter3 = this.<>4__this.SignInManager.SignInAsync(this.<user>5__3, false, false).GetAwaiter();
                    if (awaiter3.IsCompleted)
                    {
                        goto Label_022F;
                    }
                    this.<>1__state = num = 2;
                    this.<>u__3 = awaiter3;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ManageController.<SetPassword>d__22>(ref awaiter3, ref d__);
                    return;
                Label_0212:
                    awaiter3 = this.<>u__3;
                    this.<>u__3 = new TaskAwaiter();
                    this.<>1__state = num = -1;
                Label_022F:
                    awaiter3.GetResult();
                    awaiter3 = new TaskAwaiter();
                Label_0240:
                    result = this.<>4__this.RedirectToAction("Index", new { Message = ManageController.ManageMessageId.SetPasswordSuccess });
                    goto Label_02A1;
                Label_0259:
                    this.<>4__this.AddErrors(this.<result>5__1);
                    this.<result>5__1 = null;
                Label_0273:
                    result = this.<>4__this.View(this.model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_02A1:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class <VerifyPhoneNumber>d__16 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public string phoneNumber;
            public ManageController <>4__this;
            private string <code>5__1;
            private string <>s__2;
            private TaskAwaiter<string> <>u__1;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<string> awaiter;
                    if (num != 0)
                    {
                        awaiter = this.<>4__this.UserManager.GenerateChangePhoneNumberTokenAsync(this.<>4__this.User.Identity.GetUserId(), this.phoneNumber).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            ManageController.<VerifyPhoneNumber>d__16 stateMachine = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, ManageController.<VerifyPhoneNumber>d__16>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<string>();
                        this.<>1__state = num = -1;
                    }
                    string str = awaiter.GetResult();
                    awaiter = new TaskAwaiter<string>();
                    this.<>s__2 = str;
                    this.<code>5__1 = this.<>s__2;
                    this.<>s__2 = null;
                    result = (this.phoneNumber == null) ? this.<>4__this.View("Error") : this.<>4__this.View(new VerifyPhoneNumberViewModel());
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
        private sealed class <VerifyPhoneNumber>d__17 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<ActionResult> <>t__builder;
            public VerifyPhoneNumberViewModel model;
            public ManageController <>4__this;
            private IdentityResult <result>5__1;
            private IdentityResult <>s__2;
            private ApplicationUser <user>5__3;
            private ApplicationUser <>s__4;
            private TaskAwaiter<IdentityResult> <>u__1;
            private TaskAwaiter<ApplicationUser> <>u__2;
            private TaskAwaiter <>u__3;

            private void MoveNext()
            {
                ActionResult result;
                int num = this.<>1__state;
                try
                {
                    TaskAwaiter<IdentityResult> awaiter;
                    IdentityResult result2;
                    ManageController.<VerifyPhoneNumber>d__17 d__;
                    ApplicationUser user;
                    switch (num)
                    {
                        case 0:
                            break;

                        case 1:
                            goto Label_0187;

                        case 2:
                            goto Label_0234;

                        default:
                            if (!this.<>4__this.ModelState.IsValid)
                            {
                                result = this.<>4__this.View(this.model);
                                goto Label_02C4;
                            }
                            awaiter = this.<>4__this.UserManager.ChangePhoneNumberAsync(this.<>4__this.User.Identity.GetUserId(), this.model.PhoneNumber, this.model.Code).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto Label_00E8;
                            }
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            d__ = this;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<IdentityResult>, ManageController.<VerifyPhoneNumber>d__17>(ref awaiter, ref d__);
                            return;
                    }
                    awaiter = this.<>u__1;
                    this.<>u__1 = new TaskAwaiter<IdentityResult>();
                    this.<>1__state = num = -1;
                Label_00E8:
                    result2 = awaiter.GetResult();
                    awaiter = new TaskAwaiter<IdentityResult>();
                    this.<>s__2 = result2;
                    this.<result>5__1 = this.<>s__2;
                    this.<>s__2 = null;
                    if (!this.<result>5__1.Succeeded)
                    {
                        goto Label_027B;
                    }
                    TaskAwaiter<ApplicationUser> awaiter2 = this.<>4__this.UserManager.FindByIdAsync(this.<>4__this.User.Identity.GetUserId()).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto Label_01A4;
                    }
                    this.<>1__state = num = 1;
                    this.<>u__2 = awaiter2;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<ApplicationUser>, ManageController.<VerifyPhoneNumber>d__17>(ref awaiter2, ref d__);
                    return;
                Label_0187:
                    awaiter2 = this.<>u__2;
                    this.<>u__2 = new TaskAwaiter<ApplicationUser>();
                    this.<>1__state = num = -1;
                Label_01A4:
                    user = awaiter2.GetResult();
                    awaiter2 = new TaskAwaiter<ApplicationUser>();
                    this.<>s__4 = user;
                    this.<user>5__3 = this.<>s__4;
                    this.<>s__4 = null;
                    if (this.<user>5__3 <= null)
                    {
                        goto Label_0262;
                    }
                    TaskAwaiter awaiter3 = this.<>4__this.SignInManager.SignInAsync(this.<user>5__3, false, false).GetAwaiter();
                    if (awaiter3.IsCompleted)
                    {
                        goto Label_0251;
                    }
                    this.<>1__state = num = 2;
                    this.<>u__3 = awaiter3;
                    d__ = this;
                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ManageController.<VerifyPhoneNumber>d__17>(ref awaiter3, ref d__);
                    return;
                Label_0234:
                    awaiter3 = this.<>u__3;
                    this.<>u__3 = new TaskAwaiter();
                    this.<>1__state = num = -1;
                Label_0251:
                    awaiter3.GetResult();
                    awaiter3 = new TaskAwaiter();
                Label_0262:
                    result = this.<>4__this.RedirectToAction("Index", new { Message = ManageController.ManageMessageId.AddPhoneSuccess });
                    goto Label_02C4;
                Label_027B:
                    this.<>4__this.ModelState.AddModelError("", "Failed to verify phone");
                    result = this.<>4__this.View(this.model);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
            Label_02C4:
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }
    }
}

