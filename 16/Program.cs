using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

IHostEnvironment? env = app.Services.GetService<IHostEnvironment>();

// ���������� ����� �� ���������
app.UseDefaultFiles();
// ���������� ����������� �����
app.UseStaticFiles();

if (env != null)
{
    // ��������� ��������� �������� node_modules
    app.UseFileServer(new FileServerOptions()
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(env.ContentRootPath, "node_modules")
        ),
        RequestPath = "/node_modules",
        EnableDirectoryBrowsing = false
    });
}


app.Run();
