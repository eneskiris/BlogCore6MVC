using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IAboutService,AboutManager>();
builder.Services.AddSingleton<IAboutDal,EfAboutRepository>();

builder.Services.AddSingleton<IBlogService,BlogManager>();
builder.Services.AddSingleton<IBlogDal,EfBlogRepository>();

builder.Services.AddSingleton<ICategoryService,CategoryManager>();
builder.Services.AddSingleton<ICategoryDal,EfCategoryRepository>();

builder.Services.AddSingleton<ICommentService,CommentManager>();
builder.Services.AddSingleton<ICommentDal,EfCommentRepository>();

builder.Services.AddSingleton<IMessageService, MessageManager>();
builder.Services.AddSingleton<IMessageDal, EfMessageRepository>();

builder.Services.AddSingleton<IContactService,ContactManager>();
builder.Services.AddSingleton<IContactDal,EfContactRepository>();

builder.Services.AddSingleton<INewsLetterService,NewsLetterManager>();
builder.Services.AddSingleton<INewsLetterDal,EfNewsLetterRepository>();

builder.Services.AddSingleton<INotificationService,NotificationManager>();
builder.Services.AddSingleton<INotificationDal,EfNotificationRepository>();

builder.Services.AddSingleton<IWriterService,WriterManager>();
builder.Services.AddSingleton<IWriterDal,EfWriterRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddMvcCore(config =>
                            {
                                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                                config.Filters.Add(new AuthorizeFilter(policy));
                            });
builder.Services.AddMvcCore();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie(x => { x.LoginPath = "/Login/Index"; });
// builder.Services.AddSession();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
// app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();